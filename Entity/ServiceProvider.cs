using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ServiceProvider : IAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Calendar Calendar { get; set; }

        //Navigation Properties
        public ServiceCategory Category { get; set; }
        
    }
}
