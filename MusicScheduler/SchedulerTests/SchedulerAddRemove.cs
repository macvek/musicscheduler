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
    [TestClass]
    public partial class SchedulerTests
    {
        Scheduler scheduler;
        SchedulerProject project;
        SchedulerExporter exporter;

        [TestInitialize]
        public void prepare()
        {
            scheduler = new Scheduler();
            project = new SchedulerProject(scheduler);
            exporter = new SchedulerExporter(scheduler);
        }


        [TestMethod]
        // Check addition of one item
        public void testAddOneItem()
        {
            Assert.IsTrue(scheduler.Empty());
            SchedulerItem item = scheduler.AddItem("Hello");
            Assert.IsNotNull(item);
            Assert.IsTrue(scheduler.HasItem(item));
            Assert.IsFalse(scheduler.Empty());
            Assert.IsTrue(scheduler.RemoveItem(item));
            Assert.IsFalse(scheduler.RemoveItem(item));
            Assert.IsFalse(scheduler.HasItem(item));
            Assert.IsTrue(scheduler.Empty());
        }

        private Random randomizer = new Random();
        SchedulerItem[] addManyItems(int limit)
        {
            SchedulerItem[] items = new SchedulerItem[limit];
            for (int i = 0; i < limit; i++)
            {
                SchedulerItem addedItem = scheduler.AddItem("X"+randomizer.Next());
                Assert.IsNotNull(addedItem);
                items[i] = addedItem;
            }
            return items;
        }

        [TestMethod]
        // Check addition of many items
        public void testAddManyItems()
        {
            Assert.IsTrue(scheduler.Empty());
            int limit = 100;
            var items = addManyItems(limit);

            foreach (SchedulerItem each in items)
            {
                Assert.IsFalse(scheduler.Empty());
                Assert.IsTrue(scheduler.HasItem(each));
                Assert.IsTrue(scheduler.RemoveItem(each));
                Assert.IsFalse(scheduler.RemoveItem(each));
            }

            Assert.IsTrue(scheduler.Empty());
        }

        [TestMethod]
        // Check order preservation
        public void testCheckOrder()
        {
            Assert.IsTrue(scheduler.Empty());
            var firstItems = addManyItems(100);
            var lastItems = addManyItems(100);
            
            // Put firstItems after lastItems
            foreach (var each in firstItems)
            {
                Assert.IsTrue(scheduler.RemoveItem(each));
                scheduler.PushItem(each);
            }

            var scheduledItems = scheduler.ScheduledItems;
            var ptr = 0;

            foreach (var each in lastItems)
            {
                Assert.AreEqual(each, scheduledItems[ptr++]);
            }

            foreach (var each in firstItems)
            {
                Assert.AreEqual(each, scheduledItems[ptr++]);
            }  
        }

        void assertIndexes(SchedulerItem[] items, int[] orders)
        {
            var scheduledItems = scheduler.ScheduledItems;
            for (int i = 0; i < orders.Length; i++)
            {
                Assert.AreEqual(items[orders[i]], scheduledItems[i]); 
            }
        }

        [TestMethod]
        // Operates on 5 items and moves each of them up/down
        public void testMoveUpDown()
        {
            Assert.IsTrue(scheduler.Empty());
            var testItems = addManyItems(5);
            var scheduledItems = scheduler.ScheduledItems;
            var initialState = new int[] {0,1,2,3,4};
            // Check initial order
            assertIndexes(testItems, initialState);

            // one element move down
            scheduler.moveDown(testItems[0]);
            assertIndexes(testItems, new int[] {1,0,2,3,4});

            // one element move up (it resets state to initial one)
            scheduler.moveUp(testItems[0]);
            assertIndexes(testItems, initialState);

            // move three sibling items down
            var moveItems = new SchedulerItem[] {testItems[0], testItems[1], testItems[2]};
            scheduler.moveDown(moveItems);
            assertIndexes(testItems, new int[] {3,0,1,2,4});

            scheduler.moveUp(moveItems);
            assertIndexes(testItems, initialState);

            /* move three sibling items down 3 times.
             * Check if moving down the edge is handled, it should move them only 2 times down
             */

            for (int i=0;i<3;i++) {
                scheduler.moveDown(moveItems);
            }
            assertIndexes(testItems, new int[] {3,4,0,1,2});

            /* now move it 3 times up, to check if moving up down the edge 
             * is handled as well 
             */

            for (int i = 0; i < 3; i++)
            {
                scheduler.moveUp(moveItems);
            }
            assertIndexes(testItems, initialState);

            // check moving separated items down and up
            moveItems = new SchedulerItem[] { testItems[0], testItems[2] };
            
            scheduler.moveDown(moveItems);
            assertIndexes(testItems, new int[] { 1, 0, 3, 2, 4 });

            scheduler.moveUp(moveItems);
            assertIndexes(testItems, initialState);

            /* Check if previous moving takes arguments order into account,
             * it shouldn't, so moving 0,2,4 should work same as moving 2,0,4
             */
            var sortedItems = new SchedulerItem[] { testItems[0], testItems[2], testItems[4] };
            var randomItems = new SchedulerItem[] { testItems[2], testItems[0], testItems[4] };

            foreach (var itemsSet in new SchedulerItem[][] { sortedItems, randomItems })
            {
                /* check moving 3 separated items down.
                 * case o 0,2,4 indexes should connect elements 2 and 4
                 * moving it back to top 2 times should connect 0 and 2
                 * so after moving down and up it should have sequence 0,2,4,1,3
                 * last move is to move 1,3 up 2 times and move 3 down ones to revert
                 * to initialState 
                 */
                moveItems = itemsSet;
                scheduler.moveDown(moveItems);
                assertIndexes(testItems, new int[] { 1, 0, 3, 2, 4 });

                scheduler.moveUp(moveItems);
                scheduler.moveUp(moveItems);
                assertIndexes(testItems, new int[] { 0, 2, 4, 1, 3 });

                moveItems = new SchedulerItem[] { testItems[1], testItems[3] };
                scheduler.moveUp(moveItems);
                scheduler.moveUp(moveItems);
                assertIndexes(testItems, new int[] { 0, 1, 3, 2, 4 });

                scheduler.moveDown(testItems[3]);
                assertIndexes(testItems, initialState);
            }
        }
    }
}
