using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vmmsolutions.School.Domain.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Delete(Guid id);
        void Delete(TEntity obj);
        TEntity Insert(TEntity obj);
        TEntity Update(TEntity obj);

    }
}
