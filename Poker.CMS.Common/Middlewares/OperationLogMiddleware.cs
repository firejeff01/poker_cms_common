using Microsoft.AspNetCore.Http;
using Poker.CMS.Common.Api.Response;
using Poker.CMS.Common.Attributes;
using Poker.CMS.Common.Enums;
using Poker.CMS.Common.OperationLog;
using Poker.CMS.Domain.Constants;
using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Poker.CMS.Common.Middlewares
{
    public class OperationLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOperationLogRepository _repo;

        public OperationLogMiddleware(RequestDelegate next, IOperationLogRepository repo)
        {
            _next = next;
            _repo = repo;
        }

        public async Task InvokeAsync(HttpContext httpContext, IOperationContext opCtx)
        {
            // 1. Only proceed if both Module & OperationLogAttribute are present
            var endpoint = httpContext.GetEndpoint();
            var moduleAttr = endpoint?.Metadata.GetMetadata<Module>();
            var opLogAttr = endpoint?.Metadata.GetMetadata<OperationLogAttribute>();
            if (moduleAttr == null || opLogAttr == null)
            {
                await _next(httpContext);
                return;
            }

            // 2. Full request URL
            var req = httpContext.Request;
            var url = $"{req.Path}{req.QueryString}";

            // 3. Read & buffer request body
            req.EnableBuffering();
            var isMultipartWithFile = req.HasFormContentType && req.Form.Files.Count > 0;
            var isImageDirect = req.ContentType?.StartsWith("image/", StringComparison.OrdinalIgnoreCase) == true;
            string? requestBody = null;
            if (req.ContentLength > 0 && req.Body.CanSeek && !isMultipartWithFile && !isImageDirect)
            {
                req.Body.Seek(0, SeekOrigin.Begin);
                using var rdr = new StreamReader(req.Body, leaveOpen: true);
                requestBody = await rdr.ReadToEndAsync();
                req.Body.Seek(0, SeekOrigin.Begin);
            }

            await using var memStream = new MemoryStream();
            var originalBody = httpContext.Response.Body;

            // 4. Swap out the response stream so we can capture it
            if (opLogAttr.Action != OperationLogAction.Download)
            {
                httpContext.Response.Body = memStream;
            }

            // 5. Start timing & prepare exception/success flags
            var sw = Stopwatch.StartNew();
            bool success = true;
            Exception? exception = null;

            try
            {
                // let everything else run (controllers, other middleware after routing, etc.)
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                success = false;
                exception = ex;
                throw;
            }
            finally
            {
                sw.Stop();
                success = success && httpContext.Response.StatusCode == 200;

                string? responseBody = null;
                if (opLogAttr.Action != OperationLogAction.Download)
                {
                    // 6. Read JSON response (if any)
                    memStream.Seek(0, SeekOrigin.Begin);
                    using var rdr = new StreamReader(memStream, leaveOpen: true);
                    responseBody = await rdr.ReadToEndAsync();
                    memStream.Seek(0, SeekOrigin.Begin);

                    // 7. Copy the buffered content back to the real response stream
                    await memStream.CopyToAsync(originalBody);
                    httpContext.Response.Body = originalBody;

                    var baseResponse = JsonSerializer.Deserialize<BaseResponse>(responseBody);
                    success = success && baseResponse.Result;
                }

                if (responseBody is not null)
                {
                    responseBody = Regex.Unescape(responseBody);
                }

                // ***** 取代密碼 token 等機密資訊
                var pattern = @"""(password|token|operator_password)""\s*:\s*""(.*?)""";
                var replacement = @"""$1"":""*****""";
                var options = RegexOptions.IgnoreCase | RegexOptions.Singleline;

                if (!string.IsNullOrEmpty(requestBody))
                {
                    requestBody = Regex.Replace(requestBody, pattern, replacement, options);
                }

                if (!string.IsNullOrEmpty(responseBody))
                {
                    responseBody = Regex.Replace(responseBody, pattern, replacement, options);
                }

                var createUser = int.TryParse(httpContext.User?.Identity?.Name, out var uid) ? uid : 0;
                var createUserName = httpContext.User?.FindFirst(CustomClaimTypes.UserName)?.Value ?? string.Empty;

                if (opCtx.LoginUserId != null)
                {
                    createUser = opCtx.LoginUserId.Value;
                    createUserName = opCtx.LoginUserName ?? string.Empty;
                }

                // 8. Build & write the log entry
                var log = new Poker.CMS.Common.OperationLog.OperationLog
                {
                    Module = string.IsNullOrEmpty(opLogAttr.Module)? moduleAttr.ModuleName : opLogAttr.Module,
                    SubModule = opLogAttr.SubModule,
                    Action = opLogAttr.Action,
                    DurationMs = sw.Elapsed.TotalMilliseconds,
                    Success = success,
                    Exception = exception?.ToString(),
                    CreateUser = createUser,
                    RequestUrl = url,
                    RequestBody = requestBody,
                    ResponseBody = responseBody,
                    BeforeData = opCtx.BeforeData,
                    AfterData = opCtx.AfterData,
                    CreateTime = DateTime.UtcNow,
                    Ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? string.Empty,
                    CreateUserName = createUserName,
                };

                await _repo.InsertAsync(log);
            }
        }
    }
}