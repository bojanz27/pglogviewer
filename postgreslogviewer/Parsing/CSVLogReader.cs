using CsvHelper;
using postgreslogviewer.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;

namespace postgreslogviewer.Parsing
{
    public class CsvLogReader
    {
        
        public CsvLogReader()
        {

        }

        public List<LogEntry> GetLogs(string path, int rowsPerPage)
        {
            return EnumerateLogs(path, rowsPerPage).ToList();
        }

        public IEnumerable<LogEntry> EnumerateLogs(string path, int rowsPerPage)
        {

            using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var sr = new StreamReader(fs);
            using var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
            {
                csv.Configuration.HasHeaderRecord = false;

                int rowNum = 0;
                foreach (var rec in csv.GetRecords<LogEntry>().Reverse().Take(rowsPerPage))
                {
                    rec.RowNumber = ++rowNum;
                    yield return rec;
                }
            }
        }
    }
}
