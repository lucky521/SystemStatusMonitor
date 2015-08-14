using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WindowsService_liulu
{
    public static class config
    {
       public const string logname = "test";
       public const string logpath = @"C:\systemstatuslog";
    };

    public partial class Service1 : ServiceBase
    {
        private Thread worker;


        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            worker = new Thread(Worker.DoWork); // start thread to do while job
            worker.Start();

        }

        protected override void OnStop()
        {
            if (!worker.Join(3000))
                worker.Abort();

            Logger logger = new Logger(config.logname, config.logpath);  // write ending log.
            logger.writelog("Service Stoped.");

        }
    }
}
