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

        public List<LogEntry> GetLogs(string path, int rowsPerPage, string dbNames, string excludeContainingText)
        {
            var dbs = !string.IsNullOrEmpty(dbNames) ? dbNames.Split(',').ToList() : new List<string>();
            return EnumerateLogs(path, rowsPerPage, dbs, excludeContainingText).ToList();
        }

        private IEnumerable<LogEntry> EnumerateLogs(string path, int rowsPerPage, List<string> dbNames, string excludeContainingText)
        {

            using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var sr = new StreamReader(fs);
            using var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
            {
                csv.Configuration.HasHeaderRecord = false;

                int rowNum = 0;
                var query = csv.GetRecords<LogEntry>();
                if (!string.IsNullOrEmpty(excludeContainingText))
                    query = query.Where(x => !x.N_Statement.Contains(excludeContainingText));
                
                if (dbNames.Count > 0)
                {
                    foreach (var db in dbNames)
                        query = query.Where(x => x.C_Database.StartsWith(db));

                }

                foreach (var rec in query.Reverse().Take(rowsPerPage))
                {
                    rec.RowNumber = ++rowNum;
                    yield return rec;
                }
            }
        }
    }
}
