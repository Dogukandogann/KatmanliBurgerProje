using KatmanliBurger_DAL.Abstracts.Base;
using KatmanliBurger_DATA.Abstracts;
using KatmanliBurger_DATA.Concretes;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KatmanliBurger_DAL.Concretes.EntityFramework
{
    public class EfBaseDal<TEntity, TContext> : IBaseDal<TEntity> where TEntity : BaseEntity, new() where TContext : DbContext, new()
    {
        public void Create(TEntity entity)
        {
            using (TContext context = new TContext())
            {
               context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
			using (TContext context = new TContext())
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

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(expression);
            }
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null)
        {
            using (TContext context = new TContext())
            {
                return expression == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(expression).ToList();
            }
        }

        public TEntity GetById(int id)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        public IEnumerable<TEntity> GetByIdList(List<int> ids)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Where(x => ids.Contains(x.Id)).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Update(entity);
                context.SaveChanges();
            }
        }
    }
}
