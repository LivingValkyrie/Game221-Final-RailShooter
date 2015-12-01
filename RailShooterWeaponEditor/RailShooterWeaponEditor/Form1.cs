using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailShooterWeaponEditor {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            Init();
        }

        void Init() {
            numericUpDown_zoom.Visible = false;
            label_zoom.Visible = false;
        }

        #region Event Handlers

        private void checkBox_Precision_CheckedChanged( object sender, EventArgs e ) {
            if (checkBox_Precision.Checked) {
                numericUpDown_zoom.Visible = true;
                label_zoom.Visible = true;
            } else {
                numericUpDown_zoom.Visible = false;
                label_zoom.Visible = false;
            }
        }

        private void button_export_Click( object sender, EventArgs e ) {
           // Export();
        }

        #endregion

        void Export() {
            using (StreamWriter sw = new StreamWriter("../exports/" + textBox_name.Text + ".txt")) {
                sw.WriteLine("test");
            }
        }

    }
}
