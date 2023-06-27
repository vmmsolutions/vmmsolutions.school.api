using System.Data;
using Vmmsolutions.School.Domain.Base;
using Vmmsolutions.School.Domain.Interface;

namespace Vmmsolutions.School.Infra.Data.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        public IDbConnection Connection { get; set; }

        protected IUnitOfWork Uow { get; set; }

        public Repository(IUnitOfWork uow)
        {
            this.Uow = uow;
            Connection = uow.Connection;
        }
        public virtual TEntity GetById(Guid id)
        {
            return this.Uow.Context.Set<TEntity>().FirstOrDefault(o => o.Id == id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Uow.Context.Set<TEntity>().ToList();
        }

        public virtual TEntity Insert(TEntity obj)
        {
            this.Uow.Context.Set<TEntity>().Add(obj);
            this.Uow.Context.SaveChanges();
            return obj;
        }

        public virtual TEntity Update(TEntity obj)
        {
            this.Uow.Context.Set<TEntity>().Update(obj);
            this.Uow.Context.SaveChanges();
            return obj;
        }
        public virtual void Delete(Guid id)
        {
            var obj = Activator.CreateInstance<TEntity>();
            obj.Id = id;
            this.Uow.Context.Set<TEntity>().Remove(obj);
            this.Uow.Context.SaveChanges();
        }

        public virtual void Delete(TEntity obj)
        {
            this.Uow.Context.Set<TEntity>().Remove(obj);
            this.Uow.Context.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
