using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123Assignment4
{
    public partial class formProduct : Form
    {
        public event EventHandler<ProductEventArgs> NewProductEvent;
       
        public formProduct()
        {
            InitializeComponent();
        }
        private void formProduct_Load(object sender, EventArgs e)
        {
            cbCategory.DataSource = Enum.GetValues(typeof(Department));
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            Product product = new Product(); 
            product.Name = txtName.Text;
            product.Department = (Department)Enum.Parse(typeof(Department), cbCategory.Text, true);
            product.Price = Convert.ToDecimal(numPrice.Value);
            NewProductEvent.Invoke(this, new ProductEventArgs(product));
      
        }

        
    }
}
