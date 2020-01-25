using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace CRUD_WEBFORM
{
    /// <summary>
    /// Summary description for imagehandler
    /// </summary>
    public class imagehandler : IHttpHandler
    {


        
        public void ProcessRequest(HttpContext context)
        {
            int productId;
            if (context.Request.QueryString["ProductId"] != null)
                productId = Convert.ToInt32(context.Request.QueryString["ProductId"]);
            else
                throw new ArgumentException("No parameter specified");
            dbCrudWebFormEntities db = new dbCrudWebFormEntities();
            Product product = (from c in db.Products
                                 where c.Id == productId
                                 select c).FirstOrDefault();
            byte[] imageData = product.Image ;// get the image data from the database using the employeeId Querystring
            context.Response.ContentType = "image/jpeg"; // You can retrieve this also from the database
            context.Response.BinaryWrite(imageData);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}