using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using FinanceManagementSystem.Models;

namespace FinanceManagementSystem.Controllers
{
    public class ProductsController : ApiController
    {
        private FinanceEntities1 db = new FinanceEntities1();

        // GET: api/Products
        public IHttpActionResult GetProducts()
        {
            return Ok(db.Products);
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductID)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public HttpResponseMessage PostProduct()
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
                //return BadRequest(ModelState);
            }
            try
            {
                string imageName = null;
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files["Image"];
                imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
                imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
                var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
                postedFile.SaveAs(filePath);
                Product product = new Product();
                product.ProductName = httpRequest["ProductName"];
                product.ProductDetails = httpRequest["ProductDetails"];
                product.Image = filePath;
                product.CostPerUnit = Convert.ToInt32(httpRequest["CostPerUnit"]);
                product.AvailableQuantity = Convert.ToInt32(httpRequest["AvailableQuantity"]);
                db.Products.Add(product);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.Created, "Product Added");
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, e.Message);
            } 
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductID == id) > 0;
        }
    }
}