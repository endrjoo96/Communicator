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
    public partial class EnterNameForm : Form
    {
        public String result = null;

        public EnterNameForm()
        {
            InitializeComponent();
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            User[] users = SelectWindow.GetCurrentGuests();
            if (users != null){
                foreach (User usr in users)
                {
                    if (usr.Nickname.ToLower().Equals(TextBox_Name.Text.ToLower()))
                    {
                        return;
                    }
                }
            }
            result = TextBox_Name.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
