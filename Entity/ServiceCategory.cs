using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ServiceCategory:SecretaryEntity
    {
        public int ServiceCategoryId { get; set; }
        public string Category { get; set; }
        public string ImgUrl { get; set; }

        //Navigation Properties
        public virtual ICollection<ServiceProvider> Providers { get; set; }
    }
}
