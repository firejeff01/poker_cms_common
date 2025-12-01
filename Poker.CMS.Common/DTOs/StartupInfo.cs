namespace Poker.CMS.Common.DTOs
{
    public class StartupInfo
    {
        public string Message { get; set; }
        public string EnvironmentName { get; set; }
        public string ProjectName { get; set; }
        public string Version { get; set; }
        public string StartupTime { get; set; }
        public string Listening { get; set; }
        public string Status { get; set; }
        public Dictionary<string, DatabaseStatus> DB { get; set; }
    }

    public class DatabaseStatus
    {
        public string Check { get; set; }
        public string SpendTime { get; set; }
    }

    public class ExternalServiceStatus
    {
        public string Check { get; set; }
        public string SpendTime { get; set; }
    }
}
