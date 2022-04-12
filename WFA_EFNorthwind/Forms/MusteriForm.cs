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
    public partial class MusteriForm : Form
    {
        public MusteriForm()
        {
            InitializeComponent();
        }
        NorthWindEntities1 db =new NorthWindEntities1();

        private void MusteriListele()
        {
            foreach (Customer customer in db.Customers)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = customer.CustomerID;
                lvi.SubItems.Add(customer.CompanyName);
                listView1.Items.Add(lvi);
            }
        }
        private void MusteriForm_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            MusteriListele();

           
        }
        private void AddCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            MessageBox.Show(customer.CompanyName + " eklendi");
            MusteriListele();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            Customer c = new Customer();
            c.CustomerID = txtcId.Text;
            c.CompanyName = txtCname.Text;
            
            AddCustomer(c);


        }
    }
}
