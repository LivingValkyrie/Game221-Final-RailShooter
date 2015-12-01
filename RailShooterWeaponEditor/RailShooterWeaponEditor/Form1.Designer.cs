namespace RailShooterWeaponEditor {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.button_export = new System.Windows.Forms.Button();
            this.numericUpDown_manaCost = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_cost = new System.Windows.Forms.Label();
            this.label_range = new System.Windows.Forms.Label();
            this.label_damage = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label_name = new System.Windows.Forms.Label();
            this.numericUpDown_range = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_damage = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_zoom = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_castSpeed = new System.Windows.Forms.NumericUpDown();
            this.label_zoom = new System.Windows.Forms.Label();
            this.label_castSpeed = new System.Windows.Forms.Label();
            this.label_recharge = new System.Windows.Forms.Label();
            this.numericUpDown_recharge = new System.Windows.Forms.NumericUpDown();
            this.label_precision = new System.Windows.Forms.Label();
            this.checkBox_Precision = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_manaCost)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_range)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_damage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_zoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_castSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_recharge)).BeginInit();
            this.SuspendLayout();
            // 
            // button_export
            // 
            this.button_export.Location = new System.Drawing.Point(211, 400);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(255, 72);
            this.button_export.TabIndex = 0;
            this.button_export.Text = "Export";
            this.button_export.UseVisualStyleBackColor = true;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // numericUpDown_manaCost
            // 
            this.numericUpDown_manaCost.DecimalPlaces = 1;
            this.numericUpDown_manaCost.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_manaCost.Location = new System.Drawing.Point(188, 178);
            this.numericUpDown_manaCost.Name = "numericUpDown_manaCost";
            this.numericUpDown_manaCost.Size = new System.Drawing.Size(120, 31);
            this.numericUpDown_manaCost.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(677, 40);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(77, 36);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // label_cost
            // 
            this.label_cost.AutoSize = true;
            this.label_cost.Location = new System.Drawing.Point(11, 183);
            this.label_cost.Name = "label_cost";
            this.label_cost.Size = new System.Drawing.Size(116, 25);
            this.label_cost.TabIndex = 5;
            this.label_cost.Text = "Mana Cost";
            // 
            // label_range
            // 
            this.label_range.AutoSize = true;
            this.label_range.Location = new System.Drawing.Point(11, 252);
            this.label_range.Name = "label_range";
            this.label_range.Size = new System.Drawing.Size(75, 25);
            this.label_range.TabIndex = 6;
            this.label_range.Text = "Range";
            // 
            // label_damage
            // 
            this.label_damage.AutoSize = true;
            this.label_damage.Location = new System.Drawing.Point(11, 325);
            this.label_damage.Name = "label_damage";
            this.label_damage.Size = new System.Drawing.Size(92, 25);
            this.label_damage.TabIndex = 7;
            this.label_damage.Text = "Damage";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(12, 105);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(298, 31);
            this.textBox_name.TabIndex = 8;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(11, 63);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(122, 25);
            this.label_name.TabIndex = 9;
            this.label_name.Text = "Spell Name";
            // 
            // numericUpDown_range
            // 
            this.numericUpDown_range.DecimalPlaces = 1;
            this.numericUpDown_range.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_range.Location = new System.Drawing.Point(188, 252);
            this.numericUpDown_range.Name = "numericUpDown_range";
            this.numericUpDown_range.Size = new System.Drawing.Size(120, 31);
            this.numericUpDown_range.TabIndex = 10;
            // 
            // numericUpDown_damage
            // 
            this.numericUpDown_damage.DecimalPlaces = 1;
            this.numericUpDown_damage.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_damage.Location = new System.Drawing.Point(188, 319);
            this.numericUpDown_damage.Name = "numericUpDown_damage";
            this.numericUpDown_damage.Size = new System.Drawing.Size(120, 31);
            this.numericUpDown_damage.TabIndex = 11;
            // 
            // numericUpDown_zoom
            // 
            this.numericUpDown_zoom.DecimalPlaces = 1;
            this.numericUpDown_zoom.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_zoom.Location = new System.Drawing.Point(536, 319);
            this.numericUpDown_zoom.Name = "numericUpDown_zoom";
            this.numericUpDown_zoom.Size = new System.Drawing.Size(120, 31);
            this.numericUpDown_zoom.TabIndex = 17;
            // 
            // numericUpDown_castSpeed
            // 
            this.numericUpDown_castSpeed.DecimalPlaces = 1;
            this.numericUpDown_castSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_castSpeed.Location = new System.Drawing.Point(536, 252);
            this.numericUpDown_castSpeed.Name = "numericUpDown_castSpeed";
            this.numericUpDown_castSpeed.Size = new System.Drawing.Size(120, 31);
            this.numericUpDown_castSpeed.TabIndex = 16;
            // 
            // label_zoom
            // 
            this.label_zoom.AutoSize = true;
            this.label_zoom.Location = new System.Drawing.Point(342, 325);
            this.label_zoom.Name = "label_zoom";
            this.label_zoom.Size = new System.Drawing.Size(66, 25);
            this.label_zoom.TabIndex = 15;
            this.label_zoom.Text = "Zoom";
            // 
            // label_castSpeed
            // 
            this.label_castSpeed.AutoSize = true;
            this.label_castSpeed.Location = new System.Drawing.Point(342, 252);
            this.label_castSpeed.Name = "label_castSpeed";
            this.label_castSpeed.Size = new System.Drawing.Size(124, 25);
            this.label_castSpeed.TabIndex = 14;
            this.label_castSpeed.Text = "Cast Speed";
            // 
            // label_recharge
            // 
            this.label_recharge.AutoSize = true;
            this.label_recharge.Location = new System.Drawing.Point(342, 183);
            this.label_recharge.Name = "label_recharge";
            this.label_recharge.Size = new System.Drawing.Size(173, 25);
            this.label_recharge.TabIndex = 13;
            this.label_recharge.Text = "Recharge Speed";
            // 
            // numericUpDown_recharge
            // 
            this.numericUpDown_recharge.DecimalPlaces = 1;
            this.numericUpDown_recharge.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_recharge.Location = new System.Drawing.Point(536, 178);
            this.numericUpDown_recharge.Name = "numericUpDown_recharge";
            this.numericUpDown_recharge.Size = new System.Drawing.Size(120, 31);
            this.numericUpDown_recharge.TabIndex = 12;
            // 
            // label_precision
            // 
            this.label_precision.AutoSize = true;
            this.label_precision.Location = new System.Drawing.Point(342, 111);
            this.label_precision.Name = "label_precision";
            this.label_precision.Size = new System.Drawing.Size(101, 25);
            this.label_precision.TabIndex = 18;
            this.label_precision.Text = "Precision";
            // 
            // checkBox_Precision
            // 
            this.checkBox_Precision.AutoSize = true;
            this.checkBox_Precision.Location = new System.Drawing.Point(628, 105);
            this.checkBox_Precision.Name = "checkBox_Precision";
            this.checkBox_Precision.Size = new System.Drawing.Size(28, 27);
            this.checkBox_Precision.TabIndex = 19;
            this.checkBox_Precision.UseVisualStyleBackColor = true;
            this.checkBox_Precision.CheckedChanged += new System.EventHandler(this.checkBox_Precision_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 484);
            this.Controls.Add(this.checkBox_Precision);
            this.Controls.Add(this.label_precision);
            this.Controls.Add(this.numericUpDown_zoom);
            this.Controls.Add(this.numericUpDown_castSpeed);
            this.Controls.Add(this.label_zoom);
            this.Controls.Add(this.label_castSpeed);
            this.Controls.Add(this.label_recharge);
            this.Controls.Add(this.numericUpDown_recharge);
            this.Controls.Add(this.numericUpDown_damage);
            this.Controls.Add(this.numericUpDown_range);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label_damage);
            this.Controls.Add(this.label_range);
            this.Controls.Add(this.label_cost);
            this.Controls.Add(this.numericUpDown_manaCost);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Rail Shooter Weapon Builder";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_manaCost)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_range)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_damage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_zoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_castSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_recharge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_export;
        private System.Windows.Forms.NumericUpDown numericUpDown_manaCost;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label label_cost;
        private System.Windows.Forms.Label label_range;
        private System.Windows.Forms.Label label_damage;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.NumericUpDown numericUpDown_range;
        private System.Windows.Forms.NumericUpDown numericUpDown_damage;
        private System.Windows.Forms.NumericUpDown numericUpDown_zoom;
        private System.Windows.Forms.NumericUpDown numericUpDown_castSpeed;
        private System.Windows.Forms.Label label_zoom;
        private System.Windows.Forms.Label label_castSpeed;
        private System.Windows.Forms.Label label_recharge;
        private System.Windows.Forms.NumericUpDown numericUpDown_recharge;
        private System.Windows.Forms.Label label_precision;
        private System.Windows.Forms.CheckBox checkBox_Precision;
    }
}

