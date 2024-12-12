using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kiosk_movie
{
    public partial class Choice : Form
    {
        public Choice()
        {
            InitializeComponent();
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            Reserve reserve = new Reserve();
            reserve.Show();
            Close();
        }

        private void btnCombo_Click(object sender, EventArgs e)
        {
            Combo combo = new Combo();
            combo.Show();
            Close();
        }
    }
}
