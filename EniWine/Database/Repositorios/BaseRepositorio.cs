using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EniWine.Database.Repositorios
{
    public class BaseRepositorio<TEntity>: IDisposable where TEntity : class
    {
        protected EniwineEntities Db = new EniwineEntities();

        public void AddRange(IEnumerable<TEntity> obj)
        {
            Db.Set<TEntity>().AddRange(obj);
            Db.SaveChanges();
        }

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public TEntity GetById(string id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void UpdateAll(List<TEntity> obj)
        {
            foreach (var ob in obj)
            {
                Db.Entry(ob).State = EntityState.Modified;

            }
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> objs)
        {
            foreach (var obj in objs)
            {
                Db.Set<TEntity>().Remove(obj);
            }

            Db.SaveChanges();
        }
        public async Task RemoveRangeAsync(IEnumerable<TEntity> objs)
        {
            foreach (var obj in objs)
            {
                Db.Set<TEntity>().Remove(obj);
            }

            await Db.SaveChangesAsync();
        }


        public async Task<TEntity> AddAsync(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            await Db.SaveChangesAsync();
            return obj;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Db.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await Db.Set<TEntity>().FindAsync(id);
        }

        public async Task UpdateAsync(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            await Db.SaveChangesAsync();
        }

        public async Task RemoveAsync(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}