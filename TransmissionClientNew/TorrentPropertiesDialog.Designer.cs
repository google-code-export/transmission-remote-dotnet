namespace TransmissionRemoteDotnet
{
    partial class TorrentPropertiesDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TorrentPropertiesDialog));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.peerLimitValue = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.uploadLimitEnableField = new System.Windows.Forms.CheckBox();
            this.downloadLimitField = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.uploadLimitField = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.downloadLimitEnableField = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peerLimitValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadLimitField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uploadLimitField)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(257, 144);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.peerLimitValue);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.uploadLimitEnableField);
            this.tabPage1.Controls.Add(this.downloadLimitField);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.uploadLimitField);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.downloadLimitEnableField);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(249, 118);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // peerLimitValue
            // 
            this.peerLimitValue.Location = new System.Drawing.Point(131, 75);
            this.peerLimitValue.Name = "peerLimitValue";
            this.peerLimitValue.Size = new System.Drawing.Size(56, 20);
            this.peerLimitValue.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Maximum peers";
            // 
            // uploadLimitEnableField
            // 
            this.uploadLimitEnableField.AutoSize = true;
            this.uploadLimitEnableField.Location = new System.Drawing.Point(6, 18);
            this.uploadLimitEnableField.Name = "uploadLimitEnableField";
            this.uploadLimitEnableField.Size = new System.Drawing.Size(103, 17);
            this.uploadLimitEnableField.TabIndex = 6;
            this.uploadLimitEnableField.Text = "Limit upload rate";
            this.uploadLimitEnableField.UseVisualStyleBackColor = true;
            this.uploadLimitEnableField.CheckedChanged += new System.EventHandler(this.uploadLimitEnableField_CheckedChanged);
            // 
            // downloadLimitField
            // 
            this.downloadLimitField.Location = new System.Drawing.Point(131, 46);
            this.downloadLimitField.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.downloadLimitField.Name = "downloadLimitField";
            this.downloadLimitField.Size = new System.Drawing.Size(56, 20);
            this.downloadLimitField.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "KB/s";
            // 
            // uploadLimitField
            // 
            this.uploadLimitField.Location = new System.Drawing.Point(131, 17);
            this.uploadLimitField.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.uploadLimitField.Name = "uploadLimitField";
            this.uploadLimitField.Size = new System.Drawing.Size(56, 20);
            this.uploadLimitField.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "KB/s";
            // 
            // downloadLimitEnableField
            // 
            this.downloadLimitEnableField.AutoSize = true;
            this.downloadLimitEnableField.Location = new System.Drawing.Point(6, 47);
            this.downloadLimitEnableField.Name = "downloadLimitEnableField";
            this.downloadLimitEnableField.Size = new System.Drawing.Size(117, 17);
            this.downloadLimitEnableField.TabIndex = 7;
            this.downloadLimitEnableField.Text = "Limit download rate";
            this.downloadLimitEnableField.UseVisualStyleBackColor = true;
            this.downloadLimitEnableField.CheckedChanged += new System.EventHandler(this.downloadLimitEnableField_CheckedChanged);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(197, 162);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 22);
            this.button2.TabIndex = 0;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(119, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 22);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TorrentPropertiesDialog
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(282, 195);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TorrentPropertiesDialog";
            this.Text = "TorrentPropertiesDialog";
            this.Load += new System.EventHandler(this.TorrentPropertiesDialog_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peerLimitValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadLimitField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uploadLimitField)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.NumericUpDown downloadLimitField;
        private System.Windows.Forms.NumericUpDown uploadLimitField;
        private System.Windows.Forms.CheckBox downloadLimitEnableField;
        private System.Windows.Forms.CheckBox uploadLimitEnableField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown peerLimitValue;
        private System.Windows.Forms.Label label3;


    }
}