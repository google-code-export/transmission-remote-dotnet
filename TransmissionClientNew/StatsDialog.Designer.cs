namespace TransmissionRemoteDotnet
{
    partial class StatsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatsDialog));
            this.downloadedBytesLabel2 = new System.Windows.Forms.Label();
            this.uploadedBytesLabel2 = new System.Windows.Forms.Label();
            this.CloseFormButton = new System.Windows.Forms.Button();
            this.statsWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.secondsActiveValue2 = new System.Windows.Forms.Label();
            this.sessionCountValue2 = new System.Windows.Forms.Label();
            this.filesAddedValue2 = new System.Windows.Forms.Label();
            this.uploadedBytesValue2 = new System.Windows.Forms.Label();
            this.downloadedBytesValue2 = new System.Windows.Forms.Label();
            this.secondsActiveLabel2 = new System.Windows.Forms.Label();
            this.sessionCountLabel2 = new System.Windows.Forms.Label();
            this.filesAddedLabel2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.secondsActiveValue1 = new System.Windows.Forms.Label();
            this.sessionCountValue1 = new System.Windows.Forms.Label();
            this.filesAddedValue1 = new System.Windows.Forms.Label();
            this.uploadedBytesValue1 = new System.Windows.Forms.Label();
            this.downloadedBytesValue1 = new System.Windows.Forms.Label();
            this.secondsActiveLabel1 = new System.Windows.Forms.Label();
            this.sessionCountLabel1 = new System.Windows.Forms.Label();
            this.filesAddedLabel1 = new System.Windows.Forms.Label();
            this.downloadedBytesLabel1 = new System.Windows.Forms.Label();
            this.uploadedBytesLabel1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // downloadedBytesLabel2
            // 
            this.downloadedBytesLabel2.AutoSize = true;
            this.downloadedBytesLabel2.Location = new System.Drawing.Point(6, 25);
            this.downloadedBytesLabel2.Name = "downloadedBytesLabel2";
            this.downloadedBytesLabel2.Size = new System.Drawing.Size(98, 13);
            this.downloadedBytesLabel2.TabIndex = 0;
            this.downloadedBytesLabel2.Text = "Downloaded bytes:";
            // 
            // uploadedBytesLabel2
            // 
            this.uploadedBytesLabel2.AutoSize = true;
            this.uploadedBytesLabel2.Location = new System.Drawing.Point(6, 53);
            this.uploadedBytesLabel2.Name = "uploadedBytesLabel2";
            this.uploadedBytesLabel2.Size = new System.Drawing.Size(84, 13);
            this.uploadedBytesLabel2.TabIndex = 2;
            this.uploadedBytesLabel2.Text = "Uploaded bytes:";
            // 
            // CloseFormButton
            // 
            this.CloseFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseFormButton.Location = new System.Drawing.Point(372, 178);
            this.CloseFormButton.Name = "CloseFormButton";
            this.CloseFormButton.Size = new System.Drawing.Size(75, 23);
            this.CloseFormButton.TabIndex = 9;
            this.CloseFormButton.Text = "Close";
            this.CloseFormButton.UseVisualStyleBackColor = true;
            this.CloseFormButton.Click += new System.EventHandler(this.CloseFormButton_Click);
            // 
            // statsWorker
            // 
            this.statsWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.StatsWorker_DoWork);
            this.statsWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.StatsWorker_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.secondsActiveValue2);
            this.groupBox1.Controls.Add(this.sessionCountValue2);
            this.groupBox1.Controls.Add(this.filesAddedValue2);
            this.groupBox1.Controls.Add(this.uploadedBytesValue2);
            this.groupBox1.Controls.Add(this.downloadedBytesValue2);
            this.groupBox1.Controls.Add(this.secondsActiveLabel2);
            this.groupBox1.Controls.Add(this.sessionCountLabel2);
            this.groupBox1.Controls.Add(this.filesAddedLabel2);
            this.groupBox1.Controls.Add(this.downloadedBytesLabel2);
            this.groupBox1.Controls.Add(this.uploadedBytesLabel2);
            this.groupBox1.Location = new System.Drawing.Point(231, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 167);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Global";
            // 
            // secondsActiveValue2
            // 
            this.secondsActiveValue2.AutoSize = true;
            this.secondsActiveValue2.Location = new System.Drawing.Point(128, 138);
            this.secondsActiveValue2.Name = "secondsActiveValue2";
            this.secondsActiveValue2.Size = new System.Drawing.Size(58, 13);
            this.secondsActiveValue2.TabIndex = 18;
            this.secondsActiveValue2.Text = "Querying...";
            // 
            // sessionCountValue2
            // 
            this.sessionCountValue2.AutoSize = true;
            this.sessionCountValue2.Location = new System.Drawing.Point(128, 110);
            this.sessionCountValue2.Name = "sessionCountValue2";
            this.sessionCountValue2.Size = new System.Drawing.Size(58, 13);
            this.sessionCountValue2.TabIndex = 17;
            this.sessionCountValue2.Text = "Querying...";
            // 
            // filesAddedValue2
            // 
            this.filesAddedValue2.AutoSize = true;
            this.filesAddedValue2.Location = new System.Drawing.Point(128, 82);
            this.filesAddedValue2.Name = "filesAddedValue2";
            this.filesAddedValue2.Size = new System.Drawing.Size(58, 13);
            this.filesAddedValue2.TabIndex = 16;
            this.filesAddedValue2.Text = "Querying...";
            // 
            // uploadedBytesValue2
            // 
            this.uploadedBytesValue2.AutoSize = true;
            this.uploadedBytesValue2.Location = new System.Drawing.Point(128, 53);
            this.uploadedBytesValue2.Name = "uploadedBytesValue2";
            this.uploadedBytesValue2.Size = new System.Drawing.Size(58, 13);
            this.uploadedBytesValue2.TabIndex = 15;
            this.uploadedBytesValue2.Text = "Querying...";
            // 
            // downloadedBytesValue2
            // 
            this.downloadedBytesValue2.AutoSize = true;
            this.downloadedBytesValue2.Location = new System.Drawing.Point(128, 25);
            this.downloadedBytesValue2.Name = "downloadedBytesValue2";
            this.downloadedBytesValue2.Size = new System.Drawing.Size(58, 13);
            this.downloadedBytesValue2.TabIndex = 14;
            this.downloadedBytesValue2.Text = "Querying...";
            // 
            // secondsActiveLabel2
            // 
            this.secondsActiveLabel2.AutoSize = true;
            this.secondsActiveLabel2.Location = new System.Drawing.Point(6, 138);
            this.secondsActiveLabel2.Name = "secondsActiveLabel2";
            this.secondsActiveLabel2.Size = new System.Drawing.Size(81, 13);
            this.secondsActiveLabel2.TabIndex = 13;
            this.secondsActiveLabel2.Text = "Seconds active";
            // 
            // sessionCountLabel2
            // 
            this.sessionCountLabel2.AutoSize = true;
            this.sessionCountLabel2.Location = new System.Drawing.Point(6, 110);
            this.sessionCountLabel2.Name = "sessionCountLabel2";
            this.sessionCountLabel2.Size = new System.Drawing.Size(75, 13);
            this.sessionCountLabel2.TabIndex = 12;
            this.sessionCountLabel2.Text = "Session Count";
            // 
            // filesAddedLabel2
            // 
            this.filesAddedLabel2.AutoSize = true;
            this.filesAddedLabel2.Location = new System.Drawing.Point(6, 82);
            this.filesAddedLabel2.Name = "filesAddedLabel2";
            this.filesAddedLabel2.Size = new System.Drawing.Size(64, 13);
            this.filesAddedLabel2.TabIndex = 9;
            this.filesAddedLabel2.Text = "Files added:";
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.secondsActiveValue1);
            this.groupBox2.Controls.Add(this.sessionCountValue1);
            this.groupBox2.Controls.Add(this.filesAddedValue1);
            this.groupBox2.Controls.Add(this.uploadedBytesValue1);
            this.groupBox2.Controls.Add(this.downloadedBytesValue1);
            this.groupBox2.Controls.Add(this.secondsActiveLabel1);
            this.groupBox2.Controls.Add(this.sessionCountLabel1);
            this.groupBox2.Controls.Add(this.filesAddedLabel1);
            this.groupBox2.Controls.Add(this.downloadedBytesLabel1);
            this.groupBox2.Controls.Add(this.uploadedBytesLabel1);
            this.groupBox2.Location = new System.Drawing.Point(9, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 167);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current Session";
            // 
            // secondsActiveValue1
            // 
            this.secondsActiveValue1.AutoSize = true;
            this.secondsActiveValue1.Location = new System.Drawing.Point(128, 138);
            this.secondsActiveValue1.Name = "secondsActiveValue1";
            this.secondsActiveValue1.Size = new System.Drawing.Size(58, 13);
            this.secondsActiveValue1.TabIndex = 18;
            this.secondsActiveValue1.Text = "Querying...";
            // 
            // sessionCountValue1
            // 
            this.sessionCountValue1.AutoSize = true;
            this.sessionCountValue1.Location = new System.Drawing.Point(128, 110);
            this.sessionCountValue1.Name = "sessionCountValue1";
            this.sessionCountValue1.Size = new System.Drawing.Size(58, 13);
            this.sessionCountValue1.TabIndex = 17;
            this.sessionCountValue1.Text = "Querying...";
            // 
            // filesAddedValue1
            // 
            this.filesAddedValue1.AutoSize = true;
            this.filesAddedValue1.Location = new System.Drawing.Point(128, 82);
            this.filesAddedValue1.Name = "filesAddedValue1";
            this.filesAddedValue1.Size = new System.Drawing.Size(58, 13);
            this.filesAddedValue1.TabIndex = 16;
            this.filesAddedValue1.Text = "Querying...";
            // 
            // uploadedBytesValue1
            // 
            this.uploadedBytesValue1.AutoSize = true;
            this.uploadedBytesValue1.Location = new System.Drawing.Point(128, 53);
            this.uploadedBytesValue1.Name = "uploadedBytesValue1";
            this.uploadedBytesValue1.Size = new System.Drawing.Size(58, 13);
            this.uploadedBytesValue1.TabIndex = 15;
            this.uploadedBytesValue1.Text = "Querying...";
            // 
            // downloadedBytesValue1
            // 
            this.downloadedBytesValue1.AutoSize = true;
            this.downloadedBytesValue1.Location = new System.Drawing.Point(128, 25);
            this.downloadedBytesValue1.Name = "downloadedBytesValue1";
            this.downloadedBytesValue1.Size = new System.Drawing.Size(58, 13);
            this.downloadedBytesValue1.TabIndex = 14;
            this.downloadedBytesValue1.Text = "Querying...";
            // 
            // secondsActiveLabel1
            // 
            this.secondsActiveLabel1.AutoSize = true;
            this.secondsActiveLabel1.Location = new System.Drawing.Point(6, 138);
            this.secondsActiveLabel1.Name = "secondsActiveLabel1";
            this.secondsActiveLabel1.Size = new System.Drawing.Size(81, 13);
            this.secondsActiveLabel1.TabIndex = 13;
            this.secondsActiveLabel1.Text = "Seconds active";
            // 
            // sessionCountLabel1
            // 
            this.sessionCountLabel1.AutoSize = true;
            this.sessionCountLabel1.Location = new System.Drawing.Point(6, 110);
            this.sessionCountLabel1.Name = "sessionCountLabel1";
            this.sessionCountLabel1.Size = new System.Drawing.Size(75, 13);
            this.sessionCountLabel1.TabIndex = 12;
            this.sessionCountLabel1.Text = "Session Count";
            // 
            // filesAddedLabel1
            // 
            this.filesAddedLabel1.AutoSize = true;
            this.filesAddedLabel1.Location = new System.Drawing.Point(6, 82);
            this.filesAddedLabel1.Name = "filesAddedLabel1";
            this.filesAddedLabel1.Size = new System.Drawing.Size(64, 13);
            this.filesAddedLabel1.TabIndex = 9;
            this.filesAddedLabel1.Text = "Files added:";
            // 
            // downloadedBytesLabel1
            // 
            this.downloadedBytesLabel1.AutoSize = true;
            this.downloadedBytesLabel1.Location = new System.Drawing.Point(6, 25);
            this.downloadedBytesLabel1.Name = "downloadedBytesLabel1";
            this.downloadedBytesLabel1.Size = new System.Drawing.Size(98, 13);
            this.downloadedBytesLabel1.TabIndex = 0;
            this.downloadedBytesLabel1.Text = "Downloaded bytes:";
            // 
            // uploadedBytesLabel1
            // 
            this.uploadedBytesLabel1.AutoSize = true;
            this.uploadedBytesLabel1.Location = new System.Drawing.Point(6, 53);
            this.uploadedBytesLabel1.Name = "uploadedBytesLabel1";
            this.uploadedBytesLabel1.Size = new System.Drawing.Size(84, 13);
            this.uploadedBytesLabel1.TabIndex = 2;
            this.uploadedBytesLabel1.Text = "Uploaded bytes:";
            // 
            // StatsDialog
            // 
            this.AcceptButton = this.CloseFormButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseFormButton;
            this.ClientSize = new System.Drawing.Size(458, 211);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CloseFormButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StatsDialog";
            this.Text = "Transmission Daemon Statistics";
            this.Load += new System.EventHandler(this.StatsDialog_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StatsDialog_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseFormButton;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker statsWorker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label secondsActiveValue1;
        private System.Windows.Forms.Label sessionCountValue1;
        private System.Windows.Forms.Label filesAddedValue1;
        private System.Windows.Forms.Label uploadedBytesValue1;
        private System.Windows.Forms.Label downloadedBytesValue1;
        private System.Windows.Forms.Label secondsActiveLabel1;
        private System.Windows.Forms.Label sessionCountLabel1;
        private System.Windows.Forms.Label filesAddedLabel1;
        private System.Windows.Forms.Label downloadedBytesLabel1;
        private System.Windows.Forms.Label uploadedBytesLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label filesAddedLabel2;
        private System.Windows.Forms.Label sessionCountLabel2;
        private System.Windows.Forms.Label secondsActiveLabel2;
        private System.Windows.Forms.Label secondsActiveValue2;
        private System.Windows.Forms.Label sessionCountValue2;
        private System.Windows.Forms.Label filesAddedValue2;
        private System.Windows.Forms.Label uploadedBytesValue2;
        private System.Windows.Forms.Label downloadedBytesValue2;
        private System.Windows.Forms.Label downloadedBytesLabel2;
        private System.Windows.Forms.Label uploadedBytesLabel2;
    }
}