using Entity;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Persistance
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : SecretaryEntity
    {
        public ApplicationDbContext db;
        public DbSet<T> table;

        public GenericRepository(ApplicationDbContext context)
        {
            db = context;
            table = db.Set<T>();
        }

        public void Create(T obj)
        {
            table.Add(obj);
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return table.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return table.SingleOrDefault(predicate);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
        }
    }
}
