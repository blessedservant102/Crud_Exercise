using CRUD_WEBFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_WEBFORM
{
    public partial class Product1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadProductList();
        }

        private void LoadProductList()
        {
            using (var ctx = new dbCrudWebFormEntities())
            {
                
                List<ProductModel> productList = new List<ProductModel>();

                var product = (from p in ctx.Products
                               join c in ctx.Categories on p.CategoryId equals c.Id
                               select new ProductModel
                               {
                                   Id = p.Id,
                                   CategoryId = c.Id,
                                   CategoryName = c.CategoryName,
                                   Name = p.Name,
                                   Description = p.Description,
                                   Image = p.Image
                               }).ToList();

                productList = product;

                ProductGrid.DataSource = productList;
                ProductGrid.DataBind();

            }
            Session["TransactionType"] = "NewProduct";


        }


        protected void Edit_Click(object sender, EventArgs e)
        {
            
            int productId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Session["Id"] = productId;
            Session["TransactionType"] = "Edit Product";
            Response.Redirect("~/Form/AddProduct.aspx", false);
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
           (sender as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";


            int productId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            using (dbCrudWebFormEntities entities = new dbCrudWebFormEntities())
            {
                Product product = (from c in entities.Products
                                   where c.Id == productId
                                   select c).FirstOrDefault();
                entities.Products.Remove(product);
                entities.SaveChanges();
            }
            LoadProductList();

        }

        protected void Detials_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Session["Id"] = productId;
            Response.Redirect("~/Form/ViewProduct.aspx", false);
        }

        //protected void ProductGrid_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    GridViewRow row = ProductGrid.Rows[e];

        //    int categoryId = Convert.ToInt32(Gridview1.DataKeys[e.RowIndex].Values[0]);


        //}

        //protected void ProductGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{

        //}

        //protected void ProductGrid_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //protected void ProductGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != ProductGrid.EditIndex)
        //    {
        //        (e.Row.Cells[1].Controls[1] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
        //    }
        //}

        //protected void ProductGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    GridViewRow row = ProductGrid.Rows[e.RowIndex];
        //    // int categoryId = Convert.ToInt32((row.FindControl("lblCategoryId") as Label).Text);
        //    int productId = Convert.ToInt32(ProductGrid.DataKeys[e.RowIndex].Values[0]);

        //    //int categoryId = Convert.ToInt32((row.FindControl("lblCategoryId") as Label).Text);
        //    using (dbCrudWebFormEntities entities = new dbCrudWebFormEntities())
        //    {
        //        Product product = (from c in entities.Products
        //                             where c.Id == productId
        //                             select c).FirstOrDefault();
        //        entities.Products.Remove(product);
        //        entities.SaveChanges();
        //    }
        //    LoadProductList();
        //}
    }
}