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
    public partial class Service1 : ServiceBase
    {
        private Thread worker;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            worker = new Thread(Worker.DoWork);
            worker.Start();

        }

        protected override void OnStop()
        {
            if (!worker.Join(3000))
                worker.Abort();

            Logger logger = new Logger("systemstatus", "C:\\systemstatus");
            logger.writelog("Service Stoped.");

        }
    }
}
