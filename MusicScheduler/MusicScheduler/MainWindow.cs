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

using MusicScheduler.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicScheduler
{
    public partial class MainForm : Form
    {

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.N))
            {
                NewProject_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.O))
            {
                OpenProject_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.S)) {
                SaveProject_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.C))
            {
                CopySelection_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.X))
            {
                CutSelection_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.V))
            {
                PasteSelection_Click(null, null);
                return true;
            }
            else if (keyData == Keys.Delete)
            {
                DeleteSelection_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.A))
            {
                // Select All
                List<int> everyIndex = new List<int>();
                int size = TrackList.Items.Count;
                for (int i = 0; i < size; i++)
                {
                    TrackList.SetSelected(i, true);
                }

                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private String InitialFormText;
        public MainForm()
        {
            InitializeComponent();
            InitialFormText = Text;
            project = new SchedulerProject(scheduler);
            exporter = new SchedulerExporter(scheduler);
        }

        private Scheduler scheduler = new Scheduler();
        private SchedulerProject project;
        private SchedulerExporter exporter;
        
        /*
         * Path to opened project
         */
        private String projectPath = null;

        private void RefreshList()
        {
            var items = scheduler.ScheduledItems;
            var tracks = TrackList.Items;
            tracks.Clear();
            tracks.AddRange(items);
        }

        private void ScrollListToLast()
        {
            var itemsCount = scheduler.ScheduledItems.Length;
            if (itemsCount > 0)
            {
                TrackList.TopIndex = itemsCount - 1;
            }
        }

        private void AddItems_Click(object sender, EventArgs e)
        {
            // TODO: dodatkowy przycisk na FolderBrowserDialog()!
            var picker = new OpenFileDialog();
            picker.Multiselect = true;
            
            var ret = picker.ShowDialog();
            if (ret == DialogResult.OK)
            {
                foreach (var file in picker.FileNames)
                {
                    scheduler.AddItem(file);
                }
            }
            
            RefreshList();
            ScrollListToLast();
        }

        private void DeleteSelection_Click(object sender, EventArgs e)
        {
            var selection = TrackList.SelectedItems;
            if (selection.Count == 0)
            {
                return;
            }

            var firstSelectedIndex = TrackList.SelectedIndices[0];

            /* List is always filled with SchedulerItems */
            foreach (var each in selection)
            {
                scheduler.RemoveItem((SchedulerItem)each);
            }
            
            RefreshList();
            TrackList.TopIndex = firstSelectedIndex-1;
        }

        private SchedulerItem[] getSelectedSchedulerItems()
        {
            var selection = TrackList.SelectedItems;
            var length = selection.Count;
            if (length == 0)
            {
                return null;
            }

            SchedulerItem[] selectedItems = new SchedulerItem[length];
            var index = 0;
            foreach (var each in selection)
            {
                selectedItems[index++] = (SchedulerItem)each;
            }

            return selectedItems;
        }

        private void MoveDown_Click(object sender, EventArgs e)
        {
            var selectedItems = getSelectedSchedulerItems();
            if (selectedItems == null)
            {
                return;
            }

            scheduler.moveDown(selectedItems);
            RefreshList();
            
            foreach (var each in selectedItems)
            {
                TrackList.SetSelected(each.Index, true);
            }
        }

        private void MoveUp_Click(object sender, EventArgs e)
        {
            var selectedItems = getSelectedSchedulerItems();
            if (selectedItems == null)
            {
                return;
            }

            scheduler.moveUp(selectedItems);
            RefreshList();

            foreach (var each in selectedItems)
            {
                TrackList.SetSelected(each.Index, true);
            }
        }


        private void PasteSelection_Click(object sender, EventArgs e)
        {
            var selected = TrackList.SelectedItems;
            bool success;
            if (selected.Count == 0)
            {
                success = scheduler.PasteItems();
            }
            else
            {
                SchedulerItem firstOne = (SchedulerItem)selected[0];
                success = scheduler.PasteItems(firstOne);
            }

            if (!success)
            {
                MessageBox.Show("Error occured while pasting items.");
            }

            RefreshList();
        }

        private void CutSelection_Click(object sender, EventArgs e)
        {
            var selected = TrackList.SelectedItems;
            if (selected.Count == 0)
            {
                return;
            }

            SchedulerItem[] selectedItems = new SchedulerItem[selected.Count];
            int ptr = 0;
            foreach (var each in selected)
            {
                selectedItems[ptr++] = (SchedulerItem)each;
            }

            scheduler.CutItems(selectedItems);
            RefreshList();
        }

        private void CopySelection_Click(object sender, EventArgs e)
        {
            var selected = TrackList.SelectedItems;
            if (selected.Count == 0)
            {
                return;
            }

            SchedulerItem[] selectedItems = new SchedulerItem[selected.Count];
            int ptr = 0;
            foreach (var each in selected)
            {
                selectedItems[ptr++] = (SchedulerItem)each;
            }

            scheduler.CopyItems(selectedItems);
            RefreshList();
        }

        private void NewProject_Click(object sender, EventArgs e)
        {
            if (!confirmPendingChanges())
            {
                return;
            }

            project.NewProject();
            projectPath = null;
            RefreshList();
            Text = InitialFormText;
        }

        private bool confirmPendingChanges()
        {
            if (project.HasPendingChanges())
            {
                var result = MessageBox.Show("Are you sure you want to continue?", "There are unsaved changes !", MessageBoxButtons.YesNo);
                return result == DialogResult.Yes;
            }
            return true;
        }

        private void OpenProject_Click(object sender, EventArgs e)
        {
            if (!confirmPendingChanges())
            {
                return;
            }
            var dialog = new OpenFileDialog();
            dialog.Filter = "Music order project file (*.musicorder)|*.musicorder";
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (project.Load(dialog.FileName))
                {
                    projectPath = dialog.FileName;
                    UpdateWindowTitle(projectPath);
                    RefreshList();
                }
                else
                {
                    MessageBox.Show("Error while loading project file.");
                }
            }
        }

        private void SaveProject_Click(object sender, EventArgs e)
        {
            if (projectPath == null)
            {
                SaveProjectAs_Click(sender, e);
                return;
            }

            if (!project.Save(projectPath))
            {
                MessageBox.Show("Error while saving project file.");
            }
            else
            {
                RefreshList();
            }
        }

        private void SaveProjectAs_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Music order project file (*.musicorder)|*.musicorder";
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                projectPath = dialog.FileName;
                SaveProject_Click(sender, e);
                UpdateWindowTitle(projectPath);
            }
        }

        private void UpdateWindowTitle(String val)
        {
            Text = InitialFormText + " (" + val + ")";
        }

        private void ExportProject_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog pickFolder = new FolderBrowserDialog();
            pickFolder.Description = "Choose folder where to put renamed files.";
            pickFolder.ShowNewFolderButton = true;
            var result = pickFolder.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            var path = pickFolder.SelectedPath;
            if (!Directory.Exists(path))
            {
                return;
            }
            var worklist = exporter.prepareWorklist(path);
            List<ExporterJob> failedItems = new List<ExporterJob>();
            foreach (var job in worklist)
            {
                if (!job.execute())
                {
                    failedItems.Add(job);
                }
            }
            if (failedItems.Count == 0)
            {
                MessageBox.Show("Export succeed");
            }
            else
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine("Following files failed:");
                foreach (var failure in failedItems)
                {
                    builder.Append(failure.SourcePath);
                    builder.AppendLine();
                }

                MessageBox.Show(builder.ToString());
            }
        }

        private void AddDirectory(String path)
        {
            foreach (var filepath in Directory.EnumerateFiles(path))
            {
                scheduler.AddItem(filepath);
            }

            foreach (var dirpath in Directory.EnumerateDirectories(path))
            {
                AddDirectory(dirpath);
            }

            RefreshList();
        }

        private void AddFolderItems_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog pickFolder = new FolderBrowserDialog();
            pickFolder.Description = "Pick folder with files to add.";
            pickFolder.ShowNewFolderButton = false;
            var result = pickFolder.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            var path = pickFolder.SelectedPath;
            if (!Directory.Exists(path))
            {
                return;
            }

            AddDirectory(path);
        }

        private void TrackList_DragEnter(object sender, DragEventArgs e)
        {
            if ( (e.AllowedEffect & DragDropEffects.Link) != 0 && e.Data.GetDataPresent("FileDrop"))
            {
                e.Effect = DragDropEffects.Link;
            }
        }

        private void TrackList_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("FileDrop"))
            {
                String[] items = e.Data.GetData("FileDrop") as String[];
                if (items == null)
                {
                    return;
                }

                foreach (String each in items) {
                    if (Directory.Exists(each))
                    {
                        AddDirectory(each);
                    }
                    else if (File.Exists(each))
                    {
                        scheduler.AddItem(each);
                    }
                }
                RefreshList();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!confirmPendingChanges())
            {
                e.Cancel = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().Show();
        }
    }
}
