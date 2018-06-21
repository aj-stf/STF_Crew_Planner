namespace STF_CharacterPlanner
{
    partial class TalentSearchDisplay
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
            this.talentSearchGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.talentSearchGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // talentSearchGrid
            // 
            this.talentSearchGrid.AllowUserToAddRows = false;
            this.talentSearchGrid.AllowUserToDeleteRows = false;
            this.talentSearchGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.talentSearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.talentSearchGrid.Location = new System.Drawing.Point(3, 3);
            this.talentSearchGrid.MaximumSize = new System.Drawing.Size(1154, 3000);
            this.talentSearchGrid.MinimumSize = new System.Drawing.Size(1154, 0);
            this.talentSearchGrid.Name = "talentSearchGrid";
            this.talentSearchGrid.ReadOnly = true;
            this.talentSearchGrid.Size = new System.Drawing.Size(1154, 494);
            this.talentSearchGrid.TabIndex = 1;
            // 
            // TalentSearchDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(152)))), ((int)(((byte)(221)))));
            this.Controls.Add(this.talentSearchGrid);
            this.Name = "TalentSearchDisplay";
            this.Size = new System.Drawing.Size(1160, 500);
            ((System.ComponentModel.ISupportInitialize)(this.talentSearchGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView talentSearchGrid;
    }
}
