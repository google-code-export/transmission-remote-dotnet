namespace TransmissionClientNew
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.TorrentListView = new TransmissionClientNew.ListViewNF();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.RefreshWorker = new System.ComponentModel.BackgroundWorker();
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.FilesWorker = new System.ComponentModel.BackgroundWorker();
            this.FilesTimer = new System.Windows.Forms.Timer(this.components);
            this.SettingsDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.LocalSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoteSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConnectButton = new System.Windows.Forms.ToolStripButton();
            this.DisconnectButton = new System.Windows.Forms.ToolStripButton();
            this.UploadButton = new System.Windows.Forms.ToolStripButton();
            this.StartButton = new System.Windows.Forms.ToolStripSplitButton();
            this.startAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopButton = new System.Windows.Forms.ToolStripSplitButton();
            this.stopAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveButton = new System.Windows.Forms.ToolStripButton();
            this.DetailsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.TorrentListView);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.statusStrip1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(801, 279);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(801, 304);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // TorrentListView
            // 
            this.TorrentListView.AllowColumnReorder = true;
            this.TorrentListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14});
            this.TorrentListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TorrentListView.Enabled = false;
            this.TorrentListView.FullRowSelect = true;
            this.TorrentListView.Location = new System.Drawing.Point(0, 0);
            this.TorrentListView.Name = "TorrentListView";
            this.TorrentListView.ShowItemToolTips = true;
            this.TorrentListView.Size = new System.Drawing.Size(801, 257);
            this.TorrentListView.TabIndex = 1;
            this.TorrentListView.UseCompatibleStateImageBehavior = false;
            this.TorrentListView.View = System.Windows.Forms.View.Details;
            this.TorrentListView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.TorrentListView.DoubleClick += new System.EventHandler(this.DetailsButton_Click);
            this.TorrentListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Size";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Progress";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Down Speed";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Up Speed";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "ETA";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Downloaded";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Uploaded";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Ratio";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Seeders";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Leechers";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Tracker";
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Added";
            this.columnHeader14.Width = 120;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 257);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(801, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(102, 17);
            this.toolStripStatusLabel1.Text = "Ready to connect.";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsDropDownButton,
            this.ConnectButton,
            this.DisconnectButton,
            this.toolStripSeparator1,
            this.UploadButton,
            this.StartButton,
            this.StopButton,
            this.RemoveButton,
            this.DetailsButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(608, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // RefreshWorker
            // 
            this.RefreshWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RefreshWorker_DoWork);
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Interval = 3000;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "Transmission Remote Control";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // FilesWorker
            // 
            this.FilesWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FilesWorker_DoWork);
            this.FilesWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.FilesWorker_RunWorkerCompleted);
            // 
            // FilesTimer
            // 
            this.FilesTimer.Interval = 3000;
            this.FilesTimer.Tick += new System.EventHandler(this.FilesTimer_Tick);
            // 
            // SettingsDropDownButton
            // 
            this.SettingsDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LocalSettingsMenuItem,
            this.RemoteSettingsMenuItem,
            this.toolStripSeparator2,
            this.aboutToolStripMenuItem});
            this.SettingsDropDownButton.Image = global::TransmissionClientNew.Properties.Resources.settings;
            this.SettingsDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SettingsDropDownButton.Name = "SettingsDropDownButton";
            this.SettingsDropDownButton.Size = new System.Drawing.Size(78, 22);
            this.SettingsDropDownButton.Text = "Settings";
            // 
            // LocalSettingsMenuItem
            // 
            this.LocalSettingsMenuItem.Name = "LocalSettingsMenuItem";
            this.LocalSettingsMenuItem.Size = new System.Drawing.Size(152, 22);
            this.LocalSettingsMenuItem.Text = "Local";
            this.LocalSettingsMenuItem.Click += new System.EventHandler(this.LocalSettingsMenuItem_Click);
            // 
            // RemoteSettingsMenuItem
            // 
            this.RemoteSettingsMenuItem.Name = "RemoteSettingsMenuItem";
            this.RemoteSettingsMenuItem.Size = new System.Drawing.Size(152, 22);
            this.RemoteSettingsMenuItem.Text = "Remote";
            this.RemoteSettingsMenuItem.Visible = false;
            this.RemoteSettingsMenuItem.Click += new System.EventHandler(this.RemoteSettingsMenuItem_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Image = global::TransmissionClientNew.Properties.Resources.connect;
            this.ConnectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(72, 22);
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Image = global::TransmissionClientNew.Properties.Resources.disconnect;
            this.DisconnectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(86, 22);
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.Visible = false;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // UploadButton
            // 
            this.UploadButton.Image = global::TransmissionClientNew.Properties.Resources.add;
            this.UploadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(65, 22);
            this.UploadButton.Text = "Upload";
            this.UploadButton.Visible = false;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startAllToolStripMenuItem});
            this.StartButton.Enabled = false;
            this.StartButton.Image = global::TransmissionClientNew.Properties.Resources.player_play;
            this.StartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(63, 22);
            this.StartButton.Text = "Start";
            this.StartButton.Visible = false;
            this.StartButton.ButtonClick += new System.EventHandler(this.StartButton_ButtonClick);
            // 
            // startAllToolStripMenuItem
            // 
            this.startAllToolStripMenuItem.Image = global::TransmissionClientNew.Properties.Resources.player_play;
            this.startAllToolStripMenuItem.Name = "startAllToolStripMenuItem";
            this.startAllToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.startAllToolStripMenuItem.Text = "Start All";
            this.startAllToolStripMenuItem.Click += new System.EventHandler(this.startAllToolStripMenuItem_Click);
            // 
            // StopButton
            // 
            this.StopButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stopAllToolStripMenuItem});
            this.StopButton.Enabled = false;
            this.StopButton.Image = global::TransmissionClientNew.Properties.Resources.player_stop;
            this.StopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(63, 22);
            this.StopButton.Text = "Stop";
            this.StopButton.Visible = false;
            this.StopButton.ButtonClick += new System.EventHandler(this.StopButton_ButtonClick);
            // 
            // stopAllToolStripMenuItem
            // 
            this.stopAllToolStripMenuItem.Image = global::TransmissionClientNew.Properties.Resources.player_stop;
            this.stopAllToolStripMenuItem.Name = "stopAllToolStripMenuItem";
            this.stopAllToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.stopAllToolStripMenuItem.Text = "Stop All";
            this.stopAllToolStripMenuItem.Click += new System.EventHandler(this.stopAllToolStripMenuItem_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Enabled = false;
            this.RemoveButton.Image = global::TransmissionClientNew.Properties.Resources.button_cancel;
            this.RemoveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(70, 22);
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.Visible = false;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // DetailsButton
            // 
            this.DetailsButton.Enabled = false;
            this.DetailsButton.Image = global::TransmissionClientNew.Properties.Resources.details;
            this.DetailsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DetailsButton.Name = "DetailsButton";
            this.DetailsButton.Size = new System.Drawing.Size(62, 22);
            this.DetailsButton.Text = "Details";
            this.DetailsButton.Visible = false;
            this.DetailsButton.Click += new System.EventHandler(this.DetailsButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 304);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Transmission Remote";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ToolStripDropDownButton SettingsDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem LocalSettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoteSettingsMenuItem;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.ComponentModel.BackgroundWorker RefreshWorker;
        //public System.Windows.Forms.ListView TorrentListView;
        public TransmissionClientNew.ListViewNF TorrentListView;
        public System.Windows.Forms.Timer RefreshTimer;
        private System.Windows.Forms.ToolStripButton DisconnectButton;
        private System.Windows.Forms.ToolStripButton UploadButton;
        private System.Windows.Forms.ToolStripButton RemoveButton;
        private System.Windows.Forms.ToolStripButton DetailsButton;
        private System.Windows.Forms.ToolStripSplitButton StopButton;
        private System.Windows.Forms.ToolStripMenuItem stopAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton StartButton;
        private System.Windows.Forms.ToolStripMenuItem startAllToolStripMenuItem;
        public System.Windows.Forms.NotifyIcon NotifyIcon;
        public System.Windows.Forms.ToolStripButton ConnectButton;
        private System.ComponentModel.BackgroundWorker FilesWorker;
        public System.Windows.Forms.Timer FilesTimer;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

