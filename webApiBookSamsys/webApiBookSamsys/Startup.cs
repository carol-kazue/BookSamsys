using Microsoft.EntityFrameworkCore;
using webApiBookSamsys.Controllers;
using webApiBookSamsys.Infrastructure.Entities;
using webApiBookSamsys.Infrastructure.Repository;
using webApiBookSamsys.Infrastructure.Services;
using Newtonsoft.Json;
using System.Text.Json;
using webApiBookSamsys.Infrastructure.Mappers;
using AutoMapper; 

namespace webApiBookSamsys
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
            services.AddScoped<BookRepository>();
            services.AddScoped<BookService>();
            //services.AddScoped<BooksController>();
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            // Configuração do Entity Framework Core (substitua com sua configuração)
            services.AddDbContext<BookSamsysContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

           
            services.AddCors();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
