using Repository.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core
{
    internal interface IUnitOfWork:IDisposable
    {
        IAppointmentRepository Appointments { get; }
        IServiceCategoryRepository ServiceCategories { get; }
        IServiceProviderRepository ServiceProviders { get; }
        IUserRepository Users { get; }
        int Complete();
    }
}
