namespace STF_CharacterPlanner
{
    partial class ConfigureShipForm
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
            this.componentSelect1 = new STF_CharacterPlanner.ComponentSelect();
            this.shipConfigureMenu1 = new STF_CharacterPlanner.ShipConfigureMenu();
            this.SuspendLayout();
            // 
            // componentSelect1
            // 
            this.componentSelect1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(152)))), ((int)(((byte)(221)))));
            this.componentSelect1.Location = new System.Drawing.Point(12, 414);
            this.componentSelect1.Name = "componentSelect1";
            this.componentSelect1.Size = new System.Drawing.Size(1160, 435);
            this.componentSelect1.TabIndex = 1;
            // 
            // shipConfigureMenu1
            // 
            this.shipConfigureMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(152)))), ((int)(((byte)(221)))));
            this.shipConfigureMenu1.Location = new System.Drawing.Point(12, 10);
            this.shipConfigureMenu1.Name = "shipConfigureMenu1";
            this.shipConfigureMenu1.Size = new System.Drawing.Size(1160, 390);
            this.shipConfigureMenu1.TabIndex = 0;
            // 
            // ConfigureShipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(100)))), ((int)(((byte)(158)))));
            this.ClientSize = new System.Drawing.Size(1184, 861);
            this.Controls.Add(this.componentSelect1);
            this.Controls.Add(this.shipConfigureMenu1);
            this.Name = "ConfigureShipForm";
            this.Text = "Configure Ship";
            this.ResumeLayout(false);

        }

        #endregion

        public ShipConfigureMenu shipConfigureMenu1;
        public ComponentSelect componentSelect1;
    }
}