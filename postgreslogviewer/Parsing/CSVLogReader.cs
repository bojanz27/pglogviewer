using CsvHelper;
using postgreslogviewer.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace postgreslogviewer.Parsing
{
    public class CSVLogReader
    {
        
        public CSVLogReader()
        {

        }

        public List<LogEntry> GetLogs(string path)
        {

            using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var sr = new StreamReader(fs);
            using var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
            {
                csv.Configuration.HasHeaderRecord = false;
                return csv.GetRecords<LogEntry>().Take(100).ToList();
            }
        }
    }
}
