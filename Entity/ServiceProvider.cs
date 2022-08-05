using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ServiceProvider : IAccount
    {
        public int Id { get; set; }
        [Required(), MaxLength(60), MinLength(2)]
        [Display(Name = "Provider Name")]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public Calendar Calendar { get; set; }

        //Navigation Properties
        public ServiceCategory Category { get; set; }
        
    }
}
