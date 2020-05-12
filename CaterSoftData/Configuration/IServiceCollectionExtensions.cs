//using System.Web.Http;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Microsoft.Extensions.DependencyInjection;
using System;
using Castle.Facilities.AspNetCore;
using Microsoft.Extensions.Configuration;

namespace CaterSoftData.Configuration
{
    
    public static class IServiceCollectionExtensions{
      public static IServiceProvider DependencyExtension(this IServiceCollection services,IConfiguration configuration)
          {
                var container= DependencyRegisteration.Register(configuration);
              return WindsorRegistrationExtensions.AddWindsor(services,container);
    


          }
    }
    public static class DependencyRegisteration
    {
        public static  IWindsorContainer Register(IConfiguration configuration){
            var container = new WindsorContainer();
          container.Install(new DependencyInstaller(configuration));
            
         //   container.Install(FromAssembly.Instance(typeof(DependencyRegisteration).Assembly));
          
            return container;
         }
    }
}