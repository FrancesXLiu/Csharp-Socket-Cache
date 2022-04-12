namespace Cache
{
    partial class Form1
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
            this.cachedDataFragList = new System.Windows.Forms.ListBox();
            this.cacheLog = new System.Windows.Forms.TextBox();
            this.clearBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cachedDataFragList
            // 
            this.cachedDataFragList.FormattingEnabled = true;
            this.cachedDataFragList.ItemHeight = 31;
            this.cachedDataFragList.Location = new System.Drawing.Point(19, 50);
            this.cachedDataFragList.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cachedDataFragList.Name = "cachedDataFragList";
            this.cachedDataFragList.Size = new System.Drawing.Size(362, 841);
            this.cachedDataFragList.TabIndex = 0;
            this.cachedDataFragList.SelectedIndexChanged += new System.EventHandler(this.cachedDataFragList_SelectedIndexChanged);
            // 
            // cacheLog
            // 
            this.cacheLog.Location = new System.Drawing.Point(408, 50);
            this.cacheLog.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cacheLog.Multiline = true;
            this.cacheLog.Name = "cacheLog";
            this.cacheLog.Size = new System.Drawing.Size(1028, 918);
            this.cacheLog.TabIndex = 1;
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(20, 901);
            this.clearBtn.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(362, 67);
            this.clearBtn.TabIndex = 3;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cached File List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(408, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cache\'s Log";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 986);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.cacheLog);
            this.Controls.Add(this.cachedDataFragList);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Form1";
            this.Text = "Cache";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox cachedDataFragList;
        private TextBox cacheLog;
        private Button clearBtn;
        private Label label1;
        private Label label2;
    }
}