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
            this.refreshElapsedTimer = new System.Windows.Forms.Timer(this.components);
            this.torrentAndTabsSplitContainer = new System.Windows.Forms.SplitContainer();
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
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
            this.torrentTabControl = new System.Windows.Forms.TabControl();
            this.generalTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.percentageLabel = new System.Windows.Forms.Label();
            this.torrentDetailGroupBox = new System.Windows.Forms.GroupBox();
            this.createdByLabel = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.createdAtLabel = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.labelForErrorLabel = new System.Windows.Forms.Label();
            this.commentLabel = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.ratioLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.leechersLabel = new System.Windows.Forms.Label();
            this.seedersLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.uploadLimitLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.uploadRateLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.uploadedLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.remainingLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.downloadLimitLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.downloadSpeedLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.downloadedLabel = new System.Windows.Forms.Label();
            this.startedAtLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timeElapsedLabel = new System.Windows.Forms.Label();
            this.trackersTabPage = new System.Windows.Forms.TabPage();
            this.trackersListView = new TransmissionRemoteDotnet.ListViewNF();
            this.columnHeader22 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader21 = new System.Windows.Forms.ColumnHeader();
            this.filesTabPage = new System.Windows.Forms.TabPage();
            this.filesListView = new TransmissionRemoteDotnet.ListViewNF();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.peersTabPage = new System.Windows.Forms.TabPage();
            this.peersListView = new TransmissionRemoteDotnet.ListViewNF();
            this.columnHeader27 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader28 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader29 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader30 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader31 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.menuStrip.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.mainVerticalSplitContainer.Panel1.SuspendLayout();
            this.mainVerticalSplitContainer.Panel2.SuspendLayout();
            this.mainVerticalSplitContainer.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.torrentAndTabsSplitContainer.Panel1.SuspendLayout();
            this.torrentAndTabsSplitContainer.Panel2.SuspendLayout();
            this.torrentAndTabsSplitContainer.SuspendLayout();
            this.torrentTabControl.SuspendLayout();
            this.generalTabPage.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.torrentDetailGroupBox.SuspendLayout();
            this.trackersTabPage.SuspendLayout();
            this.filesTabPage.SuspendLayout();
            this.peersTabPage.SuspendLayout();
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
            this.menuStrip.Size = new System.Drawing.Size(898, 24);
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
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(898, 494);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(898, 533);
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
            this.mainVerticalSplitContainer.Panel2.Controls.Add(this.torrentAndTabsSplitContainer);
            this.mainVerticalSplitContainer.Size = new System.Drawing.Size(898, 472);
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
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 472);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(898, 22);
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
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
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
            // refreshElapsedTimer
            // 
            this.refreshElapsedTimer.Interval = 1000;
            this.refreshElapsedTimer.Tick += new System.EventHandler(this.refreshElapsedTimer_Tick);
            // 
            // torrentAndTabsSplitContainer
            // 
            this.torrentAndTabsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.torrentAndTabsSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.torrentAndTabsSplitContainer.Name = "torrentAndTabsSplitContainer";
            this.torrentAndTabsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // torrentAndTabsSplitContainer.Panel1
            // 
            this.torrentAndTabsSplitContainer.Panel1.Controls.Add(this.torrentListView);
            // 
            // torrentAndTabsSplitContainer.Panel2
            // 
            this.torrentAndTabsSplitContainer.Panel2.Controls.Add(this.torrentTabControl);
            this.torrentAndTabsSplitContainer.Size = new System.Drawing.Size(898, 472);
            this.torrentAndTabsSplitContainer.SplitterDistance = 222;
            this.torrentAndTabsSplitContainer.TabIndex = 0;
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
            this.columnHeader18,
            this.columnHeader19});
            this.torrentListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.torrentListView.Enabled = false;
            this.torrentListView.FullRowSelect = true;
            this.torrentListView.Location = new System.Drawing.Point(0, 0);
            this.torrentListView.Name = "torrentListView";
            this.torrentListView.Size = new System.Drawing.Size(898, 222);
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
            this.torrentTabControl.Controls.Add(this.peersTabPage);
            this.torrentTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.torrentTabControl.Enabled = false;
            this.torrentTabControl.Location = new System.Drawing.Point(0, 0);
            this.torrentTabControl.Name = "torrentTabControl";
            this.torrentTabControl.SelectedIndex = 0;
            this.torrentTabControl.Size = new System.Drawing.Size(898, 246);
            this.torrentTabControl.TabIndex = 0;
            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.splitContainer3);
            this.generalTabPage.Location = new System.Drawing.Point(4, 22);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalTabPage.Size = new System.Drawing.Size(890, 220);
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
            this.splitContainer3.Panel2.Controls.Add(this.torrentDetailGroupBox);
            this.splitContainer3.Size = new System.Drawing.Size(884, 214);
            this.splitContainer3.SplitterDistance = 25;
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
            this.splitContainer4.Size = new System.Drawing.Size(884, 25);
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
            this.splitContainer5.Panel1.Controls.Add(this.progressBar);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.percentageLabel);
            this.splitContainer5.Size = new System.Drawing.Size(801, 25);
            this.splitContainer5.SplitterDistance = 738;
            this.splitContainer5.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(738, 25);
            this.progressBar.TabIndex = 0;
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
            // torrentDetailGroupBox
            // 
            this.torrentDetailGroupBox.Controls.Add(this.createdByLabel);
            this.torrentDetailGroupBox.Controls.Add(this.label17);
            this.torrentDetailGroupBox.Controls.Add(this.createdAtLabel);
            this.torrentDetailGroupBox.Controls.Add(this.label16);
            this.torrentDetailGroupBox.Controls.Add(this.errorLabel);
            this.torrentDetailGroupBox.Controls.Add(this.labelForErrorLabel);
            this.torrentDetailGroupBox.Controls.Add(this.commentLabel);
            this.torrentDetailGroupBox.Controls.Add(this.label15);
            this.torrentDetailGroupBox.Controls.Add(this.ratioLabel);
            this.torrentDetailGroupBox.Controls.Add(this.label14);
            this.torrentDetailGroupBox.Controls.Add(this.leechersLabel);
            this.torrentDetailGroupBox.Controls.Add(this.seedersLabel);
            this.torrentDetailGroupBox.Controls.Add(this.label13);
            this.torrentDetailGroupBox.Controls.Add(this.label10);
            this.torrentDetailGroupBox.Controls.Add(this.uploadLimitLabel);
            this.torrentDetailGroupBox.Controls.Add(this.label12);
            this.torrentDetailGroupBox.Controls.Add(this.uploadRateLabel);
            this.torrentDetailGroupBox.Controls.Add(this.label8);
            this.torrentDetailGroupBox.Controls.Add(this.uploadedLabel);
            this.torrentDetailGroupBox.Controls.Add(this.label5);
            this.torrentDetailGroupBox.Controls.Add(this.remainingLabel);
            this.torrentDetailGroupBox.Controls.Add(this.label4);
            this.torrentDetailGroupBox.Controls.Add(this.statusLabel);
            this.torrentDetailGroupBox.Controls.Add(this.label11);
            this.torrentDetailGroupBox.Controls.Add(this.downloadLimitLabel);
            this.torrentDetailGroupBox.Controls.Add(this.label9);
            this.torrentDetailGroupBox.Controls.Add(this.downloadSpeedLabel);
            this.torrentDetailGroupBox.Controls.Add(this.label7);
            this.torrentDetailGroupBox.Controls.Add(this.label6);
            this.torrentDetailGroupBox.Controls.Add(this.downloadedLabel);
            this.torrentDetailGroupBox.Controls.Add(this.startedAtLabel);
            this.torrentDetailGroupBox.Controls.Add(this.label3);
            this.torrentDetailGroupBox.Controls.Add(this.label2);
            this.torrentDetailGroupBox.Controls.Add(this.timeElapsedLabel);
            this.torrentDetailGroupBox.Location = new System.Drawing.Point(12, 8);
            this.torrentDetailGroupBox.Name = "torrentDetailGroupBox";
            this.torrentDetailGroupBox.Size = new System.Drawing.Size(755, 169);
            this.torrentDetailGroupBox.TabIndex = 2;
            this.torrentDetailGroupBox.TabStop = false;
            // 
            // createdByLabel
            // 
            this.createdByLabel.AutoSize = true;
            this.createdByLabel.Location = new System.Drawing.Point(588, 118);
            this.createdByLabel.Name = "createdByLabel";
            this.createdByLabel.Size = new System.Drawing.Size(41, 13);
            this.createdByLabel.TabIndex = 33;
            this.createdByLabel.Text = "label18";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(497, 118);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 13);
            this.label17.TabIndex = 32;
            this.label17.Text = "Created by: ";
            // 
            // createdAtLabel
            // 
            this.createdAtLabel.AutoSize = true;
            this.createdAtLabel.Location = new System.Drawing.Point(588, 94);
            this.createdAtLabel.Name = "createdAtLabel";
            this.createdAtLabel.Size = new System.Drawing.Size(41, 13);
            this.createdAtLabel.TabIndex = 31;
            this.createdAtLabel.Text = "label17";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(497, 94);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 13);
            this.label16.TabIndex = 30;
            this.label16.Text = "Created at: ";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(588, 143);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(41, 13);
            this.errorLabel.TabIndex = 29;
            this.errorLabel.Text = "label18";
            this.errorLabel.Visible = false;
            // 
            // labelForErrorLabel
            // 
            this.labelForErrorLabel.AutoSize = true;
            this.labelForErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.labelForErrorLabel.Location = new System.Drawing.Point(497, 143);
            this.labelForErrorLabel.Name = "labelForErrorLabel";
            this.labelForErrorLabel.Size = new System.Drawing.Size(35, 13);
            this.labelForErrorLabel.TabIndex = 28;
            this.labelForErrorLabel.Text = "Error: ";
            this.labelForErrorLabel.Visible = false;
            // 
            // commentLabel
            // 
            this.commentLabel.AutoSize = true;
            this.commentLabel.Location = new System.Drawing.Point(127, 143);
            this.commentLabel.Name = "commentLabel";
            this.commentLabel.Size = new System.Drawing.Size(41, 13);
            this.commentLabel.TabIndex = 27;
            this.commentLabel.Text = "label16";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 143);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Comment: ";
            // 
            // ratioLabel
            // 
            this.ratioLabel.AutoSize = true;
            this.ratioLabel.Location = new System.Drawing.Point(588, 71);
            this.ratioLabel.Name = "ratioLabel";
            this.ratioLabel.Size = new System.Drawing.Size(41, 13);
            this.ratioLabel.TabIndex = 25;
            this.ratioLabel.Text = "label15";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(497, 71);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Ratio: ";
            // 
            // leechersLabel
            // 
            this.leechersLabel.AutoSize = true;
            this.leechersLabel.Location = new System.Drawing.Point(588, 49);
            this.leechersLabel.Name = "leechersLabel";
            this.leechersLabel.Size = new System.Drawing.Size(41, 13);
            this.leechersLabel.TabIndex = 23;
            this.leechersLabel.Text = "label15";
            // 
            // seedersLabel
            // 
            this.seedersLabel.AutoSize = true;
            this.seedersLabel.Location = new System.Drawing.Point(588, 25);
            this.seedersLabel.Name = "seedersLabel";
            this.seedersLabel.Size = new System.Drawing.Size(41, 13);
            this.seedersLabel.TabIndex = 22;
            this.seedersLabel.Text = "label14";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(497, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Leechers: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(497, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Seeds: ";
            // 
            // uploadLimitLabel
            // 
            this.uploadLimitLabel.AutoSize = true;
            this.uploadLimitLabel.Location = new System.Drawing.Point(359, 94);
            this.uploadLimitLabel.Name = "uploadLimitLabel";
            this.uploadLimitLabel.Size = new System.Drawing.Size(41, 13);
            this.uploadLimitLabel.TabIndex = 19;
            this.uploadLimitLabel.Text = "label13";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(261, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Upload limit: ";
            // 
            // uploadRateLabel
            // 
            this.uploadRateLabel.AutoSize = true;
            this.uploadRateLabel.Location = new System.Drawing.Point(359, 71);
            this.uploadRateLabel.Name = "uploadRateLabel";
            this.uploadRateLabel.Size = new System.Drawing.Size(41, 13);
            this.uploadRateLabel.TabIndex = 17;
            this.uploadRateLabel.Text = "label10";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(261, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Upload rate: ";
            // 
            // uploadedLabel
            // 
            this.uploadedLabel.AutoSize = true;
            this.uploadedLabel.Location = new System.Drawing.Point(359, 49);
            this.uploadedLabel.Name = "uploadedLabel";
            this.uploadedLabel.Size = new System.Drawing.Size(35, 13);
            this.uploadedLabel.TabIndex = 15;
            this.uploadedLabel.Text = "label8";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Uploaded: ";
            // 
            // remainingLabel
            // 
            this.remainingLabel.AutoSize = true;
            this.remainingLabel.Location = new System.Drawing.Point(359, 25);
            this.remainingLabel.Name = "remainingLabel";
            this.remainingLabel.Size = new System.Drawing.Size(35, 13);
            this.remainingLabel.TabIndex = 13;
            this.remainingLabel.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Remaining: ";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(127, 119);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(41, 13);
            this.statusLabel.TabIndex = 11;
            this.statusLabel.Text = "label12";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Status: ";
            // 
            // downloadLimitLabel
            // 
            this.downloadLimitLabel.AutoSize = true;
            this.downloadLimitLabel.Location = new System.Drawing.Point(127, 94);
            this.downloadLimitLabel.Name = "downloadLimitLabel";
            this.downloadLimitLabel.Size = new System.Drawing.Size(41, 13);
            this.downloadLimitLabel.TabIndex = 9;
            this.downloadLimitLabel.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Download limit: ";
            // 
            // downloadSpeedLabel
            // 
            this.downloadSpeedLabel.AutoSize = true;
            this.downloadSpeedLabel.Location = new System.Drawing.Point(127, 71);
            this.downloadSpeedLabel.Name = "downloadSpeedLabel";
            this.downloadSpeedLabel.Size = new System.Drawing.Size(35, 13);
            this.downloadSpeedLabel.TabIndex = 7;
            this.downloadSpeedLabel.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Download rate: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Downloaded: ";
            // 
            // downloadedLabel
            // 
            this.downloadedLabel.AutoSize = true;
            this.downloadedLabel.Location = new System.Drawing.Point(127, 49);
            this.downloadedLabel.Name = "downloadedLabel";
            this.downloadedLabel.Size = new System.Drawing.Size(35, 13);
            this.downloadedLabel.TabIndex = 4;
            this.downloadedLabel.Text = "label5";
            // 
            // startedAtLabel
            // 
            this.startedAtLabel.AutoSize = true;
            this.startedAtLabel.Location = new System.Drawing.Point(359, 119);
            this.startedAtLabel.Name = "startedAtLabel";
            this.startedAtLabel.Size = new System.Drawing.Size(35, 13);
            this.startedAtLabel.TabIndex = 3;
            this.startedAtLabel.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Started At: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Time elapsed: ";
            // 
            // timeElapsedLabel
            // 
            this.timeElapsedLabel.AutoSize = true;
            this.timeElapsedLabel.Location = new System.Drawing.Point(127, 25);
            this.timeElapsedLabel.Name = "timeElapsedLabel";
            this.timeElapsedLabel.Size = new System.Drawing.Size(35, 13);
            this.timeElapsedLabel.TabIndex = 1;
            this.timeElapsedLabel.Text = "label3";
            // 
            // trackersTabPage
            // 
            this.trackersTabPage.Controls.Add(this.trackersListView);
            this.trackersTabPage.Location = new System.Drawing.Point(4, 22);
            this.trackersTabPage.Name = "trackersTabPage";
            this.trackersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.trackersTabPage.Size = new System.Drawing.Size(890, 220);
            this.trackersTabPage.TabIndex = 1;
            this.trackersTabPage.Text = "Trackers";
            this.trackersTabPage.UseVisualStyleBackColor = true;
            // 
            // trackersListView
            // 
            this.trackersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader22,
            this.columnHeader20,
            this.columnHeader21});
            this.trackersListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackersListView.FullRowSelect = true;
            this.trackersListView.Location = new System.Drawing.Point(3, 3);
            this.trackersListView.Name = "trackersListView";
            this.trackersListView.Size = new System.Drawing.Size(884, 214);
            this.trackersListView.TabIndex = 0;
            this.trackersListView.UseCompatibleStateImageBehavior = false;
            this.trackersListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Tier";
            this.columnHeader22.Width = 40;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Announce URL";
            this.columnHeader20.Width = 300;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Scrape URL";
            this.columnHeader21.Width = 300;
            // 
            // filesTabPage
            // 
            this.filesTabPage.Controls.Add(this.filesListView);
            this.filesTabPage.Location = new System.Drawing.Point(4, 22);
            this.filesTabPage.Name = "filesTabPage";
            this.filesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.filesTabPage.Size = new System.Drawing.Size(890, 220);
            this.filesTabPage.TabIndex = 2;
            this.filesTabPage.Text = "Files";
            this.filesTabPage.UseVisualStyleBackColor = true;
            // 
            // filesListView
            // 
            this.filesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader17,
            this.columnHeader5});
            this.filesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesListView.Enabled = false;
            this.filesListView.Location = new System.Drawing.Point(3, 3);
            this.filesListView.Name = "filesListView";
            this.filesListView.Size = new System.Drawing.Size(884, 214);
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
            // peersTabPage
            // 
            this.peersTabPage.Controls.Add(this.peersListView);
            this.peersTabPage.Location = new System.Drawing.Point(4, 22);
            this.peersTabPage.Name = "peersTabPage";
            this.peersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.peersTabPage.Size = new System.Drawing.Size(890, 220);
            this.peersTabPage.TabIndex = 3;
            this.peersTabPage.Text = "Peers";
            this.peersTabPage.UseVisualStyleBackColor = true;
            // 
            // peersListView
            // 
            this.peersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader27,
            this.columnHeader28,
            this.columnHeader29,
            this.columnHeader30,
            this.columnHeader31});
            this.peersListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.peersListView.FullRowSelect = true;
            this.peersListView.Location = new System.Drawing.Point(3, 3);
            this.peersListView.Name = "peersListView";
            this.peersListView.Size = new System.Drawing.Size(884, 214);
            this.peersListView.TabIndex = 0;
            this.peersListView.UseCompatibleStateImageBehavior = false;
            this.peersListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "Address";
            this.columnHeader27.Width = 120;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Client";
            this.columnHeader28.Width = 140;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "Progress";
            this.columnHeader29.Width = 80;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "Rate To Client";
            this.columnHeader30.Width = 80;
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "Rate To Peer";
            this.columnHeader31.Width = 80;
            // 
            // columnHeader17
            // 
            this.columnHeader17.DisplayIndex = 4;
            this.columnHeader17.Text = "Skip";
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 557);
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
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
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
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.torrentAndTabsSplitContainer.Panel1.ResumeLayout(false);
            this.torrentAndTabsSplitContainer.Panel2.ResumeLayout(false);
            this.torrentAndTabsSplitContainer.ResumeLayout(false);
            this.torrentTabControl.ResumeLayout(false);
            this.generalTabPage.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.Panel2.PerformLayout();
            this.splitContainer5.ResumeLayout(false);
            this.torrentDetailGroupBox.ResumeLayout(false);
            this.torrentDetailGroupBox.PerformLayout();
            this.trackersTabPage.ResumeLayout(false);
            this.filesTabPage.ResumeLayout(false);
            this.peersTabPage.ResumeLayout(false);
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
        private System.Windows.Forms.SplitContainer torrentAndTabsSplitContainer;
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
        public TransmissionRemoteDotnet.ListViewNF filesListView;
        public System.Windows.Forms.Timer filesTimer;
        private System.Windows.Forms.TabPage generalTabPage;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label percentageLabel;
        public System.Windows.Forms.TabControl torrentTabControl;
        private TransmissionRemoteDotnet.ListViewNF trackersListView;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer refreshElapsedTimer;
        private System.Windows.Forms.Label timeElapsedLabel;
        private System.Windows.Forms.GroupBox torrentDetailGroupBox;
        private System.Windows.Forms.Label downloadedLabel;
        private System.Windows.Forms.Label startedAtLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label downloadLimitLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label downloadSpeedLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label uploadRateLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label uploadedLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label remainingLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label uploadLimitLabel;
        private System.Windows.Forms.Label leechersLabel;
        private System.Windows.Forms.Label seedersLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label ratioLabel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label commentLabel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label labelForErrorLabel;
        private System.Windows.Forms.Label createdAtLabel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label createdByLabel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TabPage peersTabPage;
        private TransmissionRemoteDotnet.ListViewNF peersListView;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader29;
        private System.Windows.Forms.ColumnHeader columnHeader30;
        private System.Windows.Forms.ColumnHeader columnHeader31;
        private System.Windows.Forms.ColumnHeader columnHeader17;
    }
}