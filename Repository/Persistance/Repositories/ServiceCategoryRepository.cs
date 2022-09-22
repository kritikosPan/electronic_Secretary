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

        //public IQueryable<ServiceCategory> GetProvidersByCategory(int id)
        //{
        //    var groups = from ServiceCategory in table
        //                 group ServiceCategory.Providers by ServiceCategory.Category into list
        //                 select list;
        //    return (IQueryable<ServiceCategory>)groups;
        //}

        //public IQueryable<IGrouping<ServiceCategory, ServiceProvider>> GetProvidersGroupedByCategory(int id)
        //{
        //    var groups = from ServiceCategory in table
        //                 group ServiceCategory.Providers by ServiceCategory.Category into list
        //                 select list;
        //    return (IQueryable<IGrouping<ServiceCategory, ServiceProvider>>)groups;
        //}

    }
}
