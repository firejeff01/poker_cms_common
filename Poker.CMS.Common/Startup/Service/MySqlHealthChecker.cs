using MySql.Data.MySqlClient;
using Poker.CMS.Common.DTOs;
using Poker.CMS.Common.Startup.Interface;
using System.Diagnostics;

namespace Poker.CMS.Common.Startup.Service
{
    public class MySqlHealthChecker : IDatabaseHealthChecker
    {
        public string DbType => "MySQL";

        public DatabaseStatus Check(string connectionString)
        {
            var result = new DatabaseStatus();
            var sw = Stopwatch.StartNew();
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();
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
