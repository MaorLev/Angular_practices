using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using WebApplication9.Data;
using WebApplication9.Data.Middleware;
using WebApplication9.Services;

namespace WebApplication9
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
            services.AddHttpContextAccessor();

            services.AddCors();

            services.AddControllers()
                  .AddNewtonsoftJson(options =>
                  {
                      options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                  });

            string connectionString = Configuration.GetConnectionString("TodoitemDB");

            services.AddAuthentication(options =>
            {
                
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
              .AddJwtBearer(x =>
              {
                  x.RequireHttpsMetadata = false;
                  x.SaveToken = true;
                  x.TokenValidationParameters = JwtService.TokenValidationParameters;
              });

            services.AddDbContext<TodolistDBContext>(options =>
            options.UseSqlServer(connectionString));
            services.AddTransient<TodolistService>();
            services.AddScoped<UsersService>();
            services.AddTransient<JwtService>();
            //services.AddScoped<JwtService>();
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

            //added by Amos
            /*            app.UseCors(x => x
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .SetIsOriginAllowed(origin => true));// allow any origin*/


            app.UseMiddleware<AllowedCorsMiddleware>();//alowed server coneection way middleware

            app.UseAuthentication();//for jwt אימות

            app.UseAuthorization();//הרשאה

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
