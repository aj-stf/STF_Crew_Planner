namespace STF_CharacterPlanner
{
    partial class OfficerSkillDisplay
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
            this.skillsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // skillsListBox
            // 
            this.skillsListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.skillsListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.skillsListBox.FormattingEnabled = true;
            this.skillsListBox.Location = new System.Drawing.Point(12, 20);
            this.skillsListBox.Name = "skillsListBox";
            this.skillsListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.skillsListBox.Size = new System.Drawing.Size(100, 121);
            this.skillsListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(213)))), ((int)(((byte)(241)))));
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Skills";
            // 
            // numBox1
            // 
            this.numBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.numBox1.FormattingEnabled = true;
            this.numBox1.Location = new System.Drawing.Point(115, 20);
            this.numBox1.Name = "numBox1";
            this.numBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.numBox1.Size = new System.Drawing.Size(39, 121);
            this.numBox1.TabIndex = 2;
            // 
            // OfficerSkillDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.skillsListBox);
            this.Name = "OfficerSkillDisplay";
            this.Size = new System.Drawing.Size(214, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox skillsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox numBox1;
    }
}
