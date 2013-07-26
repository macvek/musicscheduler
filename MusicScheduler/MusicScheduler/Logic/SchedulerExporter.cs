using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicScheduler.Logic
{
    public class SchedulerExporter
    {
        private Scheduler scheduler;
        private String mask = "00000";

        private String GetPrefixByIndex(int index)
        {
            String indexString = index.ToString();
            if (indexString.Length > mask.Length)
            {
                return indexString;
            }
            return mask.Substring(0, mask.Length - indexString.Length) + indexString;
        }

        public static String GetFileName(String path)
        {
            int indexOf = path.LastIndexOf('\\');
            if (indexOf == -1)
            {
                indexOf = path.LastIndexOf('/');
            }
            if (indexOf == -1)
            {
                return path;
            }
            else if (indexOf < path.Length)
            {
                return path.Substring(indexOf+1);
            }
            else
            {
                return "UNKNOWNPATH";
            }
        }
        
        public ExporterJob[] prepareWorklist(String exportName)
        {
            List<ExporterJob> jobs = new List<ExporterJob>();
            int ptr = 0;
            foreach (var item in scheduler.ScheduledItems)
            {
                ExporterJob job = new ExporterJob();
                job.ExportName = exportName;
                job.Item = item;
                job.SourcePath = item.FilePath;
                job.DestinationName = GetPrefixByIndex(ptr++) +"_"+ GetFileName(item.FilePath);

                jobs.Add(job);
            }

            return jobs.ToArray();
        }
        
        public SchedulerExporter(Scheduler scheduler)
        {
            this.scheduler = scheduler;
        }

    }
}
