using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuckMan {
    public partial class EndGameForm : Form {
        private Form1 _form1;

        public EndGameForm(Form1 form1, bool isWin) {
            this._form1 = form1;
            InitializeComponent();
            if (isWin) {
                labelWin.Visible = true;
                labelLost.Visible = false;
            } else {
                labelWin.Visible = false;
                labelLost.Visible = true;
            }
                

            _form1.Hide();
        }

        private void buttonRepeat_Click(object sender, EventArgs e) {
            _form1.ReinitForm();
            _form1.Show();
            this.Close();
        }
    }
}
