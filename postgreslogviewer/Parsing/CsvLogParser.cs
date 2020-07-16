//using postgreslogviewer.Models;
//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;

//namespace postgreslogviewer.CsvParsing
//{
//    public interface IHeaderModel
//    {
//        IEnumerable<string> GetColumns();
//    }

//    public class CsvLogParser
//    {
//        private readonly IHeaderModel _headerModel;

//        public CsvLogParser(IHeaderModel headerModel)
//        {
//            _headerModel = headerModel;
//        }

//        public CsvLogParser()
//        {

//        }

//        public string[] WriteSafeReadAllLines(string path)
//        {
//            using (var csv = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
//            using (var sr = new StreamReader(csv))
//            {
//                List<string> file = new List<string>();
//                while (!sr.EndOfStream)
//                {
//                    file.Add(sr.ReadLine());
//                }

//                return file.ToArray();
//            }
//        }

//        public async IAsyncEnumerable<LogEntry> Parse(string path)
//        {
//            var lines = WriteSafeReadAllLines(path);

//            foreach (var line in lines)
//            {
//                string[] columns = line.Split(',');

//                if (columns.Length < 14)
//                    continue;

//                yield return new LogEntry
//                {
//                    A_TimeStamp = columns[0],
//                    B_User = columns[1],
//                    C_Database = columns[2],
//                    D_ProcessId = columns[3],
//                    E_Ip = columns[4],
//                    F_Na = columns[5],
//                    G_Na = columns[6],
//                    H_Na = columns[7],
//                    I_Na = columns[8],
//                    J_Na = columns[9],
//                    K_Na = columns[10],
//                    L_LogLevel = columns[11],
//                    M_Na = columns[12],
//                    N_Statement = columns[13]
//                };
//            }
//            yield break;
//        }
//    }
//}