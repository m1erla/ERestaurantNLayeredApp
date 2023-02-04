using ERestaurant.Business.Abstract;
using ERestaurant.DataAccess.Concrete.EntityFrameWork;
using ERestaurant.DataAccess.Concrete.NHibernate;
using ERestaurant.Business.Concrete;
using ERestaurant.Business.DependencyResolvers.Ninject;
using ERestaurant.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERestaurant.WebFormsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _productService = InstanceFactory.GetInstance<IProductService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        }
        private IProductService _productService;
        private ICategoryService _categoryService;
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadProducts();
        }

        private void LoadCategories()
        {
            cbxCategorySearch.DataSource = _categoryService.GetAll();
            cbxCategorySearch.DisplayMember = "CategoryName";
            cbxCategorySearch.ValueMember = "CategoryId";


            cbxCategoryIdAdd.DataSource = _categoryService.GetAll();
            cbxCategoryIdAdd.DisplayMember = "CategoryName";
            cbxCategoryIdAdd.ValueMember = "CategoryId";

            cbxCategoryIdUpdate.DataSource = _categoryService.GetAll();
            cbxCategoryIdUpdate.DisplayMember = "CategoryName";
            cbxCategoryIdUpdate.ValueMember = "CategoryId";
        }
        private void LoadProducts() 
        {
          dgwProduct.DataSource = _productService.GetAll();
        }

        private void cbxCategorySearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProduct.DataSource = _productService.GetProductByCategory(Convert.ToInt32(cbxCategorySearch.SelectedValue));
            }
            catch 
            {

               
            }
        }

        private void tbxProductNameSearch_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxProductNameSearch.Text))
            {
                dgwProduct.DataSource = _productService.GetProductByProductName(tbxProductNameSearch.Text);
            }
            else
            {
                LoadProducts();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Add(new Product 
                {
                  CategoryId = Convert.ToInt32(cbxCategoryIdAdd.SelectedValue),
                  ProductName = tbxProductNameAdd.Text,
                  QuantityPerUnit = tbxQuantityPerUnitAdd.Text,
                  UnitPrice = Convert.ToDecimal(tbxUnitPriceAdd.Text),
                  UnitsInStock = Convert.ToInt16(tbxStockAmountAdd.Text)
                });
                MessageBox.Show("Product registered!");
                LoadProducts();
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Update(new Product
                {
                    ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                    ProductName = tbxProductNameUpdate.Text,
                    CategoryId = Convert.ToInt32(cbxCategoryIdUpdate.SelectedValue),
                    UnitsInStock = Convert.ToInt16(tbxStockAmountUpdate.Text),
                    QuantityPerUnit = tbxQuantityPerUnitUpdate.Text,
                    UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text)
                });

                MessageBox.Show("Update Product!");
                LoadProducts();
            }
            
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
        }

      

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgwProduct.CurrentRow;
            tbxProductNameUpdate.Text = row.Cells[1].Value.ToString();
            cbxCategoryIdUpdate.SelectedValue = row.Cells[2].Value;
            tbxUnitPriceUpdate.Text = row.Cells[3].Value.ToString();
            tbxQuantityPerUnitUpdate.Text = row.Cells[4].Value.ToString();
            tbxStockAmountUpdate.Text = row.Cells[5].Value.ToString();

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _productService.Delete(new Product
            { ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value) });
            MessageBox.Show("Deleted Product!!!");
            LoadProducts();
        }
    }
}
