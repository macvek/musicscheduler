using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicScheduler.Logic
{
    [Serializable]
    public class SchedulerItem
    {
        private String title;
        private String artists;
        private String filepath;

        private bool ExtendedTitle = false;

        public String Title
        {
            get
            {
                if (ExtendedTitle)
                {
                    return title;
                }
                else
                {
                    return SchedulerExporter.GetFileName(FilePath);
                }
            }
        }

        public String FilePath
        {
            get
            {
                return filepath;
            }
            set
            {
                filepath = value;
                title = filepath;
                if (!System.IO.File.Exists(filepath))
                {
                    title = "Missing: " + filepath;
                    ExtendedTitle = true;
                    return;
                }
                
                TagLib.File tagFile;
                try
                {
                    tagFile = TagLib.File.Create(filepath);
                }
                catch (TagLib.UnsupportedFormatException e)
                {
                    Console.WriteLine(e);
                    return;
                }
                catch (TagLib.CorruptFileException e)
                {
                    Console.WriteLine(e);
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return;
                }

                var tag = tagFile.Tag;
                if (tag != null)
                {
                    if (tag.Title != null)
                    {
                        title = tag.Title;
                        ExtendedTitle = true;
                    }
                    else
                    {
                        ExtendedTitle = false;
                    }

                    var albumArtists = tag.AlbumArtists;
                    if (albumArtists != null && albumArtists.Length > 0)
                    {
                        artists = string.Join(", ", albumArtists);
                    }
                }
                else
                {
                    ExtendedTitle = false;
                }
            }
        }

        public Scheduler Scheduler { set; get;}

        public override string ToString()
        {
            return Title;
        }

        public int Index { 
            get {
                return Scheduler.getIndexOfItem(this);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(SchedulerItem)))
            {
                var other = (SchedulerItem)obj;
                if (other.FilePath == FilePath)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
