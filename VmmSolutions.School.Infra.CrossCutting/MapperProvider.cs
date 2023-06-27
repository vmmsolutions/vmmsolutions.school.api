using AutoMapper;
using SimpleInjector;
using Vmmsolutions.School.Application.AutoMapper;

namespace VmmSolutions.School.Infra.CrossCutting
{
    public class MapperProvider
    {
        private readonly Container _container;

        public MapperProvider(Container container)
        {
            _container = container;
        }

        public IMapper GetMapper()
        {
            var mce = new MapperConfigurationExpression();
            mce.ConstructServicesUsing(_container.GetInstance);

            var mc = AutoMapperConfig.RegisterMappings();
            mc.AssertConfigurationIsValid();

            IMapper m = new Mapper(mc, t => _container.GetInstance(t));

            return m;
        }
    }
}
