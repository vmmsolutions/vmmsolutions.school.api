using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Vmmsolutions.School.Domain.Interface
{
    /// <summary>
    /// Again, as we are working with connection/transaction objects in the database,
    /// it is important to implement IDisposable to ensure that no connection is no left open.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        public IDbConnection Connection { get; set; }
        public DbContext Context { get; set; }
        public IDbTransaction Transaction { get; set; }
        public bool ValidateEntity { get; set; }
        void BeginTransaction();
        void Commit();
        void CommitSessionTransaction();
        void Rollback();
    }
}
