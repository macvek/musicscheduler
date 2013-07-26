namespace MusicScheduler
{
    partial class LicenceDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenceDialog));
            this.LicenceContent = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LicenceContent
            // 
            this.LicenceContent.Location = new System.Drawing.Point(13, 13);
            this.LicenceContent.Name = "LicenceContent";
            this.LicenceContent.Size = new System.Drawing.Size(591, 319);
            this.LicenceContent.TabIndex = 0;
            this.LicenceContent.Text = resources.GetString("LicenceContent.Text");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(520, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LicenceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 370);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LicenceContent);
            this.Name = "LicenceDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "MusicScheduler Licence";
            this.Load += new System.EventHandler(this.LicenceDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox LicenceContent;
        private System.Windows.Forms.Button button1;
    }
}