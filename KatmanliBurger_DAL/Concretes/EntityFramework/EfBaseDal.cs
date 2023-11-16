using KatmanliBurger_DAL.Abstract.Base;
using KatmanliBurger_DATA.Abstracts;
using KatmanliBurger_DATA.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace KatmanliBurger_DAL.Concretes.EntityFramework
{
    public class EfBaseDal<Tentity, Tcontext> : IBaseDal<Tentity> where Tentity : BaseEntity, new() where Tcontext : DbContext, new()
    {
        public void Create(Tentity entity)
        {
            using (Tcontext context = new Tcontext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public  void Delete(Tentity entity)
        {
            using (Tcontext context = new Tcontext())
            {
                if (entity is BurgerGarnitureMapping)
                {
                    context.Remove(entity);
                    context.SaveChanges();
                }
                else
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Modified;
                    context.SaveChanges();
                }
           
            }
        }

        public Tentity Get(Expression<Func<Tentity, bool>> filter)
        {
            using (Tcontext context = new Tcontext())
            {
                return context.Set<Tentity>().FirstOrDefault(filter);

            }

        }

        public IEnumerable<Tentity> GetAll(Expression<Func<Tentity, bool>> filter = null)
        {
            using (Tcontext context = new Tcontext())
            {
                return filter is null
                    ? context.Set<Tentity>().ToList()
                    : context.Set<Tentity>().Where(filter).ToList();

            }
        }

        public Tentity GetById(int id)
        {
            using (Tcontext context = new Tcontext())
            {
                return context.Set<Tentity>().Find(id);

            }
        }

        public IEnumerable<Tentity> GetByIdList(List<int> ids)
        {
            using (Tcontext context = new Tcontext())
            {
                return context.Set<Tentity>().Where(x => ids.Contains(x.Id)).ToList();
            }
        }   
        public void Update(Tentity entity)
        {
            using (Tcontext context = new Tcontext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
