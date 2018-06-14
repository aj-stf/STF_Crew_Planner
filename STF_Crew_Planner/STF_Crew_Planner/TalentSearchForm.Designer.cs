namespace STF_CharacterPlanner
{
    partial class TalentSearchForm
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
            this.talentSearchDisplay1 = new STF_CharacterPlanner.TalentSearchDisplay();
            this.talentMenu1 = new STF_CharacterPlanner.TalentMenu();
            this.SuspendLayout();
            // 
            // talentSearchDisplay1
            // 
            this.talentSearchDisplay1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(152)))), ((int)(((byte)(221)))));
            this.talentSearchDisplay1.Location = new System.Drawing.Point(12, 118);
            this.talentSearchDisplay1.Name = "talentSearchDisplay1";
            this.talentSearchDisplay1.Size = new System.Drawing.Size(1160, 500);
            this.talentSearchDisplay1.TabIndex = 1;
            // 
            // talentMenu1
            // 
            this.talentMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(152)))), ((int)(((byte)(221)))));
            this.talentMenu1.Location = new System.Drawing.Point(12, 12);
            this.talentMenu1.Name = "talentMenu1";
            this.talentMenu1.Size = new System.Drawing.Size(1160, 100);
            this.talentMenu1.TabIndex = 0;
            // 
            // TalentSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(100)))), ((int)(((byte)(158)))));
            this.ClientSize = new System.Drawing.Size(1184, 621);
            this.Controls.Add(this.talentSearchDisplay1);
            this.Controls.Add(this.talentMenu1);
            this.Name = "TalentSearchForm";
            this.Text = "Search Talents";
            this.ResumeLayout(false);

        }

        #endregion

        public TalentMenu talentMenu1;
        public TalentSearchDisplay talentSearchDisplay1;
    }
}