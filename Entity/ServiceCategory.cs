using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ServiceCategory:SecretaryEntity
    {
        public int Id { get; set; }
        public string Category { get; set; }

        //Navigation Properties
        public List<ServiceProvider> Providers { get; set; }
    }
}
