using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MusicScheduler.Logic
{
    public class ExporterJob
    {
        public String ExportName { get; set; }
        public SchedulerItem Item { get; set; }
        public String SourcePath { get; set; }
        public String DestinationPath
        {
            get
            {
                return ExportName + "/" + DestinationName;
            }
        }

        public String DestinationName { get; set; }

        public bool execute()
        {
            if (File.Exists(SourcePath))
            {
                try
                {
                    File.Copy(SourcePath, DestinationPath);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
