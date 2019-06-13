using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Communicator
{
    public partial class ConnectionPrompt : Form
    {
        public ConnectionPrompt(String username)
        {
            InitializeComponent();
            user_nickname_label.Text = username;
        }

        private void Yes_button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void No_button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
