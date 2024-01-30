using MyLibrary.Application.Interfaces;
using MyLibrary.Application.Services;
using MyLibrary.Inrastructure;

namespace MyLibrary.Injectors
{
    public static class Injectors
    {
        public static void DefineInjectors(IServiceCollection services)
        {
            DefineModelInjectors(services);
            DefineDbSetInjector(services);
        }

        static void DefineModelInjectors(IServiceCollection services)
        {
            services.AddScoped<IBookServices, BookServices>();
            services.AddScoped<IShelfServices, ShelfServices>();
        }

        static void DefineDbSetInjector(IServiceCollection services)
        {
            services.AddScoped<IMyLibraryDb, MyLibraryDb>();
        }
    }
}
