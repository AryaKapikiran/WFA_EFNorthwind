using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_EFNorthwind.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        NorthWindEntities1 db = new NorthWindEntities1();

        private void button1_Click(object sender, EventArgs e)
        {
            //User user = new User();
            //user.UserName = "admin";
            //user.Password = "123";

            //if (txtusername.Text == user.UserName && txtpassword.Text == user.Password)
            //{
            //    MessageBox.Show("Hoşgeldin admin");
            //    Form1 form1 = new Form1();
            //    form1.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("admin degilseniz giriş yapamazsınız");
            //}
            //List<User> users = db.Users.Where(x=>x.UserName == txtusername.Text && x.Password == txtpassword.Text).ToList();

            foreach(User user in db.Users)
            {
                if (user.UserName== txtusername.Text && user.Password== txtpassword.Text)
                {
                    MessageBox.Show("Hoşgeldin admin");
                     Form1 form1 = new Form1();
                      form1.Show();
                       this.Hide();

                }
                    
                else
                {
                    MessageBox.Show("admin degilseniz giriş yapamazsınız");
                }
                 break;

            }
            
        }
    }
}
