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
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        NorthWindEntities1 db = new NorthWindEntities1();

        private void ReportForm_Load(object sender, EventArgs e)
        {
            //1-hangi kategoride kac adet ürün vardır.
            //T-SQL
            //select CategoryName,count(ProductID) as 'Urun Adedi' from Categories c join Products p on p.CategoryID=c.CategoryID group by c.CategoryName

            //listeleme

            foreach (Category category in db.Categories)
            {
              

                listBox1.Items.Add(category.CategoryName + " " + category.Products.Count());
            }

            //2-calısanların almıs oldukları siparis sayıları

            //T-Sql
            //select e.FirstName,count(OrderID) from Orders o join Employees e on e.EmployeeID=o.EmployeeID group by e.FirstName
            //Listeleme

            foreach(Employee employee in db.Employees)
            {
               

                listBox2.Items.Add(employee.FirstName + " " + employee.Orders.Count());
               
            }

            //3-Ulkeye göre calısan sayısı
            //T-sql
           // select Country, COUNT(EmployeeID) from Employees group by Country

            //Listeleme

            foreach(Employee employee in db.Employees)
            {
                if (employee.Employees1.Count>0)
                {
                    listBox3.Items.Add(employee.Country + " " + employee.Employees1.Count());

                }
                
            }

            
        




        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            //tarihe göre siparisler
             
            List<Order> orders =db.Orders.Where(o => o.OrderDate >dateTimePicker1.Value && o.OrderDate<dateTimePicker2.Value).ToList();
            foreach(Order order in orders)
            {
                listBox4.Items.Add(order.OrderDate + " " + order.OrderID);
            }
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            
            listBox5.Items.Clear();
            //text boxtan alacagımız calısan adina gore siparisler
            List<Order> orders = db.Orders.Where(x => x.Employee.FirstName == textBox1.Text).ToList();
            foreach (Order order in orders)
            {
                listBox5.Items.Add(order.OrderID);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //numericten alacAagımız min ve max degerlerle Fiyata göre ürün listeleme 
            listBox6.Items.Clear();
            List<Product> products = db.Products.Where(x=> x.UnitPrice >numericUpDown1.Value && x.UnitPrice <numericUpDown2.Value).ToList();

            foreach(Product product in products)
            {
                listBox6.Items.Add(product.ProductName + " " + product.UnitPrice);
            }


            
        }
    }
}
