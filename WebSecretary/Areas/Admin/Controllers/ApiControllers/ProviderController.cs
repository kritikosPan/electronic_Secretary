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
    public class ProviderController : ApiController
    {
        MyDatabase.ApplicationDbContext db = new MyDatabase.ApplicationDbContext();
        UnitOfWork unit;

        public ProviderController()
        {
            unit = new UnitOfWork(db);
        }

        // GET: api/Provider
        public IEnumerable<ServiceProvider> GetProviders()
        {
            return unit.ServiceProviders.GetAll();
        }

        // GET: api/Provider/5
        [ResponseType(typeof(ServiceProvider))]
        public IHttpActionResult GetServiceProvider(int id)
        {
            ServiceProvider serviceProvider = unit.ServiceProviders.GetById(id);
            if (serviceProvider == null)
            {
                return NotFound();
            }

            return Ok(serviceProvider);
        }

        // PUT: api/Provider/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServiceProvider(int id, ServiceProvider serviceProvider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceProvider.ServiceProviderId)
            {
                return BadRequest();
            }
            unit.ServiceProviders.Update(serviceProvider);
            //db.Entry(serviceProvider).State = EntityState.Modified;

            try
            {
                unit.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceProviderExists(id))
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

        // POST: api/Provider
        [ResponseType(typeof(ServiceProvider))]
        public IHttpActionResult PostServiceProvider(ServiceProvider serviceProvider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unit.ServiceProviders.Create(serviceProvider);
            unit.Complete();

            return CreatedAtRoute("DefaultApi", new { id = serviceProvider.ServiceProviderId }, serviceProvider);
        }

        // DELETE: api/Provider/5
        [ResponseType(typeof(ServiceProvider))]
        public IHttpActionResult DeleteServiceProvider(int id)
        {
            ServiceProvider serviceProvider = unit.ServiceProviders.GetById(id);
            if (serviceProvider == null)
            {
                return NotFound();
            }

            unit.ServiceProviders.Delete(id);
            unit.Complete();

            return Ok(serviceProvider);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceProviderExists(int id)
        {
            return unit.ServiceProviders.GetAll().Count(e => e.ServiceProviderId == id) > 0;
        }
    }
}