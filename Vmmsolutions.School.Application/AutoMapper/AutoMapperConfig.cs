using AutoMapper;

namespace Vmmsolutions.School.Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new DataTransferToDomainMappingProfile());
            });
        }
    }
}
