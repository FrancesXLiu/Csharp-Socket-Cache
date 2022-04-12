namespace Client
{
    partial class Client
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.availableFiles = new System.Windows.Forms.ListBox();
            this.downloadBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textDisplay = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // availableFiles
            // 
            this.availableFiles.FormattingEnabled = true;
            this.availableFiles.ItemHeight = 31;
            this.availableFiles.Location = new System.Drawing.Point(19, 43);
            this.availableFiles.Margin = new System.Windows.Forms.Padding(5);
            this.availableFiles.Name = "availableFiles";
            this.availableFiles.Size = new System.Drawing.Size(365, 717);
            this.availableFiles.TabIndex = 0;
            this.availableFiles.SelectedIndexChanged += new System.EventHandler(this.availableFiles_SelectedIndexChanged);
            // 
            // downloadBtn
            // 
            this.downloadBtn.Location = new System.Drawing.Point(19, 774);
            this.downloadBtn.Margin = new System.Windows.Forms.Padding(5);
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.Size = new System.Drawing.Size(367, 87);
            this.downloadBtn.TabIndex = 2;
            this.downloadBtn.Text = "Download";
            this.downloadBtn.UseVisualStyleBackColor = true;
            this.downloadBtn.Click += new System.EventHandler(this.downloadBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(415, 43);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(884, 915);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Available Files on Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(415, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "Image Display";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1332, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 31);
            this.label3.TabIndex = 6;
            this.label3.Text = "Text Display";
            // 
            // textDisplay
            // 
            this.textDisplay.Location = new System.Drawing.Point(1332, 42);
            this.textDisplay.Multiline = true;
            this.textDisplay.Name = "textDisplay";
            this.textDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textDisplay.Size = new System.Drawing.Size(981, 916);
            this.textDisplay.TabIndex = 7;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(19, 871);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(5);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(367, 87);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "Save As";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2342, 976);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.textDisplay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.downloadBtn);
            this.Controls.Add(this.availableFiles);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Client";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Client_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox availableFiles;
        private Button downloadBtn;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textDisplay;
        private Button saveBtn;
    }
}