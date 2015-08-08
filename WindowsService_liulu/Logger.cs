using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace WindowsService_liulu
{
    public class Logger
    {
        string filename;
        string logpath;

        public Logger()
        {
            this.filename = "defaultname";
            this.logpath = ".";
        }

        public Logger(string name, string path)  // path = "C:\\systemstatus"
        {
            this.filename = name;
            this.logpath = path;
        }

        public int writelog(string input)
        {
            if (!Directory.Exists(logpath))
                Directory.CreateDirectory(logpath);


            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss "));
            sb.Append(input + "\r\n");

            string time_suffix = DateTime.Now.ToString("yyyy-MM-dd");
            File.AppendAllText(logpath + @"\" + filename + "_log_" + time_suffix + ".txt", sb.ToString());
            sb.Clear();
            return 0;
        }

    }
}
