using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.Infra.Data.Context;
using CakeShop.Infra.IOC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using AutoMapper;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;

namespace CakeShop.API
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
            services.AddDbContext<CakeShopDbContext>(options => {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<CakeShopDbContext>();

            services.Configure<IdentityOptions>(options => {
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 3;
            });

            var key = Encoding.ASCII.GetBytes("asjdklhasjkdhasjkhdsjkahdjksahdjksahdsjad");
            services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x => {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddCors();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CakeShop.API", Version = "v1" });
            });

            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CakeShop.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();

            app.UseCors(x => x.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }
    }
}
