using MongoDB.Bson;
using MongoDB.Driver;
using Poker.CMS.Common.DTOs;
using Poker.CMS.Common.Startup.Interface;
using System.Diagnostics;

namespace Poker.CMS.Common.Startup.Service
{
    public class MongoHealthChecker : IDatabaseHealthChecker
    {
        public string DbType => "MongoDB";

        public DatabaseStatus Check(string connectionString)
        {
            var result = new DatabaseStatus();
            var sw = Stopwatch.StartNew();
            try
            {
                using var client = new MongoClient(connectionString);
                client.GetDatabase("admin").RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait();
                result.Check = "OK";
            }
            catch (Exception ex)
            {
                result.Check = "Failed: " + ex.Message;
            }
            finally
            {
                sw.Stop();
                result.SpendTime = $"{sw.ElapsedMilliseconds}ms";
            }

            return result;
        }
    }
}
