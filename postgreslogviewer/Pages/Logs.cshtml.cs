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

        public async Task OnGet()
        {
            if (!string.IsNullOrEmpty(PathToCsvLogFile))
            {
                LogEntries = new CSVLogReader().GetLogs(PathToCsvLogFile, RowsPerPage);
            }
            else 
                LogEntries = new List<LogEntry>();
            
        }

        public async Task OnPost()
        {
            var logEntries = new CSVLogReader().GetLogs(PathToCsvLogFile, RowsPerPage);

            LogEntries = logEntries;
        }
    }

  
}
