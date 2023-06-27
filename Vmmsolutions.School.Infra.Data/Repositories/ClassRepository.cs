using Dapper;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Infra.Data.Base;

namespace Vmmsolutions.School.Infra.Data.Repositories
{
    public class ClassRepository : Repository<Classes>, IClassRepository
    {
        public ClassRepository(IUnitOfWork context) : base(context)
        {
        }

        public IEnumerable<Classes> GetAll(string createdBy, int? type, string sort, int page, int per_page, out int total)
        {
            string sql = @"SELECT *,
                            COUNT(1) OVER () as Total
                            FROM Classes ";
            DynamicParameters param = new DynamicParameters();


            sql += string.Format(@"
                ORDER BY {0}
                OFFSET ({1}-1)*{2} ROWS FETCH NEXT {2} ROWS ONLY", sort, page, per_page);

            int count = 0;

            IEnumerable<Classes> result = Connection.Query<Classes, int, Classes>(sql,
                (p, t) =>
                {
                    count = t;
                    return p;
                },
                splitOn: "Total",
                param: param);

            total = count;
            return result;
        }

        public Classes GetByCreatedBy(string createdBy, int type)
        {
            string sql = @"SELECT [Id],
                               [CreatedBy],
                               [CreatedOn],
                               [UpdatedOn],
                               [Agreed],
                               [Type]
                            FROM Classes 
                            WHERE [CreatedBy] = @CreatedBy AND [Type] = @Type ";

            Classes result = Connection.QueryFirstOrDefault<Classes>(sql, param: new { CreatedBy = createdBy, Type = type }, transaction: Uow.Transaction);

            return result;
        }
    }
}
