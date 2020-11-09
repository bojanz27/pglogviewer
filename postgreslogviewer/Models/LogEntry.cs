using CsvHelper.Configuration.Attributes;

namespace postgreslogviewer.Models
{
    public class LogEntry
    {
        [Index(0)]
        public string A_TimeStamp { get; set; }
        [Index(1)]
        public string B_User { get; set; }
        [Index(2)]
        public string C_Database { get; set; }
        [Index(3)]
        public string D_ProcessId { get; set; }
        [Index(4)]
        public string E_Ip { get; set; }
        [Index(5)]
        public string F_Na { get; set; }
        [Index(6)]
        public string G_Na { get; set; }
        [Index(7)]
        public string H_Na { get; set; }
        [Index(8)]
        public string I_Na { get; set; }
        [Index(9)]
        public string J_Na { get; set; }
        [Index(10)]
        public string K_Na { get; set; }
        [Index(11)]
        public string L_LogLevel { get; set; }
        [Index(12)]
        public string M_Na { get; set; }
        [Index(13)]
        public string N_Statement { get; set; }
        [Index(14)]
        public string O_Parameters { get; set; }
    }
}