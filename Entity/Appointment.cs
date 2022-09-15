using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Appointment:SecretaryEntity
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Navigation Properties
        //public Calendar calendar { get; set; }

        public virtual User User { get; set; }
        public virtual ServiceProvider Provider { get; set; }

    }
}
