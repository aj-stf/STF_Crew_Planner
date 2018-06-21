namespace STF_CharacterPlanner
{
    partial class CrewInput
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.setAllCrewButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.setAllCrewBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(213)))), ((int)(((byte)(241)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(38, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Crew Job";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(213)))), ((int)(((byte)(241)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(135, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Num";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(213)))), ((int)(((byte)(241)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(177, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rank";
            // 
            // setAllCrewButton
            // 
            this.setAllCrewButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.setAllCrewButton.Location = new System.Drawing.Point(492, 73);
            this.setAllCrewButton.Name = "setAllCrewButton";
            this.setAllCrewButton.Size = new System.Drawing.Size(75, 23);
            this.setAllCrewButton.TabIndex = 3;
            this.setAllCrewButton.Text = "Set Crew";
            this.setAllCrewButton.UseVisualStyleBackColor = false;
            this.setAllCrewButton.Click += new System.EventHandler(this.setAllCrewButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(213)))), ((int)(((byte)(241)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(452, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Set All Crew to Rank";
            // 
            // setAllCrewBox
            // 
            this.setAllCrewBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.setAllCrewBox.FormattingEnabled = true;
            this.setAllCrewBox.Location = new System.Drawing.Point(446, 75);
            this.setAllCrewBox.Name = "setAllCrewBox";
            this.setAllCrewBox.Size = new System.Drawing.Size(40, 21);
            this.setAllCrewBox.TabIndex = 6;
            // 
            // CrewInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(152)))), ((int)(((byte)(221)))));
            this.Controls.Add(this.setAllCrewBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.setAllCrewButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CrewInput";
            this.Size = new System.Drawing.Size(680, 580);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button setAllCrewButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox setAllCrewBox;
    }
}
