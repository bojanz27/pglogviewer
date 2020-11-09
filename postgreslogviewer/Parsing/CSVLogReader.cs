using CsvHelper;
using postgreslogviewer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace postgreslogviewer.Parsing
{
    public class CsvLogReader
    {

        public CsvLogReader()
        {

        }

        public List<LogEntry> GetLogs(string path, int rowsPerPage, bool replaceParams)
        {
            try
            {
                path = path.Trim('\"');
                using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var sr = new StreamReader(fs);
                using var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
                {
                    csv.Configuration.HasHeaderRecord = false;
                    var recordsEnum = csv.GetRecords<LogEntry>().Reverse().Take(rowsPerPage);
                    
                    if (!replaceParams)
                        return recordsEnum.ToList();
                    
                    List<LogEntry> entries = new List<LogEntry>();
                    foreach (var r  in recordsEnum)
                    {
                        if (!string.IsNullOrEmpty(r.O_Parameters))
                        {
                            ReplaceParams(r);
                        }
                        entries.Add(r);
                    }
                    return entries;
                }
            }
            catch
            {
                return new List<LogEntry>();
            }
        }

        private void ReplaceParams(LogEntry r)
        {
            List<(string name, string value)> parsed = ParseParameters(r.O_Parameters);
            foreach (var (name, value) in parsed)
            {
                r.N_Statement = r.N_Statement.Replace(name, value);
            }
        }

        private List<(string, string)> ParseParameters(string source)
        {
            var parameters = source;
            List<(string, string)> parsed = new List<(string, string)>();

            if (parameters.StartsWith("parameters:"))
                parameters = parameters.Substring(11);
            parameters = parameters.Trim();
            var paramsList = parameters.Split(',');
            foreach (var p in paramsList)
            {
                var parts = p.Split('=');
                parsed.Add((parts[0].Trim(), parts[1].Trim()));
            }
            parsed.Reverse();
            return parsed;
        }
    }
}
