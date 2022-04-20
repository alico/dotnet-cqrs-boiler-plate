using AutoMapper;

public static class AutoMapperExtension
{
    public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
    {
        // Auto Mapper Configurations
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AllowNullCollections = true;
            //mc.AddProfile(new MappingProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
}

