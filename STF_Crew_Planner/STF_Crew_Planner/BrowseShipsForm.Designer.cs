namespace STF_CharacterPlanner
{
    partial class BrowseShipsForm
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
            this.shipBrowser1 = new STF_CharacterPlanner.ShipBrowser();
            this.SuspendLayout();
            // 
            // shipBrowser1
            // 
            this.shipBrowser1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(152)))), ((int)(((byte)(221)))));
            this.shipBrowser1.Location = new System.Drawing.Point(12, 12);
            this.shipBrowser1.Name = "shipBrowser1";
            this.shipBrowser1.Size = new System.Drawing.Size(1160, 537);
            this.shipBrowser1.TabIndex = 0;
            // 
            // BrowseShipsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(100)))), ((int)(((byte)(158)))));
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.shipBrowser1);
            this.Name = "BrowseShipsForm";
            this.Text = "Browse Ships";
            this.ResumeLayout(false);

        }

        #endregion

        private ShipBrowser shipBrowser1;
    }
}