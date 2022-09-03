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
    [EnableCors("*","*","GET,POST,PUT,DELETE")]
    public class UserController : ApiController
    {
        MyDatabase.ApplicationDbContext db = new MyDatabase.ApplicationDbContext();
        UnitOfWork unit;

        public UserController()
        {
            unit = new UnitOfWork(db);
        }

        // GET: api/User
        public IEnumerable<User> GetUsers()
        {
            return unit.Users.GetAll();
        }

        // GET: api/User/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = unit.Users.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/User/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }
            unit.Users.Update(user);
            //db.Entry(user).State = EntityState.Modified;

            try
            {
                unit.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/User
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unit.Users.Create(user);
            unit.Complete();

            return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);
        }

        // DELETE: api/User/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = unit.Users.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            unit.Users.Delete(id);
            unit.Complete();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return unit.Users.GetAll().Count(e => e.UserId == id) > 0;
        }
    }
}