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
    public class ServiceProviderRepository : GenericRepository<ServiceProvider>, IServiceProviderRepository
    {
        public ServiceProviderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<ServiceProvider> GetTopRatedProvidersByCategory(string category, int count)
        {
            return table.Where(x => x.Category.Category == category).OrderByDescending(x => x.Rating).Take(count).ToList();
        }

        public IQueryable<IGrouping<ServiceCategory, ServiceProvider>> GetProvidersGroupedByCategory()
        {
            var groups = from provider in table
                         group provider by provider.Category into list
                         select list;
            return groups;
        }
        public IEnumerable<ServiceProvider> GetProviders()
        {
            return table.Where(x => x.Category != null);
        }

        public IEnumerable<ServiceProvider> GetProv()
        {
            return table.Include("Category");
        }
    }
}
