using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using postgreslogviewer.Models;
using postgreslogviewer.Parsing;

namespace postgreslogviewer.Pages
{
    public class LogsModel : PageModel
    {
        public List<LogEntry> LogEntries { get; set; }

        public async Task OnGet()
        {
            string path = @"C:\Program Files\PostgreSQL\12\data\log\postgresql-2020-07-08_000000.csv";

            var logEntries = new CSVLogReader().GetLogs(path);

            LogEntries = logEntries;
        }

        public async Task OnPost(FilterDTO filter)
        {
            
        }
    }

    public class FilterDTO
    {
        public bool A { get; set; }
        public bool B { get; set; }
        public bool C { get; set; }
        public bool D { get; set; }
        public bool E { get; set; }
        public bool F { get; set; }
        public bool G { get; set; }
        public bool H { get; set; }
        public bool I { get; set; }
        public bool J { get; set; }
        public bool K { get; set; }
        public bool L { get; set; }
        public bool M { get; set; }
        public bool N { get; set; }
        public bool O { get; set; }
    }
}
