using FluentValidation;
using System.Diagnostics.CodeAnalysis;
using Vmmsolutions.School.Domain.Interface;

namespace Vmmsolutions.School.Domain.Base
{
    [ExcludeFromCodeCoverage]
    public class Services<TEntity> : IService<TEntity>
            where TEntity : class
    {
        public Services(IUnitOfWork context, IRepository<TEntity> repository)
        {
            Repository = repository;
            Context = context;
        }

        protected IRepository<TEntity> Repository { get; }

        protected AbstractValidator<TEntity> Validator { get; set; }

        protected IUnitOfWork Context { get; set; }

        public virtual void Delete(TEntity obj)
        {
            //if (Context.ValidateEntity)
            //    Validator.ValidateAndThrow(obj);
            Repository.Delete(obj);
        }

        public void Dispose()
        {
            Repository.Dispose();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Repository.GetAll();
        }

        public virtual TEntity GetById(Guid id)
        {
            return Repository.GetById(id);
        }

        public virtual TEntity Insert(TEntity obj)
        {
            //if (Context.ValidateEntity)
            //    Validator.ValidateAndThrow(obj, "Insert");

            return Repository.Insert(obj);
        }

        public virtual TEntity Update(TEntity obj)
        {
            //if (Context.ValidateEntity)
            //    Validator.ValidateAndThrow(obj, "Update");
            return Repository.Update(obj);
        }
    }
}