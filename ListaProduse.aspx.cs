using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

namespace bike
{
    public partial class ListaProduse : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                PopulateBrands(ddlBrandAdd);
                PopulateCategories(ddlCategoryAdd);
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            DataBaseUtilities dbUtils = new DataBaseUtilities();
            List<MyProduct> products = dbUtils.GetProducts4(txtSearch.Text);
            GridView1.DataSource = products;
            GridView1.DataBind();
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            LoadData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            LoadData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var productID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string newProductName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtProductName")).Text;

            UpdateProduct(productID, newProductName);

            GridView1.EditIndex = -1;
            LoadData();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                GridView1.EditIndex = -1;
                LoadData();
            }
        }
        public void UpdateProduct(int productID, string newProductName)
        {
            using (bikeStoresEntities context = new bikeStoresEntities())
            {
                var product = context.products.Find(productID);

                if (product != null)
                {
                    product.product_name = newProductName;

                    context.Entry(product).State = EntityState.Modified;

                    context.SaveChanges();
                }
            }
        }

        private void PopulateBrands(DropDownList cmb)
        {
            DataBaseUtilities Utils = new DataBaseUtilities();
            var brands = Utils.GetBrands("");
            cmb.Items.Clear();
            foreach (var brand in brands)
            {
                cmb.Items.Add(new ListItem(brand.brand_name, brand.brand_id.ToString()));
            }
        }

        private void PopulateCategories(DropDownList cmb)
        {
            DataBaseUtilities Utils = new DataBaseUtilities();
            var categories = new DbCategorii().GetCategories("");
            cmb.Items.Clear();
            foreach (var cat in categories)
            {
                cmb.Items.Add(new ListItem(cat.category_name, cat.category_id.ToString()));
            }
        }
        public void InsertNewProduct(string productName, int modelYear, decimal listPrice, int brandId, int categoryId)
        {
            using (bikeStoresEntities context = new bikeStoresEntities())
            {
                var newProduct = new product
                {
                    product_name = productName,
                    model_year = (short)modelYear,
                    list_price = listPrice,
                    brand_id = brandId,
                    category_id = categoryId
                };

                context.products.Add(newProduct);
                context.SaveChanges();
            }
        }
        protected void btnSaveAddProduct_Click(object sender, EventArgs e)
        {
            string product_name = txtProductNameAdd.Text;
            int model_year;
            decimal list_price;
            int brand_id;
            int category_id;

            if (int.TryParse(txtModelYearAdd.Text, out model_year) &&
                decimal.TryParse(txtPriceAdd.Text, out list_price) &&
                int.TryParse(ddlBrandAdd.SelectedValue, out brand_id) &&
                int.TryParse(ddlCategoryAdd.SelectedValue, out category_id) &&
                !string.IsNullOrEmpty(product_name))
            {
                InsertNewProduct(product_name, model_year, list_price, brand_id, category_id);

                hideAddPopup();

                LoadData();
            }
            else
            {
                lblErrorMessage.Text = "Invalid data. Please ensure that year and price are numbers, and all fields are filled.";
                lblErrorMessage.Visible = true;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            int rowIndex = Convert.ToInt32(btnDelete.CommandArgument);

           // int rowIndex = int.Parse(e.CommandArgument.ToString());
            string val = this.GridView1.DataKeys[rowIndex]["product_id"].ToString();

            GridView1.Rows[rowIndex].Visible = false;
            Session["LastDeletedRowIndex"] = rowIndex;
            btnUndo.Visible = true;
        }

        protected void btnUndo_Click(object sender, EventArgs e)
        {
            if (Session["LastDeletedRowIndex"] != null)
            {
                int rowIndex = (int)Session["LastDeletedRowIndex"];
                GridView1.Rows[rowIndex].Visible = true;
                btnUndo.Visible = false;
            }
        }

        private void hideAddPopup()
        {
            addProductModal.Hide();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            addProductModal.Show();
        }

        protected void btnCancelAddProduct_Click(object sender, EventArgs e)
        {
            hideAddPopup();
        }

        protected void btnCancelEditProduct_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
