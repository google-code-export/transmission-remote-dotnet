namespace TransmissionRemoteDotnet
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTorrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTorrentFromUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.mainVerticalSplitContainer = new System.Windows.Forms.SplitContainer();
            this.stateListBox = new System.Windows.Forms.ListBox();
            this.torrentAndFileListViewSplitContainer = new System.Windows.Forms.SplitContainer();
            this.torrentListView = new TransmissionRemoteDotnet.ListViewNF();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
            this.torrentTabControl = new System.Windows.Forms.TabControl();
            this.generalTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.percentageLabel = new System.Windows.Forms.Label();
            this.trackersTabPage = new System.Windows.Forms.TabPage();
            this.filesTabPage = new System.Windows.Forms.TabPage();
            this.filesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.connectButton = new System.Windows.Forms.ToolStripButton();
            this.disconnectButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.addTorrentButton = new System.Windows.Forms.ToolStripButton();
            this.addWebTorrentButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.removeTorrentButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.startTorrentButton = new System.Windows.Forms.ToolStripButton();
            this.pauseTorrentButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.localConfigureButton = new System.Windows.Forms.ToolStripButton();
            this.remoteConfigureButton = new System.Windows.Forms.ToolStripButton();
            this.refreshWorker = new System.ComponentModel.BackgroundWorker();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.filesTimer = new System.Windows.Forms.Timer(this.components);
            this.filesWorker = new System.ComponentModel.BackgroundWorker();
            this.menuStrip.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.mainVerticalSplitContainer.Panel1.SuspendLayout();
            this.mainVerticalSplitContainer.Panel2.SuspendLayout();
            this.mainVerticalSplitContainer.SuspendLayout();
            this.torrentAndFileListViewSplitContainer.Panel1.SuspendLayout();
            this.torrentAndFileListViewSplitContainer.Panel2.SuspendLayout();
            this.torrentAndFileListViewSplitContainer.SuspendLayout();
            this.torrentTabControl.SuspendLayout();
            this.generalTabPage.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.filesTabPage.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(793, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTorrentToolStripMenuItem,
            this.addTorrentFromUrlToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addTorrentToolStripMenuItem
            // 
            this.addTorrentToolStripMenuItem.Name = "addTorrentToolStripMenuItem";
            this.addTorrentToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.addTorrentToolStripMenuItem.Text = "Add Torrent";
            this.addTorrentToolStripMenuItem.Click += new System.EventHandler(this.addTorrentButton_Click);
            // 
            // addTorrentFromUrlToolStripMenuItem
            // 
            this.addTorrentFromUrlToolStripMenuItem.Name = "addTorrentFromUrlToolStripMenuItem";
            this.addTorrentFromUrlToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.addTorrentFromUrlToolStripMenuItem.Text = "Add Torrent From URL";
            this.addTorrentFromUrlToolStripMenuItem.Click += new System.EventHandler(this.addWebTorrentButton_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(190, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localSettingsToolStripMenuItem,
            this.remoteSettingsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // localSettingsToolStripMenuItem
            // 
            this.localSettingsToolStripMenuItem.Name = "localSettingsToolStripMenuItem";
            this.localSettingsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.localSettingsToolStripMenuItem.Text = "Local Settings";
            this.localSettingsToolStripMenuItem.Click += new System.EventHandler(this.localConfigureButton_Click);
            // 
            // remoteSettingsToolStripMenuItem
            // 
            this.remoteSettingsToolStripMenuItem.Name = "remoteSettingsToolStripMenuItem";
            this.remoteSettingsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.remoteSettingsToolStripMenuItem.Text = "Remote Settings";
            this.remoteSettingsToolStripMenuItem.Visible = false;
            this.remoteSettingsToolStripMenuItem.Click += new System.EventHandler(this.remoteConfigureButton_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.aboutToolStripMenuItem.Text = "About Transmission Remote";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.mainVerticalSplitContainer);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.statusStrip);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(793, 429);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(793, 468);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip);
            // 
            // mainVerticalSplitContainer
            // 
            this.mainVerticalSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainVerticalSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.mainVerticalSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainVerticalSplitContainer.Name = "mainVerticalSplitContainer";
            // 
            // mainVerticalSplitContainer.Panel1
            // 
            this.mainVerticalSplitContainer.Panel1.Controls.Add(this.stateListBox);
            this.mainVerticalSplitContainer.Panel1Collapsed = true;
            // 
            // mainVerticalSplitContainer.Panel2
            // 
            this.mainVerticalSplitContainer.Panel2.Controls.Add(this.torrentAndFileListViewSplitContainer);
            this.mainVerticalSplitContainer.Size = new System.Drawing.Size(793, 407);
            this.mainVerticalSplitContainer.SplitterDistance = 112;
            this.mainVerticalSplitContainer.TabIndex = 1;
            // 
            // stateListBox
            // 
            this.stateListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stateListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stateListBox.FormattingEnabled = true;
            this.stateListBox.ItemHeight = 18;
            this.stateListBox.Items.AddRange(new object[] {
            "All",
            "Downloading",
            "Paused",
            "Complete",
            "Seeding"});
            this.stateListBox.Location = new System.Drawing.Point(0, 0);
            this.stateListBox.Name = "stateListBox";
            this.stateListBox.Size = new System.Drawing.Size(112, 94);
            this.stateListBox.TabIndex = 0;
            this.stateListBox.SelectedIndexChanged += new System.EventHandler(this.stateListBox_SelectedIndexChanged);
            // 
            // torrentAndFileListViewSplitContainer
            // 
            this.torrentAndFileListViewSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.torrentAndFileListViewSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.torrentAndFileListViewSplitContainer.Name = "torrentAndFileListViewSplitContainer";
            this.torrentAndFileListViewSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // torrentAndFileListViewSplitContainer.Panel1
            // 
            this.torrentAndFileListViewSplitContainer.Panel1.Controls.Add(this.torrentListView);
            // 
            // torrentAndFileListViewSplitContainer.Panel2
            // 
            this.torrentAndFileListViewSplitContainer.Panel2.Controls.Add(this.torrentTabControl);
            this.torrentAndFileListViewSplitContainer.Panel2Collapsed = true;
            this.torrentAndFileListViewSplitContainer.Size = new System.Drawing.Size(793, 407);
            this.torrentAndFileListViewSplitContainer.SplitterDistance = 193;
            this.torrentAndFileListViewSplitContainer.TabIndex = 0;
            // 
            // torrentListView
            // 
            this.torrentListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19});
            this.torrentListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.torrentListView.FullRowSelect = true;
            this.torrentListView.Location = new System.Drawing.Point(0, 0);
            this.torrentListView.Name = "torrentListView";
            this.torrentListView.Size = new System.Drawing.Size(793, 407);
            this.torrentListView.TabIndex = 0;
            this.torrentListView.UseCompatibleStateImageBehavior = false;
            this.torrentListView.View = System.Windows.Forms.View.Details;
            this.torrentListView.SelectedIndexChanged += new System.EventHandler(this.torrentListView_SelectedIndexChanged);
            this.torrentListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.torrentListView_ColumnClick);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Name";
            this.columnHeader6.Width = 200;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Size";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Done";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Status";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Seeds";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Peers";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Down Speed";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Up Speed";
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "ETA";
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Uploaded";
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Ratio";
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Label";
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Added On";
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Completed On";
            // 
            // torrentTabControl
            // 
            this.torrentTabControl.Controls.Add(this.generalTabPage);
            this.torrentTabControl.Controls.Add(this.trackersTabPage);
            this.torrentTabControl.Controls.Add(this.filesTabPage);
            this.torrentTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.torrentTabControl.Enabled = false;
            this.torrentTabControl.Location = new System.Drawing.Point(0, 0);
            this.torrentTabControl.Name = "torrentTabControl";
            this.torrentTabControl.SelectedIndex = 0;
            this.torrentTabControl.Size = new System.Drawing.Size(150, 46);
            this.torrentTabControl.TabIndex = 0;
            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.splitContainer3);
            this.generalTabPage.Location = new System.Drawing.Point(4, 22);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalTabPage.Size = new System.Drawing.Size(142, 20);
            this.generalTabPage.TabIndex = 0;
            this.generalTabPage.Text = "General";
            this.generalTabPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.AutoScroll = true;
            this.splitContainer3.Size = new System.Drawing.Size(136, 14);
            this.splitContainer3.SplitterDistance = 32;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer4.Size = new System.Drawing.Size(663, 32);
            this.splitContainer4.SplitterDistance = 79;
            this.splitContainer4.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Downloaded: ";
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.progressBar1);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.percentageLabel);
            this.splitContainer5.Size = new System.Drawing.Size(580, 32);
            this.splitContainer5.SplitterDistance = 522;
            this.splitContainer5.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(522, 32);
            this.progressBar1.TabIndex = 0;
            // 
            // percentageLabel
            // 
            this.percentageLabel.AutoSize = true;
            this.percentageLabel.Location = new System.Drawing.Point(6, 10);
            this.percentageLabel.Name = "percentageLabel";
            this.percentageLabel.Size = new System.Drawing.Size(45, 13);
            this.percentageLabel.TabIndex = 0;
            this.percentageLabel.Text = "__.__ %";
            // 
            // trackersTabPage
            // 
            this.trackersTabPage.Location = new System.Drawing.Point(4, 22);
            this.trackersTabPage.Name = "trackersTabPage";
            this.trackersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.trackersTabPage.Size = new System.Drawing.Size(142, 20);
            this.trackersTabPage.TabIndex = 1;
            this.trackersTabPage.Text = "Trackers";
            this.trackersTabPage.UseVisualStyleBackColor = true;
            // 
            // filesTabPage
            // 
            this.filesTabPage.Controls.Add(this.filesListView);
            this.filesTabPage.Location = new System.Drawing.Point(4, 22);
            this.filesTabPage.Name = "filesTabPage";
            this.filesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.filesTabPage.Size = new System.Drawing.Size(142, 20);
            this.filesTabPage.TabIndex = 2;
            this.filesTabPage.Text = "Files";
            this.filesTabPage.UseVisualStyleBackColor = true;
            // 
            // filesListView
            // 
            this.filesListView.CheckBoxes = true;
            this.filesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.filesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesListView.Enabled = false;
            this.filesListView.Location = new System.Drawing.Point(3, 3);
            this.filesListView.Name = "filesListView";
            this.filesListView.Size = new System.Drawing.Size(136, 14);
            this.filesListView.TabIndex = 0;
            this.filesListView.UseCompatibleStateImageBehavior = false;
            this.filesListView.View = System.Windows.Forms.View.Details;
            this.filesListView.SelectedIndexChanged += new System.EventHandler(this.filesListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Path";
            this.columnHeader1.Width = 375;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Done";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "%";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Priority";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 407);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(793, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectButton,
            this.disconnectButton,
            this.toolStripSeparator4,
            this.addTorrentButton,
            this.addWebTorrentButton,
            this.toolStripSeparator1,
            this.removeTorrentButton,
            this.toolStripSeparator2,
            this.startTorrentButton,
            this.pauseTorrentButton,
            this.toolStripSeparator3,
            this.localConfigureButton,
            this.remoteConfigureButton});
            this.toolStrip.Location = new System.Drawing.Point(3, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(81, 39);
            this.toolStrip.TabIndex = 0;
            // 
            // connectButton
            // 
            this.connectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.connectButton.Image = global::TransmissionRemoteDotnet.Properties.Resources.connect_creating;
            this.connectButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.connectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(36, 36);
            this.connectButton.Text = "Connect";
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.disconnectButton.Image = global::TransmissionRemoteDotnet.Properties.Resources.connect_no;
            this.disconnectButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.disconnectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(36, 36);
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.Visible = false;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            this.toolStripSeparator4.Visible = false;
            // 
            // addTorrentButton
            // 
            this.addTorrentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addTorrentButton.Image = global::TransmissionRemoteDotnet.Properties.Resources.edit_add;
            this.addTorrentButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addTorrentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addTorrentButton.Name = "addTorrentButton";
            this.addTorrentButton.Size = new System.Drawing.Size(36, 36);
            this.addTorrentButton.Text = "Add Torrent";
            this.addTorrentButton.Visible = false;
            this.addTorrentButton.Click += new System.EventHandler(this.addTorrentButton_Click);
            // 
            // addWebTorrentButton
            // 
            this.addWebTorrentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addWebTorrentButton.Image = global::TransmissionRemoteDotnet.Properties.Resources.net_add;
            this.addWebTorrentButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addWebTorrentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addWebTorrentButton.Name = "addWebTorrentButton";
            this.addWebTorrentButton.Size = new System.Drawing.Size(36, 36);
            this.addWebTorrentButton.Text = "Add Torrent from URL";
            this.addWebTorrentButton.Visible = false;
            this.addWebTorrentButton.Click += new System.EventHandler(this.addWebTorrentButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            this.toolStripSeparator1.Visible = false;
            // 
            // removeTorrentButton
            // 
            this.removeTorrentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeTorrentButton.Image = global::TransmissionRemoteDotnet.Properties.Resources.button_cancel1;
            this.removeTorrentButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.removeTorrentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeTorrentButton.Name = "removeTorrentButton";
            this.removeTorrentButton.Size = new System.Drawing.Size(36, 36);
            this.removeTorrentButton.Text = "Remove torrent(s)";
            this.removeTorrentButton.Visible = false;
            this.removeTorrentButton.Click += new System.EventHandler(this.removeTorrentButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            this.toolStripSeparator2.Visible = false;
            // 
            // startTorrentButton
            // 
            this.startTorrentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startTorrentButton.Image = global::TransmissionRemoteDotnet.Properties.Resources.player_play1;
            this.startTorrentButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.startTorrentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startTorrentButton.Name = "startTorrentButton";
            this.startTorrentButton.Size = new System.Drawing.Size(36, 36);
            this.startTorrentButton.Text = "Start torrent(s)";
            this.startTorrentButton.Visible = false;
            this.startTorrentButton.Click += new System.EventHandler(this.startTorrentButton_Click);
            // 
            // pauseTorrentButton
            // 
            this.pauseTorrentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pauseTorrentButton.Image = global::TransmissionRemoteDotnet.Properties.Resources.player_pause;
            this.pauseTorrentButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.pauseTorrentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pauseTorrentButton.Name = "pauseTorrentButton";
            this.pauseTorrentButton.Size = new System.Drawing.Size(36, 36);
            this.pauseTorrentButton.Text = "Pause torrent(s)";
            this.pauseTorrentButton.Visible = false;
            this.pauseTorrentButton.Click += new System.EventHandler(this.pauseTorrentButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // localConfigureButton
            // 
            this.localConfigureButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.localConfigureButton.Image = global::TransmissionRemoteDotnet.Properties.Resources.configure;
            this.localConfigureButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.localConfigureButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.localConfigureButton.Name = "localConfigureButton";
            this.localConfigureButton.Size = new System.Drawing.Size(36, 36);
            this.localConfigureButton.Text = "Local Settings";
            this.localConfigureButton.Click += new System.EventHandler(this.localConfigureButton_Click);
            // 
            // remoteConfigureButton
            // 
            this.remoteConfigureButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.remoteConfigureButton.Image = global::TransmissionRemoteDotnet.Properties.Resources.netconfigure;
            this.remoteConfigureButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.remoteConfigureButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.remoteConfigureButton.Name = "remoteConfigureButton";
            this.remoteConfigureButton.Size = new System.Drawing.Size(36, 36);
            this.remoteConfigureButton.Text = "Remote Settings";
            this.remoteConfigureButton.Visible = false;
            this.remoteConfigureButton.Click += new System.EventHandler(this.remoteConfigureButton_Click);
            // 
            // refreshWorker
            // 
            this.refreshWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.refreshWorker_DoWork);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // filesTimer
            // 
            this.filesTimer.Tick += new System.EventHandler(this.filesTimer_Tick);
            // 
            // filesWorker
            // 
            this.filesWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.filesWorker_DoWork);
            this.filesWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.filesWorker_RunWorkerCompleted);
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 492);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.Text = "Transmission Remote";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.mainVerticalSplitContainer.Panel1.ResumeLayout(false);
            this.mainVerticalSplitContainer.Panel2.ResumeLayout(false);
            this.mainVerticalSplitContainer.ResumeLayout(false);
            this.torrentAndFileListViewSplitContainer.Panel1.ResumeLayout(false);
            this.torrentAndFileListViewSplitContainer.Panel2.ResumeLayout(false);
            this.torrentAndFileListViewSplitContainer.ResumeLayout(false);
            this.torrentTabControl.ResumeLayout(false);
            this.generalTabPage.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.Panel2.PerformLayout();
            this.splitContainer5.ResumeLayout(false);
            this.filesTabPage.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.SplitContainer mainVerticalSplitContainer;
        private System.Windows.Forms.SplitContainer torrentAndFileListViewSplitContainer;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripButton addTorrentButton;
        private System.Windows.Forms.TabPage trackersTabPage;
        private System.Windows.Forms.TabPage filesTabPage;
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
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ToolStripButton disconnectButton;
        private System.Windows.Forms.ToolStripButton addWebTorrentButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton removeTorrentButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton startTorrentButton;
        private System.Windows.Forms.ToolStripButton pauseTorrentButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton localConfigureButton;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton remoteConfigureButton;
        private System.Windows.Forms.ToolStripMenuItem addTorrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTorrentFromUrlToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        public System.Windows.Forms.ToolStripButton connectButton;
        public System.Windows.Forms.Timer refreshTimer;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        public System.ComponentModel.BackgroundWorker refreshWorker;
        public System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public ListViewNF torrentListView;
        private System.Windows.Forms.ToolStripMenuItem localSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteSettingsToolStripMenuItem;
        public System.Windows.Forms.ListBox stateListBox;
        private System.ComponentModel.BackgroundWorker filesWorker;
        public System.Windows.Forms.ListView filesListView;
        public System.Windows.Forms.Timer filesTimer;
        private System.Windows.Forms.TabPage generalTabPage;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label percentageLabel;
        public System.Windows.Forms.TabControl torrentTabControl;
    }
}