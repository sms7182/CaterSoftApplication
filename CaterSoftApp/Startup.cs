using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CaterSoftApp.Configuration;
using CaterSoftData.Configuration;
using CaterSoftDomain.Contracts;
using CaterSoftDomain.Models;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;


namespace CaterSoftApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddMvc(options =>
            {
                options.InputFormatters.Add(new TextPlainInputFormatter());
            });

            services.AddAuthentication(
            CertificateAuthenticationDefaults.AuthenticationScheme)
       .AddCertificate();

            services.AddControllers(options => options.EnableEndpointRouting = false);
            services.AddControllers().AddNewtonsoftJson();

            services.AddMvc().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = null;
                o.JsonSerializerOptions.DictionaryKeyPolicy = null;
                o.JsonSerializerOptions.WriteIndented = true;
            });
            services.AddMvc(o => o.InputFormatters.Insert(0, new RawRequestBodyFormatter()));

            //        services.AddSwaggerGen(c =>
            //  {
            //       c.SwaggerDoc("v5", new OpenApiInfo
            //            {
            //                 Version = "v5",
            //                 Title = "OrderSync",
            //                 Description = "using for sync from wincatersoft server",

            //            });

            //  });

            services.AddControllers(options => options.EnableEndpointRouting = false);
          
            return services.DependencyExtension(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            app.UseRouting();
            app.UseCors("MyPolicy");



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            
            // app.UseSwagger();
            // app.UseSwaggerUI(c =>
            // {
            //     c.SwaggerEndpoint("/swagger/v1/swagger.json", "ItdSoftware");
            //     c.RoutePrefix = "swagger";
            //     c.DocExpansion(DocExpansion.None);
            //     c.DefaultModelsExpandDepth(-1);
            // });

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=WeatherForecast}/{action=Get}/{id?}");

            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
         
            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMvc();
           

        }
    }
}
