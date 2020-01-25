using CRUD_WEBFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_WEBFORM.Form
{
    public partial class AddProduct : System.Web.UI.Page
    {
        private string trans = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            trans = (string)Session["TransactionType"];
            //if (Request.QueryString["TransactionType"] != null)
            //    trans = Request.QueryString["TransactionType"].ToString();

            LoadDataDropDown();
        }

        private void LoadDetails(string transType)
        {


                if (transType !="NewProduct" && transType !="")
                {
                    //diplaying details for updating product info;
                    btnAdd.Text = "Update";
                    txtTransactionType.Text = "Edit Product";
                    int id = (int)Session["Id"];
                    txtId.Text = id.ToString();
                    using (var db = new dbCrudWebFormEntities())
                    {

                       var product= (from p in db.Products
                         join c in db.Categories on p.CategoryId equals c.Id where p.Id == id
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
                            CategoryDropDownList.SelectedValue = product.CategoryId.ToString();


                            txtProductName.Text = product.Name;
                            txtDescription.Text = product.Description;
                            txtImage.ImageUrl= "~/ImageHandler.ashx?ProductId=" + id;

                        }
                    }


                    }
                else
                {
                    btnAdd.Text = "Save";
                }

            
        }

        private void LoadDataDropDown()
        {
            if (CategoryDropDownList.Items.Count == 0)
            {
                using (var context = new dbCrudWebFormEntities())
                {
                    var allCategory = (from c in context.Categories
                                       select c).ToList();


                    CategoryDropDownList.DataSource = allCategory;
                    CategoryDropDownList.DataBind();
                    CategoryDropDownList.Visible = true;
                }


                LoadDetails(trans);

            }

        }

        protected void SaveUpdateProduct(object sender, EventArgs e)
        {
            
            if (btnAdd.Text == "Save")
            {
                if (FileUpload1.HasFile)
                {
                    int imagefilelenth = FileUpload1.PostedFile.ContentLength;
                    byte[] imgarray = new byte[imagefilelenth];
                    HttpPostedFile image = FileUpload1.PostedFile;
                    image.InputStream.Read(imgarray, 0, imagefilelenth);


                    using (dbCrudWebFormEntities entities = new dbCrudWebFormEntities())
                    {
                        var categoryId = Convert.ToInt32(CategoryDropDownList.SelectedValue); 
                        Product product = new Product
                        {
                            CategoryId = categoryId,
                            Name = txtProductName.Text,
                            Description = txtDescription.Text,
                            Image = imgarray

                        };
                        entities.Products.Add(product);
                        entities.SaveChanges();
                        Response.Redirect("~/Product.aspx?", false);
                    }

                }
            }
            else
            {  //Updating the Production Details
                using (dbCrudWebFormEntities entities = new dbCrudWebFormEntities())
                {
                    var categoryId = Convert.ToInt32(CategoryDropDownList.SelectedValue); 
                    int id = Convert.ToInt32(txtId.Text);
                    Product product = (from c in entities.Products
                                         where c.Id == id
                                         select c).FirstOrDefault();
                    if (product != null)
                    {
                        if (FileUpload1.HasFile)
                        {
                            int imagefilelenth = FileUpload1.PostedFile.ContentLength;
                            byte[] imgarray = new byte[imagefilelenth];
                            HttpPostedFile image = FileUpload1.PostedFile;
                            image.InputStream.Read(imgarray, 0, imagefilelenth);
                            product.Image = imgarray;
                        }
                        product.CategoryId = categoryId;
                        product.Name = txtProductName.Text;
                        product.Description = txtDescription.Text;

                    }
                    entities.SaveChanges();
                    Response.Redirect("~/Product.aspx?", false);
                }

            }


            
        }

        protected void CloseForm(object sender, EventArgs e)
        {
            //Response.Redirect("userHome.aspx");
            Response.Redirect("~/Product.aspx?", false);
        }

    }
}