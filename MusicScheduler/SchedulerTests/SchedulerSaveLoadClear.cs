/*
 * Author: Maciej Aleksandrowicz ( macvek@gmail.com ), 2013
 * 
    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation; either version 2 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicScheduler.Logic;
using System.IO;

namespace MusicScheduler
{
    public partial class SchedulerTests
    {

        [TestMethod]
        public void testSaveLoadDiffrentProjects()
        {
            Assert.IsTrue(scheduler.Empty());
            project.Save("tmpname1");

            addManyItems(10);
            SchedulerItem[] generated = scheduler.ScheduledItems;

            project.Save("tmpname2");
            Assert.IsTrue(project.Load("tmpname1"));
            Assert.IsTrue(scheduler.Empty());
            project.Load("tmpname2");
            CollectionAssert.AreEqual(generated, scheduler.ScheduledItems);
        }

        [TestMethod]
        public void testSaveLoadProject()
        {
            Assert.IsTrue(scheduler.Empty());
            project.Save("tmpname");
            Assert.IsTrue(project.Load("tmpname"));
            Assert.IsTrue(scheduler.Empty());
            
            addManyItems(10);
            SchedulerItem[] generated = new SchedulerItem[10];
            Array.Copy(scheduler.ScheduledItems, generated, 10);
            
            project.Save("tmpname");
            Assert.IsTrue(project.Load("tmpname"));
            CollectionAssert.AreEqual(generated, scheduler.ScheduledItems);
        }

        [TestMethod]
        public void testNewProject()
        {
            Assert.IsTrue(scheduler.Empty());
            addManyItems(10);
            project.NewProject();
            Assert.IsFalse(project.HasPendingChanges());
            Assert.IsTrue(scheduler.Empty());
        }

        [TestMethod]
        public void testPendingChanges()
        {
            Assert.IsTrue(scheduler.Empty());
            addManyItems(10);
            Assert.IsTrue(project.HasPendingChanges());
            project.Save("tmpname");
            Assert.IsFalse(project.HasPendingChanges());

            project.Save("tmpname");
            SchedulerItem[] generated = new SchedulerItem[10];
            Array.Copy(scheduler.ScheduledItems, generated, 10);
            foreach (var each in generated)
            {
                scheduler.RemoveItem(each);
            }
            Assert.IsTrue(project.HasPendingChanges());
            project.Save("tmpname");
            Assert.IsFalse(project.HasPendingChanges());
        }

        [TestMethod]
        public void testExport()
        {
            Assert.IsTrue(scheduler.Empty());
            addManyItems(10);
            var items = scheduler.ScheduledItems;
            int byteptr = 0;
            foreach (var each in items)
            {
                var file = File.OpenWrite(each.FilePath);
                file.Write(new byte[] { (byte)byteptr++ }, 0, 1);
                file.Close();
            }
            if (!Directory.Exists("tempoutput"))
            {
                Directory.CreateDirectory("tempoutput");
            }
            var worklist = exporter.prepareWorklist("tempoutput");

            string[] keys = new string[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                var work = worklist[i];
                Assert.IsTrue(work.Item == items[i]);
                Assert.IsTrue(work.SourcePath == items[i].FilePath);
                keys[i] = work.DestinationName;
            }

            Array.Sort(keys, worklist);
            for (int i = 0; i < items.Length; i++)
            {
                Assert.IsTrue(worklist[i].SourcePath == items[i].FilePath);
            }

            byteptr = 0;
            foreach (var each in worklist)
            {
                Assert.IsTrue(each.execute());
                var file = File.OpenRead(each.DestinationPath);
                byte[] input = new byte[1];
                file.Read(input, 0, 1);
                Assert.IsTrue(input[0] == byteptr++);
                file.Close();
                File.Delete(each.DestinationPath);
            }

            Directory.Delete("tempoutput", true);
        }
    }
}
