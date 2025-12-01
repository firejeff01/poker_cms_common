using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Poker.CMS.Common.Extensions
{
    public static class ExceptionExtension
    {
        public static string GetMessage(this Exception exception)
        {
            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

            var stackTraceInfo = GetStackTraceInfo(exception.StackTrace);

            var content = new ErrorMessage()
            {
                Message = "🚨 Exception Alert 🚨\n\n",
                EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Unknown",
                ProjectName = versionInfo.ProductName,
                Location = stackTraceInfo.FileName,
                Line = stackTraceInfo.LineNumber.ToString(),
                Information = exception.Message,
                Status = "Error"
            };

            content.Message += $"[{content.EnvironmentName}][{content.ProjectName}][{content.Status}]\n" +
                               "{\n" +
                               $"    Program File: {content.Location}\n" +
                               $"    Line Number: {content.Line}\n" +
                               $"    Message: {exception.Message} | {exception.InnerException?.Message}\n" +
                               "}";

            return content.Message;
        }


        private static (string FileName, int LineNumber) GetStackTraceInfo(string stackTrace)
        {
            if (string.IsNullOrEmpty(stackTrace))
            {
                return ("Unknown", -1);
            }

            // 解析堆疊追蹤中的檔案名稱和行號
            var stackTraceLines = stackTrace.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
            var match = Regex.Match(stackTraceLines, @"\s+at\s+(.*)\s+in\s+(.*):line\s+(\d+)");

            if (match.Success)
            {
                var fileName = Path.GetFileName(match.Groups[2].Value);
                var lineNumber = int.Parse(match.Groups[3].Value);
                return (fileName, lineNumber);
            }
            return ("Unknown", -1);  // 如果無法解析，返回預設值
        }

        private class ErrorMessage
        {
            public string Message { get; set; }
            public string EnvironmentName { get; set; }
            public string ProjectName { get; set; }
            public string Location { get; set; }
            public string Line { get; set; }
            public string Information { get; set; }
            public string Status { get; set; }
        }
    }
}
