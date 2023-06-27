using Dapper;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Infra.Data.Base;

namespace Vmmsolutions.School.Infra.Data.Repositories
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(IUnitOfWork context) : base(context)
        {
        }

        public IEnumerable<Teacher> GetAll(string createdBy, int? type, string sort, int page, int per_page, out int total)
        {
            string sql = @"SELECT *,
                            COUNT(1) OVER () as Total
                            FROM Teachers ";
            DynamicParameters param = new DynamicParameters();


            sql += string.Format(@"
                ORDER BY {0}
                OFFSET ({1}-1)*{2} ROWS FETCH NEXT {2} ROWS ONLY", sort, page, per_page);

            int count = 0;

            IEnumerable<Teacher> result = Connection.Query<Teacher, int, Teacher>(sql,
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

        public Teacher GetByCreatedBy(string createdBy, int type)
        {
            string sql = @"SELECT [Id],
                               [CreatedBy],
                               [CreatedOn],
                               [UpdatedOn],
                               [Agreed],
                               [Type]
                            FROM Teachers 
                            WHERE [CreatedBy] = @CreatedBy AND [Type] = @Type ";

            Teacher result = Connection.QueryFirstOrDefault<Teacher>(sql, param: new { CreatedBy = createdBy, Type = type }, transaction: Uow.Transaction);

            return result;
        }
    }
}
