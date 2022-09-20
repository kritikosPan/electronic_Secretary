using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Repositories
{
    public interface IServiceProviderRepository: IGenericRepository<ServiceProvider>
    {
        IQueryable<IGrouping<ServiceCategory, ServiceProvider>> GetProvidersGroupedByCategory();
        IEnumerable<ServiceProvider> GetTopRatedProvidersByCategory(string category,int rating);
        IEnumerable<ServiceProvider> GetProv();
    }
}
