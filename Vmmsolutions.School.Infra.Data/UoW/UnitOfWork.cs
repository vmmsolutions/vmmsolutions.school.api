using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data;
using Vmmsolutions.School.Domain.Interface;

namespace Vmmsolutions.School.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Just for logging and debugging purpose
        /// </summary>
        private readonly DbContextId _id;

        /// <summary>
        /// The IDbConnection will be responsible for managing the database connection
        /// </summary>
        public IDbConnection Connection { get; set; }

        /// <summary>
        /// the IDbTransaction will be responsible for the transactions
        /// </summary>
        public IDbTransaction Transaction { get; set; }

        public DbContext Context { get; set; }

        public bool ValidateEntity { get; set; }

        public UnitOfWork(IDbConnection connection, DbContext context)
        {
            this.Context = context;
            _id = context.ContextId;
            this.ValidateEntity = true;
            this.Context.Database.CanConnect();
            this.Connection = this.Context.Database.GetService<IDbConnection>();
        }

        public void BeginTransaction()
        {
            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            Transaction.Commit();
            Dispose();
        }

        public void CommitSessionTransaction()
        {
            Transaction.Commit();
            DisposeTransaction();
        }

        public void Rollback()
        {
            Transaction.Rollback();
            Dispose();
        }

        public void DisposeTransaction() => Transaction?.Dispose();

        /// <summary>
        /// The Connection object has two similar methods, Close and Dispose. 
        /// Both close the database connection, but Close still keeps the Connection object active.
        /// In short, if you intend to reopen this same connection in the future, the best choice is to use Close, 
        /// otherwise, using Dispose you will need to generate a new Connection object.
        /// </summary>
        public void Dispose()
        {
            if (Connection != null)
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();

                Connection?.Dispose();
                Connection = null;
            }

            if (Transaction != null)
            {
                DisposeTransaction();
                Transaction = null;
            }

            if (Context != null)
            {
                Context?.Dispose();
                Context = null;
            }
        }
    }
}
