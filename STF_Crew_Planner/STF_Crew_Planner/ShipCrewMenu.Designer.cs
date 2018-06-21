namespace STF_CharacterPlanner
{
    partial class ShipCrewMenu
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
            this.NumberOfCrew = new System.Windows.Forms.Label();
            this.ShipMaxCrew = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.resetCrewButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(213)))), ((int)(((byte)(241)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Num of Crew";
            // 
            // NumberOfCrew
            // 
            this.NumberOfCrew.AutoSize = true;
            this.NumberOfCrew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(213)))), ((int)(((byte)(241)))));
            this.NumberOfCrew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumberOfCrew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberOfCrew.Location = new System.Drawing.Point(110, 12);
            this.NumberOfCrew.Name = "NumberOfCrew";
            this.NumberOfCrew.Size = new System.Drawing.Size(18, 20);
            this.NumberOfCrew.TabIndex = 6;
            this.NumberOfCrew.Text = "0";
            // 
            // ShipMaxCrew
            // 
            this.ShipMaxCrew.AutoSize = true;
            this.ShipMaxCrew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(213)))), ((int)(((byte)(241)))));
            this.ShipMaxCrew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ShipMaxCrew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShipMaxCrew.Location = new System.Drawing.Point(110, 37);
            this.ShipMaxCrew.Name = "ShipMaxCrew";
            this.ShipMaxCrew.Size = new System.Drawing.Size(18, 20);
            this.ShipMaxCrew.TabIndex = 8;
            this.ShipMaxCrew.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(213)))), ((int)(((byte)(241)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ship Max";
            // 
            // resetCrewButton
            // 
            this.resetCrewButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(213)))), ((int)(((byte)(241)))));
            this.resetCrewButton.Location = new System.Drawing.Point(586, 36);
            this.resetCrewButton.Name = "resetCrewButton";
            this.resetCrewButton.Size = new System.Drawing.Size(75, 23);
            this.resetCrewButton.TabIndex = 9;
            this.resetCrewButton.Text = "Reset Crew";
            this.resetCrewButton.UseVisualStyleBackColor = false;
            this.resetCrewButton.Click += new System.EventHandler(this.resetCrewButton_Click);
            // 
            // ShipCrewMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(152)))), ((int)(((byte)(221)))));
            this.Controls.Add(this.resetCrewButton);
            this.Controls.Add(this.ShipMaxCrew);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NumberOfCrew);
            this.Controls.Add(this.label1);
            this.Name = "ShipCrewMenu";
            this.Size = new System.Drawing.Size(680, 69);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label NumberOfCrew;
        public System.Windows.Forms.Label ShipMaxCrew;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button resetCrewButton;
    }
}
