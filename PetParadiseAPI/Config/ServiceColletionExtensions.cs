using PetParadiseAPI.DataAccess.DAO;
using PetParadiseAPI.Services.Services;


namespace PetParadiseAPI.Config
{
    public static class ServiceColletionExtensions
    {
        public static IServiceCollection AddConfig(
             this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient(typeof(IBaseDAO<>), typeof(BaseDAO<>));
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IUsuarioDAO, UsuarioDAO>();
            return services;
        }
    }
}
