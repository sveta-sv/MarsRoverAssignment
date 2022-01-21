using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;

namespace MarsRoverAssignment
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
            services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            var surface = new int[,]
            {
                           /*W*/
               /*y0 y1 y2 y3 y4 y5 y6 y7 y8 y9*/
          /*x0*/{0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
          /*x1*/{0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
          /*x2*/{0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
          /*x3*/{0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    /*S*/ /*x4*/{0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, /*N*/
          /*x5*/{0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
          /*x6*/{0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
          /*x7*/{0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
          /*x8*/{0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
          /*x9*/{0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
                           /*E*/
            };

            var planet = new Planet(surface);
            var rover = new Rover(0, 0, Direction.E, planet);

            services.AddSingleton(rover);
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
