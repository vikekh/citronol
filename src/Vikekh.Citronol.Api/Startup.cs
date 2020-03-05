using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;

namespace Vikekh.Citronol.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            if (env.IsDevelopment())
            {
                app.UseCors(policy =>
                    policy.WithOrigins("http://localhost:5002", "https://localhost:5003")
                    .AllowAnyMethod()
                    .WithHeaders(HeaderNames.ContentType));
            }
            else if (env.IsProduction())
            {
                app.UseCors(policy =>
                    policy.WithOrigins("https://citronol-api.vikekh.com")
                    .AllowAnyMethod()
                    .WithHeaders(HeaderNames.ContentType));
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
