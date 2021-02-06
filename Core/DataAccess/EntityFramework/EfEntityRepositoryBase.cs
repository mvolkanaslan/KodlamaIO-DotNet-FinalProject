using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity:class,IEntity,new()
        where TContext : DbContext,new()
    {
        public void Add(TEntity entity)
        {
            //Using işi bitince GC bellekten onu seler
            //daha perforanslı
            //IDispoasble Pattern İmplemntiton pf C# - belleği hızlıca temizleme
            using (TContext context = new TContext())
            {

                var addedEntity = context.Entry(entity); //referensı yakalama
                addedEntity.State = EntityState.Added; // operasyon
                context.SaveChanges();//işlemi tamamla
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {

                var deletedEntity = context.Entry(entity); //referensı yakalama
                deletedEntity.State = EntityState.Deleted; // operasyon
                context.SaveChanges();//işlemi tamamla
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        //BUrada filtreyi sonradan fonkiona yolluyruz. bu değşebilir.
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();

            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {

                var updatedEntity = context.Entry(entity); //referensı yakalama
                updatedEntity.State = EntityState.Modified; // operasyon
                context.SaveChanges();//işlemi tamamla
            }
        }
    }
}
