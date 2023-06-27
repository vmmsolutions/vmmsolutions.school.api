using AutoMapper;
using Vmmsolutions.School.Domain.Interface;

namespace Vmmsolutions.School.Application.Base
{
    public class AppService
    {
        public AppService(IUnitOfWork uoW, IMapper Mapper)
        {
            UoW = uoW;
            this.Mapper = Mapper;
        }

        protected IUnitOfWork UoW { get; set; }
        protected IMapper Mapper { get; set; }
    }
}
