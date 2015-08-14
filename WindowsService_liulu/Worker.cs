using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService_liulu
{
    public class Worker
    {

        public static void DoWork()
        {
            Logger logger = new Logger(config.logname, config.logpath);

            while (true)
            {
                logger.writelog("Usage of CPU = " + SystemStatus.getTotalCpuUsage());
                logger.writelog("Usage of Memory = " + SystemStatus.getTotalRAMUsage());


                string process1 = "pcoip_server_win32";
                string pcoip_server_result = SystemStatus.getCpuUsageByProcessName(process1);
                if (pcoip_server_result != "")
                    logger.writelog("Usage of CPU " + process1 + " = " + pcoip_server_result);

                pcoip_server_result = SystemStatus.getMemoryUsageByProcessName(process1);
                if (pcoip_server_result != "")
                    logger.writelog("Usage of Memory " + process1 + " = " + pcoip_server_result);

                string process2 = "wsnm";
                string wsnm_result = SystemStatus.getCpuUsageByProcessName(process2);
                if (wsnm_result != "")
                    logger.writelog("Usage of CPU " + process2 + " = " + wsnm_result);

                wsnm_result = SystemStatus.getMemoryUsageByProcessName(process2);
                if (wsnm_result != "")
                    logger.writelog("Usage of Memory " + process2 + " = " + wsnm_result);


                System.Threading.Thread.Sleep(5000);
            }
        }


    }
}
