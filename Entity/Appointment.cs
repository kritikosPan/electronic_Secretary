using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime DateofAppointment { get; set; }

        //Navigation Properties

        public User User { get; set; }

    }
}
