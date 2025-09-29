using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bike
{
    public partial class ListaCategorii : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void bttnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string newCategoryName = txtCategoryName.Text;  
            DbCategorii dbCategorii = new DbCategorii();
            string insertedCategoryName = dbCategorii.InsertCategory(newCategoryName);
        }
        private void LoadData()
        {
            DbCategorii dbUtils = new DbCategorii();
            List<DbCategorii.Categorii> categories = dbUtils.GetCategories(txtSearch.Text);
            gridCategorii.DataSource = categories;
            gridCategorii.DataBind();
        }
    }
}