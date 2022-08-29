using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            ServiceCategory c1 = new ServiceCategory() { Category = "Doctor"};
            ServiceCategory c2 = new ServiceCategory() { Category = "Bank"};
            ServiceCategory c3 = new ServiceCategory() { Category = "Public Sector"};
            ServiceCategory c4 = new ServiceCategory() { Category = "Cosmetic Services"};

            ServiceProvider p1 = new ServiceProvider() { Name = "Tripodakis", Email = "tripo@gmail.com", Password = "admin1234!", Calendar = new Calendar(), Category = c1 };
            ServiceProvider p2 = new ServiceProvider() { Name = "Eurobank", Email = "eurobank@gmail.com", Password = "admin1234!", Calendar = new Calendar(), Category = c2 };
            ServiceProvider p3 = new ServiceProvider() { Name = "DOY", Email = "doy@gmail.com", Password = "admin1234!", Calendar = new Calendar(), Category = c3 };
            ServiceProvider p4 = new ServiceProvider() { Name = "Hair & Nails", Email = "hairnails@gmail.com", Password = "admin1234!", Calendar = new Calendar(), Category = c4 };

            Appointment a1 = new Appointment() { Subject = "wisdom tooth removal", DateofAppointment = new DateTime() { }, User = u1 };
            Appointment a2 = new Appointment() { Subject = "account registration", DateofAppointment = new DateTime() { } };
            Appointment a3 = new Appointment() { Subject = "Tax Payment", DateofAppointment = new DateTime() { } };
            Appointment a4 = new Appointment() { Subject = "haircut", DateofAppointment = new DateTime() { } };


            c1.Providers.Add(p1);
            c2.Providers.Add(p2);
            c3.Providers.Add(p3);
            c4.Providers.Add(p4);



            


            base.Seed(context);
        }
    }
}
