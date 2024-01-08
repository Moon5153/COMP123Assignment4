using System;
using System.IO;
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
    public partial class formCatalog : Form
    {

        Catalog catalog;
        int timerCount = 0;
        int previousSaveCount = 0;

        public formCatalog()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePath.Text;
            if (!File.Exists(filePath))
            { 
                MessageBox.Show("No such file exists in the given path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                catalog = new Catalog();
                catalog = DataStore.Load(filePath); 
                dgvCatalog.DataSource = catalog.GetAllProducts();
           
            }
        }
        private void chkAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoSave.Checked == true)
            {
                timer.Start();
               
            }
            else
            {
                timer.Stop();
                timerCount = 0;
            }
                
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            timerCount++;
        }
        private void dgvCatalog_DataSourceChanged(object sender, EventArgs e)
        {
            decimal saveCount = numFrequency.Value;
            
            if (chkAutoSave.Checked==true&&timerCount >= saveCount&&(timerCount>=(saveCount+previousSaveCount)))
            {
                DataStore.Save(catalog, txtFilePath.Text);
                previousSaveCount = timerCount;
            }

        }

        private void btnCreateProduct_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePath.Text;
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Load a file first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (formProduct form2 = new formProduct())
                {
                    form2.NewProductEvent += Form2_NewProductEvent;
                    form2.ShowDialog();
                }
            }
            
                
        }

        private void Form2_NewProductEvent(object sender, ProductEventArgs e)
        {
            var product = e.NewProduct;
            catalog.Add(product);
            dgvCatalog.DataSource = null;
            dgvCatalog.DataSource = catalog.GetAllProducts();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string filter = txtFilter.Text;
            string filePath = txtFilePath.Text;
            if (!File.Exists(filePath))
            {              
                MessageBox.Show("Load a file first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    dgvCatalog.DataSource = catalog.GetProducts(filter);
                }
                else
                {
                    dgvCatalog.DataSource = catalog.GetAllProducts();
                }
            }
            
        }
       

        

       
    }
}
