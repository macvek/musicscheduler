namespace MusicScheduler
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrackList = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.AddFolderItems = new System.Windows.Forms.Button();
            this.OpenProject = new System.Windows.Forms.Button();
            this.AddItems = new System.Windows.Forms.Button();
            this.ExportProject = new System.Windows.Forms.Button();
            this.CutSelection = new System.Windows.Forms.Button();
            this.DeleteSelection = new System.Windows.Forms.Button();
            this.PasteSelection = new System.Windows.Forms.Button();
            this.CopySelection = new System.Windows.Forms.Button();
            this.SaveProjectAs = new System.Windows.Forms.Button();
            this.SaveProject = new System.Windows.Forms.Button();
            this.NewProject = new System.Windows.Forms.Button();
            this.MoveUp = new System.Windows.Forms.Button();
            this.MoveDown = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(634, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.newProjectToolStripMenuItem.Text = "New Project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.NewProject_Click);
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.openProjectToolStripMenuItem.Text = "Open Project";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.OpenProject_Click);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.saveProjectToolStripMenuItem.Text = "Save Project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.SaveProject_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem2.Text = "Save Project As";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.SaveProjectAs_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.ExportProject_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.pasteToolStripMenuItem1,
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // cutToolStripMenuItem1
            // 
            this.cutToolStripMenuItem1.Name = "cutToolStripMenuItem1";
            this.cutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.cutToolStripMenuItem1.Text = "Cut";
            this.cutToolStripMenuItem1.Click += new System.EventHandler(this.CutSelection_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem1.Text = "Copy";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.CopySelection_Click);
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.pasteToolStripMenuItem1.Text = "Paste";
            this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.PasteSelection_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.AddItems_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteSelection_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // TrackList
            // 
            this.TrackList.AllowDrop = true;
            this.TrackList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrackList.ContextMenuStrip = this.contextMenuStrip1;
            this.TrackList.FormattingEnabled = true;
            this.TrackList.Location = new System.Drawing.Point(0, 54);
            this.TrackList.Name = "TrackList";
            this.TrackList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.TrackList.Size = new System.Drawing.Size(597, 381);
            this.TrackList.TabIndex = 1;
            this.TrackList.DragDrop += new System.Windows.Forms.DragEventHandler(this.TrackList_DragDrop);
            this.TrackList.DragEnter += new System.Windows.Forms.DragEventHandler(this.TrackList_DragEnter);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.addToolStripMenuItem1,
            this.deleteToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 114);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutSelection_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopySelection_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteSelection_Click);
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.addToolStripMenuItem1.Text = "Add";
            this.addToolStripMenuItem1.Click += new System.EventHandler(this.AddItems_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.DeleteSelection_Click);
            // 
            // AddFolderItems
            // 
            this.AddFolderItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddFolderItems.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AddFolderItems.Image = global::MusicScheduler.Properties.Resources.document_add_many;
            this.AddFolderItems.Location = new System.Drawing.Point(603, 84);
            this.AddFolderItems.Name = "AddFolderItems";
            this.AddFolderItems.Size = new System.Drawing.Size(24, 24);
            this.AddFolderItems.TabIndex = 14;
            this.AddFolderItems.UseVisualStyleBackColor = true;
            this.AddFolderItems.Click += new System.EventHandler(this.AddFolderItems_Click);
            // 
            // OpenProject
            // 
            this.OpenProject.Image = global::MusicScheduler.Properties.Resources.document_open_2;
            this.OpenProject.Location = new System.Drawing.Point(37, 27);
            this.OpenProject.Name = "OpenProject";
            this.OpenProject.Size = new System.Drawing.Size(24, 24);
            this.OpenProject.TabIndex = 13;
            this.OpenProject.UseVisualStyleBackColor = true;
            this.OpenProject.Click += new System.EventHandler(this.OpenProject_Click);
            // 
            // AddItems
            // 
            this.AddItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddItems.Image = global::MusicScheduler.Properties.Resources.list_add_5;
            this.AddItems.Location = new System.Drawing.Point(603, 54);
            this.AddItems.Name = "AddItems";
            this.AddItems.Size = new System.Drawing.Size(24, 24);
            this.AddItems.TabIndex = 12;
            this.AddItems.UseVisualStyleBackColor = true;
            this.AddItems.Click += new System.EventHandler(this.AddItems_Click);
            // 
            // ExportProject
            // 
            this.ExportProject.Image = global::MusicScheduler.Properties.Resources.fork;
            this.ExportProject.Location = new System.Drawing.Point(127, 27);
            this.ExportProject.Name = "ExportProject";
            this.ExportProject.Size = new System.Drawing.Size(24, 24);
            this.ExportProject.TabIndex = 11;
            this.ExportProject.UseVisualStyleBackColor = true;
            this.ExportProject.Click += new System.EventHandler(this.ExportProject_Click);
            // 
            // CutSelection
            // 
            this.CutSelection.Image = global::MusicScheduler.Properties.Resources.edit_cut_4;
            this.CutSelection.Location = new System.Drawing.Point(181, 27);
            this.CutSelection.Name = "CutSelection";
            this.CutSelection.Size = new System.Drawing.Size(24, 24);
            this.CutSelection.TabIndex = 10;
            this.CutSelection.UseVisualStyleBackColor = true;
            this.CutSelection.Click += new System.EventHandler(this.CutSelection_Click);
            // 
            // DeleteSelection
            // 
            this.DeleteSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteSelection.Image = global::MusicScheduler.Properties.Resources.edit_delete_2;
            this.DeleteSelection.Location = new System.Drawing.Point(603, 346);
            this.DeleteSelection.Name = "DeleteSelection";
            this.DeleteSelection.Size = new System.Drawing.Size(24, 24);
            this.DeleteSelection.TabIndex = 9;
            this.DeleteSelection.UseVisualStyleBackColor = true;
            this.DeleteSelection.Click += new System.EventHandler(this.DeleteSelection_Click);
            // 
            // PasteSelection
            // 
            this.PasteSelection.Image = global::MusicScheduler.Properties.Resources.edit_paste_4;
            this.PasteSelection.Location = new System.Drawing.Point(241, 27);
            this.PasteSelection.Name = "PasteSelection";
            this.PasteSelection.Size = new System.Drawing.Size(24, 24);
            this.PasteSelection.TabIndex = 8;
            this.PasteSelection.UseVisualStyleBackColor = true;
            this.PasteSelection.Click += new System.EventHandler(this.PasteSelection_Click);
            // 
            // CopySelection
            // 
            this.CopySelection.Image = global::MusicScheduler.Properties.Resources.edit_copy_9;
            this.CopySelection.Location = new System.Drawing.Point(211, 27);
            this.CopySelection.Name = "CopySelection";
            this.CopySelection.Size = new System.Drawing.Size(24, 24);
            this.CopySelection.TabIndex = 7;
            this.CopySelection.UseVisualStyleBackColor = true;
            this.CopySelection.Click += new System.EventHandler(this.CopySelection_Click);
            // 
            // SaveProjectAs
            // 
            this.SaveProjectAs.Image = global::MusicScheduler.Properties.Resources.document_save_all;
            this.SaveProjectAs.Location = new System.Drawing.Point(97, 27);
            this.SaveProjectAs.Name = "SaveProjectAs";
            this.SaveProjectAs.Size = new System.Drawing.Size(24, 24);
            this.SaveProjectAs.TabIndex = 6;
            this.SaveProjectAs.UseVisualStyleBackColor = true;
            this.SaveProjectAs.Click += new System.EventHandler(this.SaveProjectAs_Click);
            // 
            // SaveProject
            // 
            this.SaveProject.Image = global::MusicScheduler.Properties.Resources.document_save_5;
            this.SaveProject.Location = new System.Drawing.Point(67, 27);
            this.SaveProject.Name = "SaveProject";
            this.SaveProject.Size = new System.Drawing.Size(24, 24);
            this.SaveProject.TabIndex = 5;
            this.SaveProject.UseVisualStyleBackColor = true;
            this.SaveProject.Click += new System.EventHandler(this.SaveProject_Click);
            // 
            // NewProject
            // 
            this.NewProject.Image = global::MusicScheduler.Properties.Resources.mail_new;
            this.NewProject.Location = new System.Drawing.Point(7, 27);
            this.NewProject.Name = "NewProject";
            this.NewProject.Size = new System.Drawing.Size(24, 24);
            this.NewProject.TabIndex = 4;
            this.NewProject.UseVisualStyleBackColor = true;
            this.NewProject.Click += new System.EventHandler(this.NewProject_Click);
            // 
            // MoveUp
            // 
            this.MoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveUp.Image = global::MusicScheduler.Properties.Resources.arrow_up_3;
            this.MoveUp.Location = new System.Drawing.Point(603, 166);
            this.MoveUp.Name = "MoveUp";
            this.MoveUp.Size = new System.Drawing.Size(24, 24);
            this.MoveUp.TabIndex = 3;
            this.MoveUp.UseVisualStyleBackColor = true;
            this.MoveUp.Click += new System.EventHandler(this.MoveUp_Click);
            // 
            // MoveDown
            // 
            this.MoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveDown.Image = global::MusicScheduler.Properties.Resources.arrow_down_3;
            this.MoveDown.Location = new System.Drawing.Point(603, 196);
            this.MoveDown.Name = "MoveDown";
            this.MoveDown.Size = new System.Drawing.Size(24, 24);
            this.MoveDown.TabIndex = 2;
            this.MoveDown.UseVisualStyleBackColor = true;
            this.MoveDown.Click += new System.EventHandler(this.MoveDown_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(634, 442);
            this.Controls.Add(this.AddFolderItems);
            this.Controls.Add(this.OpenProject);
            this.Controls.Add(this.AddItems);
            this.Controls.Add(this.ExportProject);
            this.Controls.Add(this.CutSelection);
            this.Controls.Add(this.DeleteSelection);
            this.Controls.Add(this.PasteSelection);
            this.Controls.Add(this.CopySelection);
            this.Controls.Add(this.SaveProjectAs);
            this.Controls.Add(this.SaveProject);
            this.Controls.Add(this.NewProject);
            this.Controls.Add(this.MoveUp);
            this.Controls.Add(this.MoveDown);
            this.Controls.Add(this.TrackList);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(650, 480);
            this.Name = "MainForm";
            this.Text = "Music Scheduler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListBox TrackList;
        private System.Windows.Forms.Button MoveDown;
        private System.Windows.Forms.Button MoveUp;
        private System.Windows.Forms.Button NewProject;
        private System.Windows.Forms.Button SaveProject;
        private System.Windows.Forms.Button SaveProjectAs;
        private System.Windows.Forms.Button CopySelection;
        private System.Windows.Forms.Button PasteSelection;
        private System.Windows.Forms.Button DeleteSelection;
        private System.Windows.Forms.Button CutSelection;
        private System.Windows.Forms.Button ExportProject;
        private System.Windows.Forms.Button AddItems;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button OpenProject;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button AddFolderItems;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

