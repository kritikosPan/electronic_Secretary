﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Repositories
{
    public interface IServiceCategoryRepository : IGenericRepository<ServiceCategory>
    {
        IEnumerable<ServiceCategory> GetCateg();
    }
}
