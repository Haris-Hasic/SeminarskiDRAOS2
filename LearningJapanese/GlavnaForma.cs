using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningJapanese
{
    public partial class GlavnaForma : Form
    {
        public GlavnaForma()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (username_tb.Text.Equals("admin") && password_tb.Text.Equals("admin"))
                tabControl1.SelectedIndex = 1;

            ocistiKontrole();
        }

        void ocistiKontrole()
        {
            username_tb.Text = "";
            password_tb.Text = "";
        }
    }
}
