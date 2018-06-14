namespace STF_CharacterPlanner
{
    partial class BridgeMember
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
            this.selectedTalents1 = new STF_CharacterPlanner.SelectedTalents();
            this.availableTalents1 = new STF_CharacterPlanner.AvailableTalents();
            this.officerControl1 = new STF_CharacterPlanner.OfficerControl();
            this.officerSkillDisplay1 = new STF_CharacterPlanner.OfficerSkillDisplay();
            this.SuspendLayout();
            // 
            // selectedTalents1
            // 
            this.selectedTalents1.Location = new System.Drawing.Point(482, -10);
            this.selectedTalents1.Name = "selectedTalents1";
            this.selectedTalents1.Size = new System.Drawing.Size(380, 175);
            this.selectedTalents1.TabIndex = 4;
            // 
            // availableTalents1
            // 
            this.availableTalents1.Location = new System.Drawing.Point(880, -10);
            this.availableTalents1.Name = "availableTalents1";
            this.availableTalents1.Size = new System.Drawing.Size(380, 175);
            this.availableTalents1.TabIndex = 3;
            // 
            // officerControl1
            // 
            this.officerControl1.Location = new System.Drawing.Point(3, -10);
            this.officerControl1.Name = "officerControl1";
            this.officerControl1.Size = new System.Drawing.Size(303, 168);
            this.officerControl1.TabIndex = 2;
            // 
            // officerSkillDisplay1
            // 
            this.officerSkillDisplay1.Location = new System.Drawing.Point(312, 0);
            this.officerSkillDisplay1.Name = "officerSkillDisplay1";
            this.officerSkillDisplay1.Size = new System.Drawing.Size(214, 150);
            this.officerSkillDisplay1.TabIndex = 1;
            // 
            // BridgeMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(152)))), ((int)(((byte)(221)))));
            this.Controls.Add(this.selectedTalents1);
            this.Controls.Add(this.availableTalents1);
            this.Controls.Add(this.officerControl1);
            this.Controls.Add(this.officerSkillDisplay1);
            this.Name = "BridgeMember";
            this.Size = new System.Drawing.Size(1260, 158);
            this.ResumeLayout(false);

        }

        #endregion

        public OfficerSkillDisplay officerSkillDisplay1;
        public OfficerControl officerControl1;
        public AvailableTalents availableTalents1;
        public SelectedTalents selectedTalents1;
    }
}
