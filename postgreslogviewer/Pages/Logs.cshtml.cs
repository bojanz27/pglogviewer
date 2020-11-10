using System.Collections.Generic;
using System.Linq;
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
        public List<LogEntry> LogEntries { get; set; }

        [BindProperty]
        public int RowsPerPage { get; set; } = 20;

        [BindProperty]
        public string PathToCsvLogFile { get; set; }
        [BindProperty]
        public string Databases { get; set; }
        [BindProperty]
        public bool ReplaceParams { get; set; }

        public async Task OnGet()
        {
            if (!string.IsNullOrEmpty(PathToCsvLogFile))
            {
                LogEntries = new CsvLogReader().GetLogs(PathToCsvLogFile, RowsPerPage, ReplaceParams, Databases);
            }
            else 
                LogEntries = new List<LogEntry>();
            
        }

        public async Task OnPost()
        {
            var logEntries = new CsvLogReader().GetLogs(PathToCsvLogFile, RowsPerPage, ReplaceParams, Databases);

            LogEntries = logEntries;
        }
    }

  
}
