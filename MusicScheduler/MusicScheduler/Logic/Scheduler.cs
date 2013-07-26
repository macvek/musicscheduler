using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MusicScheduler.Logic
{
    /**
     * Scheduler assumes it has provided valid data, so there is no null pointer checking etc.
     * Such validation should be performed by calling methods.
     */
    public class Scheduler
    {
        private List<SchedulerItem> Items = new List<SchedulerItem>();
        public delegate void ChangeEventHandler(object sender, EventArgs e);

        public event ChangeEventHandler OnChange;

        private void TriggerOnChange()
        {
            if (OnChange != null)
            {
                OnChange(this, null);
            }
        }

        /* 
         * Returns item appended to list
         */
        public SchedulerItem AddItem(String path)
        {
            var each = new SchedulerItem();
            each.FilePath = path;
            Items.Add(each);
            each.Scheduler = this;
            TriggerOnChange();
            return each;
        }

        /*
         * item mustn't be null
         */
        public bool HasItem(SchedulerItem item)
        {
            return Items.Contains(item);
        }

        public bool Empty()
        {
            return Items.Count == 0;
        }

        public void RemoveAllItems()
        {
            foreach (var item in Items)
            {
                ClearItemRelations(item);
            };
            TriggerOnChange();
            Items.Clear();
        }

        /*
         * item mustn't be null
         */
        private void  ClearItemRelations(SchedulerItem item)
        {
            item.Scheduler = null;
        }

        /*
         * item mustn't be null
         */
        public bool RemoveItem(SchedulerItem item)
        {
            if (!HasItem(item))
            {
                return false;
            }
            else
            {
                ClearItemRelations(item);
                Items.Remove(item);
                TriggerOnChange();
                return true;
            }
        }

        public SchedulerItem[] ScheduledItems
        {
            get
            {
                return Items.ToArray();
            }
        }

        /*
         * each mustn't be null
         */
        public void PushItem(SchedulerItem each)
        {
            each.Scheduler = this;
            Items.Add(each);
            TriggerOnChange();
        }

        public void InsertItem(SchedulerItem each, int index)
        {
            each.Scheduler = this;
            Items.Insert(index, each);
            TriggerOnChange();
        }

        /*
         * items MUSTN'T be null
         * each item must belong to this Scheduler
         */
        private void SortItems(SchedulerItem[] items)
        {
            // SchedulerItem[] is used to prevent identity error
            Dictionary<int, SchedulerItem> map = new Dictionary<int, SchedulerItem>();
            int[] indexes = new int[items.Length];
            int ptr = 0;
            foreach (var each in items) {
                map.Add(each.Index, each);
                indexes[ptr++] = each.Index;
            }

            sortAscending(indexes);
            ptr = 0;
            foreach (var each in indexes)
            {
                items[ptr++] = map[each];
            }
        }
        
        private void sortDescending(int[] input)
        {
            sortAscending(input);
            Array.Reverse(input);
        }

        private void sortAscending(int[] input)
        {
            Array.Sort(input);            
        }

        /*
         * input MUSTN'T be null,
         * input must have distinct elements
         */
        private int[] getIndexesForItems(SchedulerItem[] input)
        {
            var len = input.Length;
            var indexes = new int[len];

            for (var i = 0; i < len; i++)
            {
                indexes[i] = getIndexOfItem(input[i]);
            }

            return indexes;
        }

        public int getIndexOfItem(SchedulerItem one)
        {
            if (!HasItem(one))
            {
                return -1;
            }
            int hash = one.GetHashCode();
            for (int i = 0; i < Items.Count; i++)
            {
                var each = Items[i];
                if (each.GetHashCode() == hash)
                {
                    return i;
                }
            }
            return -1;
        }

        /**
         * from + by must by in range (0, items.Length)
         * howMuch - from must not be nagative
         * abs(by) less than items.length
         */
        private void moveRangeByOffset(int from, int howMuch, int by)
        {
            var range = Items.GetRange(from, howMuch);

            Items.RemoveRange(from, howMuch);
            Items.InsertRange(from + by, range);
        }


        /*
         * moveItems MUSTN'T be null,
         * moveItems must have distinct elements
         */
        public void moveDown(SchedulerItem[] moveItems)
        {
            var indexes = getIndexesForItems(moveItems);
            sortDescending(indexes);

            // find ranges without holes and move them down
            var rangeBegining = 0;

            for (var range=1;range <= indexes.Length;range++) {
                if (range == indexes.Length || indexes[range] + 1 != indexes[range - 1])
                {
                    // range is broken, so move it and set another one
                    var highestIndex = indexes[rangeBegining];
                    // There is place for this range to be moved
                    if (highestIndex + 1 < Items.Count)
                    {
                        moveRangeByOffset(indexes[range - 1], range - rangeBegining, 1);
                    }
                    rangeBegining = range;
                }  
            }
            TriggerOnChange();
        }

        /*
         * moveItems MUSTN'T be null,
         * moveItems must have distinct elements
         */
        public void moveUp(SchedulerItem[] moveItems)
        {
            var indexes = getIndexesForItems(moveItems);
            sortAscending(indexes);

            // find ranges without holes and move them up
            var rangeBegining = 0;

            for (var range = 1; range <= indexes.Length; range++)
            {
                if (range == indexes.Length || indexes[range] != indexes[range - 1] + 1)
                {
                    // range is broken, so move it and set another one
                    var lowestIndex = indexes[rangeBegining];
                    // There is place for this range to be moved
                    if (lowestIndex > 0)
                    {
                        moveRangeByOffset(lowestIndex, range - rangeBegining, -1);
                    }
                    rangeBegining = range;
                }
            }
            TriggerOnChange();
        }

        public void moveDown(SchedulerItem schedulerItem)
        {
            moveDown(new SchedulerItem[] { schedulerItem });
        }

        public void moveUp(SchedulerItem schedulerItem)
        {
            moveUp(new SchedulerItem[] { schedulerItem });
        }

        private static String ClipboardKey = "SchedulerCollection";

        private String PutItemsToString(SchedulerItem[] items, bool removeFromCollection)
        {
            List<SchedulerItem> itemsToCut = new List<SchedulerItem>();
            foreach (var each in items)
            {
                if (items.Contains(each))
                {
                    itemsToCut.Add(each);
                    if (removeFromCollection) {
                        RemoveItem(each);
                    }
                }
            }
            // Prepare list of elements to cut
            SchedulerItem[] toClipboard = itemsToCut.ToArray();

            // Serialize to XML
            StringWriter writer = new StringWriter();
            var serializer = new XmlSerializer(typeof(SchedulerItem[]));
            serializer.Serialize(writer, toClipboard);

            return writer.ToString();
        }
        
        public void CutItems(SchedulerItem[] items)
        {
            SchedulerItem[] itemsCopy = new SchedulerItem[items.Length];
            Array.Copy(items, itemsCopy, items.Length);
            SortItems(itemsCopy);

            String stringFromItems = PutItemsToString(itemsCopy, true);

            // Put to clipboard
            Clipboard.SetData(ClipboardKey, stringFromItems);
            TriggerOnChange();
        }

        private SchedulerItem[] GetItemsFromString(String content)
        {
            String xmlToDeserialize = content;
            if (xmlToDeserialize == null)
            {
                return null;
            }

            var serializer = new XmlSerializer(typeof(SchedulerItem[]));
            StringReader reader = new StringReader(xmlToDeserialize);
            try
            {
                SchedulerItem[] items = (SchedulerItem[])serializer.Deserialize(reader);
                return items;
            }
            catch (InvalidOperationException e)
            {
                // This is visible when tests are performed in false case scenario
                Console.WriteLine("Exception during clipboard data deserilization");
                var innerException = e.InnerException;
                Console.WriteLine(innerException.Message);
                Console.Write(innerException.StackTrace);
                return null;
            }
        }

        public bool PasteItems()
        {
            var fromClipboard = Clipboard.GetDataObject();
            if (fromClipboard == null)
            {
                return false;
            }
            
            if (fromClipboard.GetFormats().Contains(ClipboardKey))
            {
                SchedulerItem[] items = GetItemsFromString((String)fromClipboard.GetData(ClipboardKey));
                if (items == null)
                {
                    // Clipboard was cleared after previous pasting
                    return true;
                }

                foreach (var each in items)
                {
                    PushItem(each);
                }
                TriggerOnChange();
                // clear clipboard
                Clipboard.SetData(ClipboardKey, null);
            }

            // If there is no data in clipboard paste is considered successful
            return true;
        }

        /*
         * Paste data from clipboard BEFORE pasteBefore
         */
        
        public bool PasteItems(SchedulerItem pasteBefore)
        {
            var index = Items.IndexOf(pasteBefore);
            if (index == -1)
            {
                return false;
            }

            var fromClipboard = Clipboard.GetDataObject();
            if (fromClipboard == null)
            {
                return false;
            }

            if (fromClipboard.GetFormats().Contains(ClipboardKey))
            {
                SchedulerItem[] items = GetItemsFromString((String)fromClipboard.GetData(ClipboardKey));
                if (items == null)
                {
                    // Clipboard was cleared after previous pasting
                    return true;
                }

                Array.Reverse(items);
                
                foreach (var each in items)
                {
                    InsertItem(each, index);
                }
                TriggerOnChange();
                // clear clipboard
                Clipboard.SetData(ClipboardKey, null);
            }

            // If there is no data in clipboard paste is considered successful
            return true;
        }

        public void CopyItems(SchedulerItem[] items)
        {
            SchedulerItem[] itemsCopy = new SchedulerItem[items.Length];
            Array.Copy(items, itemsCopy, items.Length);
            SortItems(itemsCopy);

            String stringFromItems = PutItemsToString(itemsCopy, false);

            // Put to clipboard
            Clipboard.SetData(ClipboardKey, stringFromItems);
        }
    }
}
