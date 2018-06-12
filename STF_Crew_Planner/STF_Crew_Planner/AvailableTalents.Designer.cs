namespace STF_CharacterPlanner
{
    partial class AvailableTalents
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
            this.availableTalentBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.talentsLeft = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // availableTalentBox
            // 
            this.availableTalentBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.availableTalentBox.FormattingEnabled = true;
            this.availableTalentBox.Location = new System.Drawing.Point(2, 29);
            this.availableTalentBox.Name = "availableTalentBox";
            this.availableTalentBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.availableTalentBox.Size = new System.Drawing.Size(276, 134);
            this.availableTalentBox.TabIndex = 0;
            this.availableTalentBox.SelectedIndexChanged += new System.EventHandler(this.availableTalentBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(213)))), ((int)(((byte)(241)))));
            this.label1.Location = new System.Drawing.Point(22, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available Talents";
            // 
            // talentsLeft
            // 
            this.talentsLeft.AutoSize = true;
            this.talentsLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.talentsLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.talentsLeft.Location = new System.Drawing.Point(3, 12);
            this.talentsLeft.Name = "talentsLeft";
            this.talentsLeft.Size = new System.Drawing.Size(15, 15);
            this.talentsLeft.TabIndex = 2;
            this.talentsLeft.Text = "0";
            // 
            // AvailableTalents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.talentsLeft);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.availableTalentBox);
            this.Name = "AvailableTalents";
            this.Size = new System.Drawing.Size(280, 175);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox availableTalentBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label talentsLeft;
    }
}
