namespace STF_CharacterPlanner
{
    partial class TalentMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.searchTermBox = new System.Windows.Forms.TextBox();
            this.searchTermButton = new System.Windows.Forms.Button();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.searchTypeButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.jobBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.searchJobButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search Description by Term";
            // 
            // searchTermBox
            // 
            this.searchTermBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.searchTermBox.Location = new System.Drawing.Point(6, 32);
            this.searchTermBox.Name = "searchTermBox";
            this.searchTermBox.Size = new System.Drawing.Size(200, 20);
            this.searchTermBox.TabIndex = 1;
            // 
            // searchTermButton
            // 
            this.searchTermButton.Location = new System.Drawing.Point(6, 58);
            this.searchTermButton.Name = "searchTermButton";
            this.searchTermButton.Size = new System.Drawing.Size(100, 23);
            this.searchTermButton.TabIndex = 2;
            this.searchTermButton.Text = "Search";
            this.searchTermButton.UseVisualStyleBackColor = true;
            this.searchTermButton.Click += new System.EventHandler(this.searchTermButton_Click);
            // 
            // typeBox
            // 
            this.typeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Location = new System.Drawing.Point(957, 32);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(200, 21);
            this.typeBox.TabIndex = 3;
            this.typeBox.SelectedIndexChanged += new System.EventHandler(this.typeBox_SelectedIndexChanged);
            // 
            // searchTypeButton
            // 
            this.searchTypeButton.Location = new System.Drawing.Point(1057, 58);
            this.searchTypeButton.Name = "searchTypeButton";
            this.searchTypeButton.Size = new System.Drawing.Size(100, 23);
            this.searchTypeButton.TabIndex = 4;
            this.searchTypeButton.Text = "Search";
            this.searchTypeButton.UseVisualStyleBackColor = true;
            this.searchTypeButton.Click += new System.EventHandler(this.searchTypeButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1075, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Search by Type";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // jobBox
            // 
            this.jobBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.jobBox.FormattingEnabled = true;
            this.jobBox.Location = new System.Drawing.Point(499, 32);
            this.jobBox.Name = "jobBox";
            this.jobBox.Size = new System.Drawing.Size(200, 21);
            this.jobBox.TabIndex = 6;
            this.jobBox.SelectedIndexChanged += new System.EventHandler(this.jobBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(562, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Search by Job";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // searchJobButton
            // 
            this.searchJobButton.Location = new System.Drawing.Point(549, 58);
            this.searchJobButton.Name = "searchJobButton";
            this.searchJobButton.Size = new System.Drawing.Size(100, 23);
            this.searchJobButton.TabIndex = 8;
            this.searchJobButton.Text = "Search";
            this.searchJobButton.UseVisualStyleBackColor = true;
            this.searchJobButton.Click += new System.EventHandler(this.searchJobButton_Click);
            // 
            // TalentMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(152)))), ((int)(((byte)(221)))));
            this.Controls.Add(this.searchJobButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.jobBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchTypeButton);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.searchTermButton);
            this.Controls.Add(this.searchTermBox);
            this.Controls.Add(this.label1);
            this.Name = "TalentMenu";
            this.Size = new System.Drawing.Size(1160, 100);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchTermBox;
        private System.Windows.Forms.Button searchTermButton;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.Button searchTypeButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox jobBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button searchJobButton;
    }
}
