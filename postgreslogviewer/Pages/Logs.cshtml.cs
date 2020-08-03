using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using postgreslogviewer.Models;
using postgreslogviewer.Parsing;

namespace postgreslogviewer.Pages
{
    public class LogsModel : PageModel
    {
        private readonly CsvLogReader _logReader;

        public List<LogEntry> LogEntries { get; set; }

        [BindProperty]
        public int RowsPerPage { get; set; } = 20;

        [BindProperty]
        public string PathToCsvLogFile { get; set; }

        public LogsModel(CsvLogReader csvLogReader)
        {
            _logReader = csvLogReader;
        }
        
        public async Task OnGet()
        {
            if (!string.IsNullOrEmpty(PathToCsvLogFile))
            {
                LogEntries = _logReader.GetLogs(PathToCsvLogFile, RowsPerPage);
            }
            else 
                LogEntries = new List<LogEntry>();
            
        }

        public async Task OnPost()
        {
            var logEntries = _logReader.GetLogs(PathToCsvLogFile, RowsPerPage);

            LogEntries = logEntries;
        }
    }

  
}
