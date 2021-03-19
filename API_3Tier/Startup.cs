using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API_3Tier
{
    public class Startup
    {
        private readonly string AllowAll = "_AllowAll";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Add CORS
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            // Add framework services.
            services.AddMvc();
           
            //------
            services.AddCors(options => {
                options.AddPolicy(
                        name: AllowAll,
                        builder =>
                        {
                            builder.WithOrigins("*");
                        }
                    );
            });

            services.AddSingleton<DAL.ConnectDB>();
            services.AddSingleton<DAL.BrandDAL>();
            services.AddSingleton<DAL.CategoryDAL>();
            services.AddSingleton<BLL.ProductBLL>();
            services.AddSingleton<BLL.BrandBLL>();
            services.AddSingleton<BLL.CategoryBLL>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //-------

            app.UseCors("MyPolicy");

           
            //-----
            app.UseCors(AllowAll);

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
