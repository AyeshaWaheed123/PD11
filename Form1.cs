using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace pd11
{
    public partial class Form1 : Form
    {
        List<Product> products = new List<Product>();

        public Form1()
        {
            InitializeComponent();
            LoadProducts();
            BindData();
        }

        private void LoadProducts()
        {
            products.Add(new Product { Name = "Shirt", Price = 9.95m, Quantity = 5 });
            products.Add(new Product { Name = "Shoes", Price = 19.95m, Quantity = 1 });
            products.Add(new Product { Name = "Pants", Price = 14.95m, Quantity = 2 });
        }

        private void BindData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = products;
        }

        private void btnUpdateCart_Click(object sender, EventArgs e)
        {
        
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.DataBoundItem is Product product)
                {
                    int qty;
                    if (int.TryParse(row.Cells["Quantity"].Value?.ToString(), out qty))
                    {
                        product.Quantity = qty;
                    }
                }
            }

          
            dataGridView1.Refresh();

            
            decimal grandTotal = products.Sum(p => p.Total);
           label3.Text = $"Total: ${grandTotal:F2}";
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total => Price * Quantity;
    }
}
