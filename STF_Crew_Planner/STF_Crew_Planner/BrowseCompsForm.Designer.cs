namespace STF_CharacterPlanner
{
    partial class BrowseCompsForm
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
            this.compBrowser1 = new STF_CharacterPlanner.CompBrowser();
            this.SuspendLayout();
            // 
            // compBrowser1
            // 
            this.compBrowser1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(152)))), ((int)(((byte)(221)))));
            this.compBrowser1.Location = new System.Drawing.Point(12, 12);
            this.compBrowser1.Name = "compBrowser1";
            this.compBrowser1.Size = new System.Drawing.Size(1160, 537);
            this.compBrowser1.TabIndex = 0;
            // 
            // BrowseCompsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(100)))), ((int)(((byte)(158)))));
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.compBrowser1);
            this.Name = "BrowseCompsForm";
            this.Text = "Browse Components";
            this.ResumeLayout(false);

        }

        #endregion

        private CompBrowser compBrowser1;
    }
}