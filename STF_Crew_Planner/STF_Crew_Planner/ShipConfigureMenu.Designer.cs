namespace STF_CharacterPlanner
{
    partial class ShipConfigureMenu
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
            this.browseShipsButton = new System.Windows.Forms.Button();
            this.selectShipBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ShipBrowseGrid = new System.Windows.Forms.DataGridView();
            this.browseCompsButton = new System.Windows.Forms.Button();
            this.browseWeaponsBut = new System.Windows.Forms.Button();
            this.weaponDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ShipBrowseGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // browseShipsButton
            // 
            this.browseShipsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.browseShipsButton.Location = new System.Drawing.Point(333, 25);
            this.browseShipsButton.Name = "browseShipsButton";
            this.browseShipsButton.Size = new System.Drawing.Size(112, 23);
            this.browseShipsButton.TabIndex = 0;
            this.browseShipsButton.Text = "Browse Ships";
            this.browseShipsButton.UseVisualStyleBackColor = false;
            this.browseShipsButton.Click += new System.EventHandler(this.browseShipsButton_Click);
            // 
            // selectShipBox
            // 
            this.selectShipBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.selectShipBox.FormattingEnabled = true;
            this.selectShipBox.Location = new System.Drawing.Point(20, 25);
            this.selectShipBox.Name = "selectShipBox";
            this.selectShipBox.Size = new System.Drawing.Size(278, 21);
            this.selectShipBox.TabIndex = 1;
            this.selectShipBox.SelectedIndexChanged += new System.EventHandler(this.selectShipBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(213)))), ((int)(((byte)(241)))));
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Ship Base";
            // 
            // ShipBrowseGrid
            // 
            this.ShipBrowseGrid.AllowUserToAddRows = false;
            this.ShipBrowseGrid.AllowUserToDeleteRows = false;
            this.ShipBrowseGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.ShipBrowseGrid.ColumnHeadersHeight = 50;
            this.ShipBrowseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ShipBrowseGrid.Location = new System.Drawing.Point(10, 80);
            this.ShipBrowseGrid.MaximumSize = new System.Drawing.Size(1140, 3000);
            this.ShipBrowseGrid.MinimumSize = new System.Drawing.Size(1140, 0);
            this.ShipBrowseGrid.MultiSelect = false;
            this.ShipBrowseGrid.Name = "ShipBrowseGrid";
            this.ShipBrowseGrid.ReadOnly = true;
            this.ShipBrowseGrid.RowTemplate.Height = 50;
            this.ShipBrowseGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ShipBrowseGrid.Size = new System.Drawing.Size(1140, 100);
            this.ShipBrowseGrid.TabIndex = 3;
            // 
            // browseCompsButton
            // 
            this.browseCompsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.browseCompsButton.Location = new System.Drawing.Point(451, 25);
            this.browseCompsButton.Name = "browseCompsButton";
            this.browseCompsButton.Size = new System.Drawing.Size(112, 23);
            this.browseCompsButton.TabIndex = 4;
            this.browseCompsButton.Text = "Browse Components";
            this.browseCompsButton.UseVisualStyleBackColor = false;
            this.browseCompsButton.Click += new System.EventHandler(this.browseCompsButton_Click);
            // 
            // browseWeaponsBut
            // 
            this.browseWeaponsBut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.browseWeaponsBut.Location = new System.Drawing.Point(569, 25);
            this.browseWeaponsBut.Name = "browseWeaponsBut";
            this.browseWeaponsBut.Size = new System.Drawing.Size(112, 23);
            this.browseWeaponsBut.TabIndex = 5;
            this.browseWeaponsBut.Text = "Browse Weapons";
            this.browseWeaponsBut.UseVisualStyleBackColor = false;
            this.browseWeaponsBut.Click += new System.EventHandler(this.browseWeaponsBut_Click);
            // 
            // weaponDataGrid
            // 
            this.weaponDataGrid.AllowUserToAddRows = false;
            this.weaponDataGrid.AllowUserToDeleteRows = false;
            this.weaponDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.weaponDataGrid.ColumnHeadersHeight = 50;
            this.weaponDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.weaponDataGrid.Location = new System.Drawing.Point(10, 186);
            this.weaponDataGrid.MaximumSize = new System.Drawing.Size(1140, 3000);
            this.weaponDataGrid.MinimumSize = new System.Drawing.Size(1140, 0);
            this.weaponDataGrid.Name = "weaponDataGrid";
            this.weaponDataGrid.ReadOnly = true;
            this.weaponDataGrid.RowTemplate.Height = 35;
            this.weaponDataGrid.Size = new System.Drawing.Size(1140, 194);
            this.weaponDataGrid.TabIndex = 6;
            // 
            // ShipConfigureMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(152)))), ((int)(((byte)(221)))));
            this.Controls.Add(this.weaponDataGrid);
            this.Controls.Add(this.browseWeaponsBut);
            this.Controls.Add(this.browseCompsButton);
            this.Controls.Add(this.ShipBrowseGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectShipBox);
            this.Controls.Add(this.browseShipsButton);
            this.Name = "ShipConfigureMenu";
            this.Size = new System.Drawing.Size(1160, 390);
            ((System.ComponentModel.ISupportInitialize)(this.ShipBrowseGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browseShipsButton;
        private System.Windows.Forms.ComboBox selectShipBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView ShipBrowseGrid;
        private System.Windows.Forms.Button browseCompsButton;
        private System.Windows.Forms.Button browseWeaponsBut;
        private System.Windows.Forms.DataGridView weaponDataGrid;
    }
}
