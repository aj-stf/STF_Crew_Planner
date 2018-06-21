namespace STF_CharacterPlanner
{
    partial class ConfigureCrewForm
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
            this.crewInput1 = new STF_CharacterPlanner.CrewInput();
            this.shipCrewMenu1 = new STF_CharacterPlanner.ShipCrewMenu();
            this.SuspendLayout();
            // 
            // crewInput1
            // 
            this.crewInput1.AutoScroll = true;
            this.crewInput1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(152)))), ((int)(((byte)(221)))));
            this.crewInput1.Location = new System.Drawing.Point(12, 87);
            this.crewInput1.Name = "crewInput1";
            this.crewInput1.Size = new System.Drawing.Size(680, 760);
            this.crewInput1.TabIndex = 1;
            // 
            // shipCrewMenu1
            // 
            this.shipCrewMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(152)))), ((int)(((byte)(221)))));
            this.shipCrewMenu1.Location = new System.Drawing.Point(12, 12);
            this.shipCrewMenu1.Name = "shipCrewMenu1";
            this.shipCrewMenu1.Size = new System.Drawing.Size(680, 69);
            this.shipCrewMenu1.TabIndex = 0;
            // 
            // ConfigureCrewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(100)))), ((int)(((byte)(158)))));
            this.ClientSize = new System.Drawing.Size(704, 741);
            this.Controls.Add(this.crewInput1);
            this.Controls.Add(this.shipCrewMenu1);
            this.Name = "ConfigureCrewForm";
            this.Text = "Configure Crew";
            this.ResumeLayout(false);

        }

        #endregion

        public ShipCrewMenu shipCrewMenu1;
        public CrewInput crewInput1;
    }
}