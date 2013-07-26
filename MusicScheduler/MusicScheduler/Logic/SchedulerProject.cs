using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MusicScheduler.Logic
{
    public class SchedulerProject
    {
        private Scheduler child;
        private bool changeHappened = false;

        void changeHandler(object sender, EventArgs e) {
            changeHappened = true;
        }
        private Scheduler.ChangeEventHandler onChangeHandlerDelegate = null;

        public SchedulerProject(Scheduler child)
        {
            this.child = child;
            onChangeHandlerDelegate = new Scheduler.ChangeEventHandler(changeHandler);
            child.OnChange += onChangeHandlerDelegate;
        }

        public bool Save(string path)
        {
            StringBuilder output = new StringBuilder();
            
            XmlWriter writer = XmlWriter.Create(output);
            writer.WriteStartDocument();
                writer.WriteStartElement("SchedulerProject");
                writer.WriteAttributeString("version", "0.1");

                foreach (var item in child.ScheduledItems)
                {
                    writer.WriteStartElement("item");
                    writer.WriteAttributeString("filepath", item.FilePath);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            
            changeHappened = false;
            try
            {
                File.WriteAllText(path, output.ToString());
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception during SchedulerProject.Save");
                Console.WriteLine(e.Message);
                Console.Write(e.StackTrace);
                return false;
            }
        }

        public bool Load(string path)
        {
            List<String> names = new List<String>();
            String inputString;
            try
            {
                inputString = File.ReadAllText(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception during SchedulerProject.Load");
                Console.WriteLine(e.Message);
                Console.Write(e.StackTrace);
                return false;
            }
            
            try
            {
                StringReader input = new StringReader(inputString);
                XmlReader reader = XmlReader.Create(input);

                if (!reader.ReadToFollowing("SchedulerProject"))
                {
                    return false;
                }

                String version = reader.GetAttribute("version");
                if (!version.Equals("0.1"))
                {
                    return false;
                }

                if (reader.ReadToDescendant("item"))
                {
                    do
                    {
                        String randomName = reader.GetAttribute("filepath");
                        if (randomName != null)
                        {
                            names.Add(randomName);
                        }
                    }
                    while (reader.ReadToNextSibling("item"));
                }
            }
            catch (XmlException e)
            {
                Console.WriteLine("Exception during XML reading");
                Console.WriteLine(e.Message);
                Console.Write(e.StackTrace);
                return false;
            }

            child.RemoveAllItems();
            foreach (var name in names)
            {
                child.AddItem(name);
            }
            changeHappened = false;
            return true;
        }

        public void NewProject()
        {
            child.OnChange -= onChangeHandlerDelegate;
            child.RemoveAllItems();
            child.OnChange += onChangeHandlerDelegate;
            changeHappened = false;
        }

        public bool HasPendingChanges()
        {
            return changeHappened;
        }
    }
}
