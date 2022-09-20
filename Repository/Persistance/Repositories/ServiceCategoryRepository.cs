using Entity;
using MyDatabase;
using Repository.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Persistance.Repositories
{
    public class ServiceCategoryRepository : GenericRepository<ServiceCategory>, IServiceCategoryRepository
    {
        public ServiceCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<ServiceCategory> GetCateg()
        {
            return table.Include("Providers");
        }
    }
}
