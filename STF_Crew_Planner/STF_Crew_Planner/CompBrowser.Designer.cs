namespace STF_CharacterPlanner
{
    partial class CompBrowser
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
            this.ShipBrowseGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ShipBrowseGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ShipBrowseGrid
            // 
            this.ShipBrowseGrid.AllowUserToAddRows = false;
            this.ShipBrowseGrid.AllowUserToDeleteRows = false;
            this.ShipBrowseGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.ShipBrowseGrid.ColumnHeadersHeight = 50;
            this.ShipBrowseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ShipBrowseGrid.Location = new System.Drawing.Point(10, 10);
            this.ShipBrowseGrid.MaximumSize = new System.Drawing.Size(1140, 3000);
            this.ShipBrowseGrid.MinimumSize = new System.Drawing.Size(1140, 0);
            this.ShipBrowseGrid.Name = "ShipBrowseGrid";
            this.ShipBrowseGrid.ReadOnly = true;
            this.ShipBrowseGrid.RowTemplate.Height = 35;
            this.ShipBrowseGrid.Size = new System.Drawing.Size(1140, 517);
            this.ShipBrowseGrid.TabIndex = 3;
            // 
            // CompBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(152)))), ((int)(((byte)(221)))));
            this.Controls.Add(this.ShipBrowseGrid);
            this.Name = "CompBrowser";
            this.Size = new System.Drawing.Size(1160, 537);
            ((System.ComponentModel.ISupportInitialize)(this.ShipBrowseGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ShipBrowseGrid;
    }
}
