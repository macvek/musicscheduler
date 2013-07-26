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

namespace MusicScheduler
{
    partial class SchedulerTests
    {
        [TestMethod]
        public void testIndexOfItems()
        {
            Assert.IsTrue(scheduler.Empty());
            var a = scheduler.AddItem("Random1");
            var b = scheduler.AddItem("Random2");

            a.FilePath = "A";
            b.FilePath = "A";

            Assert.IsFalse(a.Index == b.Index);
        }
        
        [TestMethod]
        public void testEmptyClipboardPaste()
        {
            Assert.IsTrue(scheduler.PasteItems());
        }

        [TestMethod]
        // Copies items from a scheduler and pastes to end of list
        public void testCopyAndPasteWithAppend()
        {
            addManyItems(100);
            Assert.IsFalse(scheduler.Empty());
            var items = scheduler.ScheduledItems;
            var pastedItems = new SchedulerItem[items.Length*2];
            Array.Copy(items, pastedItems, items.Length);
            Array.Copy(items,0, pastedItems, items.Length, items.Length);
            scheduler.CopyItems(items);
            scheduler.PasteItems();
            CollectionAssert.AreEqual(scheduler.ScheduledItems, pastedItems);
            items = scheduler.ScheduledItems;
            var anotherPastedItems = new SchedulerItem[pastedItems.Length * 2];
            Array.Copy(items, 0, anotherPastedItems, 0, items.Length);
            Array.Copy(items, 0, anotherPastedItems, items.Length, items.Length);
            scheduler.CopyItems(items);
            scheduler.PasteItems();
            Assert.IsFalse(scheduler.Empty());
            
        }

        [TestMethod]
        public void testCopyAndPasteWithPrepend()
        {
            addManyItems(100);
            Assert.IsFalse(scheduler.Empty());
            var items = scheduler.ScheduledItems;
            SchedulerItem[] last5items = new SchedulerItem[5];
            SchedulerItem[] afterPasteShouldBe = new SchedulerItem[105];

            Array.Copy(items, 0, afterPasteShouldBe, 5, 100);
            Array.Copy(items, 95, last5items, 0, 5);

            Array.Copy(last5items, 0, afterPasteShouldBe, 0, 5);

            scheduler.CopyItems(last5items);
            var firstItem = scheduler.ScheduledItems[0];
            scheduler.PasteItems(firstItem);
            Assert.IsTrue(105 == scheduler.ScheduledItems.Length);
            CollectionAssert.AreEqual(scheduler.ScheduledItems, afterPasteShouldBe);
        }

        [TestMethod]
        // Cuts items from a scheduler and pastes to end of list
        public void testCutAndPasteWithAppend()
        {
            addManyItems(100);
            Assert.IsFalse(scheduler.Empty());
            var items = scheduler.ScheduledItems;
            scheduler.CutItems(items);
            Assert.IsTrue(scheduler.Empty());
            scheduler.PasteItems();
            Assert.IsFalse(scheduler.Empty());
            var pastedItems = scheduler.ScheduledItems;
            CollectionAssert.AreEqual(items, pastedItems);
        }

        // Cuts items and puts it before selected item
        [TestMethod]
        public void testCutAndPasteWithPrepend()
        {
            addManyItems(100);
            Assert.IsFalse(scheduler.Empty());
            var items = scheduler.ScheduledItems;
            SchedulerItem[] last5items = new SchedulerItem[5];
            SchedulerItem[] afterPasteShouldBe= new SchedulerItem[100];

            Array.Copy(items, 0, afterPasteShouldBe, 5,95);
            Array.Copy(items, 95, last5items, 0, 5);

            Array.Copy(last5items, 0, afterPasteShouldBe, 0, 5);

            scheduler.CutItems(last5items);
            Assert.IsTrue(95 == scheduler.ScheduledItems.Length);
            var firstItem = scheduler.ScheduledItems[0];
            scheduler.PasteItems(firstItem);
            Assert.IsTrue(100 == scheduler.ScheduledItems.Length);
            CollectionAssert.AreEqual(scheduler.ScheduledItems, afterPasteShouldBe);
        }
    }
}
