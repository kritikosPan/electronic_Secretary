using MyDatabase;
using Repository.Core;
using Repository.Core.Repositories;
using Repository.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            context = dbContext;
            Appointments = new AppointmentRepository(context);
            Calendar=new CalendarRepository(context);
            ServiceCategories=new ServiceCategoryRepository(context);
            ServiceProviders=new ServiceProviderRepository(context);
            Users=new UserRepository(context);
        }
        public IAppointmentRepository Appointments { get; private set; }

        public ICalendarRepository Calendar { get; private set; }

        public IServiceCategoryRepository ServiceCategories { get; private set; }

        public IServiceProviderRepository ServiceProviders { get; private set; }

        public IUserRepository Users { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
