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
    public class AppointmentController : ApiController
    {
        MyDatabase.ApplicationDbContext db = new MyDatabase.ApplicationDbContext();
        UnitOfWork unit;

        public AppointmentController()
        {
            unit = new UnitOfWork(db);
        }

        // GET: api/Appointment
        public IEnumerable<Appointment> GetAppointments()
        {
            return unit.Appointments.GetAll();
        }

        // GET: api/Appointment/5
        [ResponseType(typeof(Appointment))]
        public IHttpActionResult GetAppointment(int id)
        {
            Appointment appointment = unit.Appointments.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        // PUT: api/Appointment/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAppointment(int id, Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointment.Id)
            {
                return BadRequest();
            }
            unit.Appointments.Update(appointment);
            //.Entry(appointment).State = EntityState.Modified;

            try
            {
                unit.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
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

        // POST: api/Appointment
        [ResponseType(typeof(Appointment))]
        public IHttpActionResult PostAppointment(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unit.Appointments.Create(appointment);
            unit.Complete();

            return CreatedAtRoute("DefaultApi", new { id = appointment.Id }, appointment);
        }

        // DELETE: api/Appointment/5
        [ResponseType(typeof(Appointment))]
        public IHttpActionResult DeleteAppointment(int id)
        {
            Appointment appointment = unit.Appointments.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            unit.Appointments.Delete(id);
            unit.Complete();

            return Ok(appointment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppointmentExists(int id)
        {
            return unit.Appointments.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}