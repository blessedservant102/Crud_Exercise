using CRUD_WEBFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_WEBFORM.Form
{
    public partial class ViewProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadProductDetails();
        }

        private void LoadProductDetails()
        {
            int productId= (int)Session["Id"];
            using (var db = new dbCrudWebFormEntities())
            {

                var product = (from p in db.Products
                               join c in db.Categories on p.CategoryId equals c.Id
                               where p.Id == productId
                               select new ProductModel
                               {
                                   Id = p.Id,
                                   CategoryId = c.Id,
                                   CategoryName = c.CategoryName,
                                   Name = p.Name,
                                   Description = p.Description,
                                   Image = p.Image
                               }).FirstOrDefault();
                if (product != null)
                {
                    lblId.Text = product.Id.ToString();
                    lblCategory.Text = product.CategoryName;
                    lblProductName.Text = product.Name;
                    lblDescription.Text = product.Description;
                    txtImage.ImageUrl = "~/ImageHandler.ashx?ProductId=" + productId;

                }
            }
        }


        protected void CloseForm(object sender, EventArgs e)
        {

            Response.Redirect("~/Product.aspx", false);
        }
    }
}