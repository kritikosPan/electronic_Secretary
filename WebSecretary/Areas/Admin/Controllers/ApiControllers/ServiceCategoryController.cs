using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Entity;
using MyDatabase;
using Repository.Persistance;

namespace WebSecretary.Areas.Admin.Controllers.ApiControllers
{
    [EnableCors("*", "*", "GET,POST,PUT,DELETE")]
    public class ServiceCategoryController : ApiController
    {
        MyDatabase.ApplicationDbContext db = new MyDatabase.ApplicationDbContext();
        UnitOfWork unit;

        public ServiceCategoryController()
        {
            unit = new UnitOfWork(db);
        }

        // GET: api/ServiceCategory
        public IEnumerable<ServiceCategory> GetCategories()
        {
            return unit.ServiceCategories.GetCateg();
        }

        // GET: api/ServiceCategory/5
        [ResponseType(typeof(ServiceCategory))]
        public IHttpActionResult GetServiceCategory(int id)
        {
            ServiceCategory serviceCategory = unit.ServiceCategories.GetById(id);
            if (serviceCategory == null)
            {
                return NotFound();
            }

            return Ok(serviceCategory);
        }

        // PUT: api/ServiceCategory/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServiceCategory(int id, ServiceCategory serviceCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceCategory.ServiceCategoryId)
            {
                return BadRequest();
            }

            unit.ServiceCategories.Update(serviceCategory);

            try
            {
                unit.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceCategoryExists(id))
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

        // POST: api/ServiceCategory
        [ResponseType(typeof(ServiceCategory))]
        public IHttpActionResult PostServiceCategory(ServiceCategory serviceCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unit.ServiceCategories.Create(serviceCategory);
            unit.Complete();

            return CreatedAtRoute("DefaultApi", new { id = serviceCategory.ServiceCategoryId }, serviceCategory);
        }

        // DELETE: api/ServiceCategory/5
        [ResponseType(typeof(ServiceCategory))]
        public IHttpActionResult DeleteServiceCategory(int id)
        {
            ServiceCategory serviceCategory = unit.ServiceCategories.GetById(id);
            if (serviceCategory == null)
            {
                return NotFound();
            }

            unit.ServiceCategories.Delete(id);
            unit.Complete();

            return Ok(serviceCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceCategoryExists(int id)
        {
            return unit.ServiceCategories.GetAll().Count(e => e.ServiceCategoryId == id) > 0;
        }
    }
}