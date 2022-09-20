using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase.Initializers
{
    public class MockupDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            User u1 = new User() { Firstname = "Dionushs", Lastname = "Tzovaras", Email = "dion1234@gmail.com", Password = "admin1234!" };
            User u2 = new User() { Firstname = "Panagiotis", Lastname = "Kritikos", Email = "panos1234@gmail.com", Password = "admin1234!" };
            User u3 = new User() { Firstname = "George", Lastname = "Prassas", Email = "gio1234@gmail.com", Password = "admin1234!" };
            User u4 = new User() { Firstname = "Spiros", Lastname = "Christodoulou", Email = "spch1234@gmail.com", Password = "admin1234!" };
            User u5 = new User() { Firstname = "Ektoras", Lastname = "Gatsos", Email = "ektor1234@gmail.com", Password = "admin1234!" };
            User u6 = new User() { Firstname = "Joey", Lastname = "Tribiani", Email = "joey1234@gmail.com", Password = "admin1234!" };
            User u7 = new User() { Firstname = "Kornilia", Lastname = "Panou", Email = "mars1234@gmail.com", Password = "admin1234!" };
            User u8 = new User() { Firstname = "John", Lastname = "Wick", Email = "wick1234@gmail.com", Password = "admin1234!" };
            User u9 = new User() { Firstname = "George", Lastname = "Pasparakis", Email = "paspa1234@gmail.com", Password = "admin1234!" };
            User u10 = new User() { Firstname = "Marianta", Lastname = "Papadopoulou", Email = "dion1234@gmail.com", Password = "admin1234!" };

            context.Users.AddOrUpdate(u1, u2, u3, u4, u5, u6, u7, u8, u9, u10);
            context.SaveChanges();


            Appointment a1 = new Appointment() { Subject = "wisdom tooth removal", StartDate = new DateTime(2022, 9, 15), EndDate = new DateTime(2022, 9, 15) };
            Appointment a2 = new Appointment() { Subject = "account registration", StartDate = new DateTime(2022, 9, 15), EndDate = new DateTime(2022, 9, 15) };
            Appointment a3 = new Appointment() { Subject = "Tax Payment", StartDate = new DateTime(2022, 9, 15), EndDate = new DateTime(2022, 9, 15) };
            Appointment a4 = new Appointment() { Subject = "haircut", StartDate = new DateTime(2022, 9, 15), EndDate = new DateTime(2022, 9, 15) };

            a1.User = u1;
            a2.User = u2;
            a3.User = u3;
            a4.User = u7;


            context.Appointments.AddOrUpdate(a1, a2, a3, a4);
            context.SaveChanges();

            ServiceCategory c1 = new ServiceCategory() { Category = "Doctor" };
            ServiceCategory c2 = new ServiceCategory() { Category = "Bank" };
            ServiceCategory c3 = new ServiceCategory() { Category = "Public Sector" };
            ServiceCategory c4 = new ServiceCategory() { Category = "Cosmetic Services" };


            context.Categories.AddOrUpdate(c1, c2, c3, c4);
            context.SaveChanges();


            ServiceProvider p1 = new ServiceProvider() { Name = "Tripodakis", Email = "tripo@gmail.com", Password = "admin1234!", Category=c1 };
            ServiceProvider p2 = new ServiceProvider() { Name = "Eurobank", Email = "eurobank@gmail.com", Password = "admin1234!", Category = c2 };
            ServiceProvider p3 = new ServiceProvider() { Name = "DOY", Email = "doy@gmail.com", Password = "admin1234!", Category = c3};
            ServiceProvider p4 = new ServiceProvider() { Name = "Hair & Nails", Email = "hairnails@gmail.com", Password = "admin1234!", Category = c4};

            context.Providers.AddOrUpdate(p1, p2, p3, p4);
            context.SaveChanges();


            c1.Providers.Add(p1);
            c2.Providers.Add(p2);
            c3.Providers.Add(p3);
            c4.Providers.Add(p4);

            a1.Provider = p1;
            a2.Provider = p2;
            a3.Provider = p3;
            a4.Provider = p4;


            context.SaveChanges();

            base.Seed(context);
        }
    }
}
