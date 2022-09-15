using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ServiceProvider : SecretaryEntity,IAccount
    {
        public int ServiceProviderId { get; set; }
        [Required(), MaxLength(60), MinLength(2)]
        [Display(Name = "Provider Name")]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public double Rating { get; set; }

        //Navigation Properties
        //public ServiceCategory Category { get; set; }
        public virtual ServiceCategory Category { get; set; }

    }
}
