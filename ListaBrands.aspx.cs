using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bike
{
    public partial class ListaBrands : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void bttnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            DataBaseUtilities dbUtils = new DataBaseUtilities();
            List<brand> brands = dbUtils.GetBrands(txtSearch.Text);
            gridBrands.DataSource = brands;
            gridBrands.DataBind();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string newBrandName = txtBrandName.Text;
            DbBrands dbBrands = new DbBrands();
            string insertedBrandName=dbBrands.InsertBrand(newBrandName);
        }
    }
}