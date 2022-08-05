﻿using Entity;
using MyDatabase.Initializers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("Sindesmos")
        {
            Database.SetInitializer<ApplicationDbContext>(new MockupDbInitializer());
            Database.Initialize(false);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<ServiceProvider> Provides { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
    }
}
