using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_WEBFORM
{
    public partial class Category1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            GridLoad();
        }

        private void GridLoad()
        {
            using (var ctx = new dbCrudWebFormEntities())
            {
                var categories = ctx.Categories.ToList();
                Gridview1.DataSource = categories;
                Gridview1.DataBind();
            }

            //using (dbCrudWebFormEntities entities = new dbCrudWebFormEntities())
            //{
            //    Gridview1.DataSource = from category in entities.Categories
            //                           select category;
            //    //GridLoad();
            //}




        }
        protected void Edit_Click(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            txtId.Text = categoryId.ToString();
            using (var db = new dbCrudWebFormEntities())
            {
                var category = (from p in db.Categories
                               where p.Id == categoryId select p).FirstOrDefault();
                if (category != null)
                {
                    txtCategoryName.Text = category.CategoryName;

                }
            }
            btnAdd.Text = "Update";
            btnCancel.Visible = true;
        }

        protected void CancelUpdate(object sender, EventArgs e)
        {
            btnAdd.Text = "Add";
            btnCancel.Visible = false;
            txtCategoryName.Text = "";
            txtId.Text = "0";
        }


    protected void InsertUpdate(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Add")
            {
                using (dbCrudWebFormEntities entities = new dbCrudWebFormEntities())
                {
                    Category category = new Category
                    {
                        CategoryName = txtCategoryName.Text

                    };
                    entities.Categories.Add(category);
                    entities.SaveChanges();
                }
            }
            else
            {
                int categoryId = Convert.ToInt32(txtId.Text);
                using (dbCrudWebFormEntities entities = new dbCrudWebFormEntities())
                {
                    Category category = (from c in entities.Categories
                                         where c.Id == categoryId
                                         select c).FirstOrDefault();
                    if (category != null)
                    {
                        category.CategoryName = txtCategoryName.Text;
                    }
                    entities.SaveChanges();
                }
            }
            txtId.Text = "0";
            btnAdd.Text = "Add";
            txtCategoryName.Text = "";
            btnCancel.Visible = false;
            this.GridLoad();
        }

        protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Gridview1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gridview1.EditIndex = e.NewEditIndex;
            this.DataBind();

        }

        protected void Gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = Gridview1.Rows[e.RowIndex];
            
            int categoryId = Convert.ToInt32(Gridview1.DataKeys[e.RowIndex].Values[0]);
            //int categoryId = Convert.ToInt32((row.FindControl("lblCategoryId") as Label).Text);
            string categoryname =  (row.FindControl("txtCategoryName") as TextBox).Text;
            using (dbCrudWebFormEntities entities = new dbCrudWebFormEntities())
            {
                Category category = (from c in entities.Categories
                                     where c.Id == categoryId
                                     select c).FirstOrDefault();
                if (category != null)
                {
                    category.CategoryName = categoryname;
                }
                entities.SaveChanges();
            }
            this.DataBind();
            Gridview1.EditIndex = -1;
            GridLoad();
        }

        protected void Gridview1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gridview1.EditIndex = -1;
            this.DataBind();

        }

        protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != Gridview1.EditIndex)
            //{
            //    (e.Row.Cells[2].Controls[1] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            //}

        }

        protected void Gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = Gridview1.Rows[e.RowIndex];
            // int categoryId = Convert.ToInt32((row.FindControl("lblCategoryId") as Label).Text);
            int categoryId = Convert.ToInt32(Gridview1.DataKeys[e.RowIndex].Values[0]);

            //int categoryId = Convert.ToInt32((row.FindControl("lblCategoryId") as Label).Text);
            using (dbCrudWebFormEntities entities = new dbCrudWebFormEntities())
            {
                Category category = (from c in entities.Categories
                                     where c.Id == categoryId
                                     select c).FirstOrDefault();
                entities.Categories.Remove(category);
                entities.SaveChanges();
            }
            GridLoad();

        }

        protected void Gridview1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            
        }
    }
}