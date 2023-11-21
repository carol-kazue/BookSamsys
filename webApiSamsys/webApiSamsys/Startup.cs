using webApiSamsys.Infrastructure.Services;

namespace webApiSamsys
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped< LivroService>(); // Substitua ILivroService pelo tipo real se necessário

        }
    }
}
