using System;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CaterSoftData.Repositories;
using CaterSoftDomain;
using CaterSoftDomain.IRepositories;

using Microsoft.Extensions.Configuration;
using NHibernate;

namespace CaterSoftData.Configuration
{
    public class DependencyInstaller : IWindsorInstaller
    {
        
        IConfiguration configuration;
        public DependencyInstaller(IConfiguration confg)
        {
            configuration=confg;
        }
        public void Install(IWindsorContainer windsorContainer, IConfigurationStore store)
        {
           windsorContainer.Kernel.ComponentRegistered+=Kernel_ComponentRegistered;
            var dbtype=configuration.GetSection("DBType").Value;
          
            ORMSession.configuration=configuration;
           windsorContainer.Register(
              
            Component.For<ISessionFactory>().UsingFactoryMethod(ORMSession.CreateMSSqlNhSessionFactory).LifeStyle.Singleton,
            Component.For<NhUnitOfWorkInterceptor>().LifeStyle.Transient,

            Classes.FromAssembly(typeof(OrderRepository).Assembly).BasedOn(typeof(BaseRepository<>))
            .WithService.FromInterface(typeof(IRepository)).LifestyleTransient()
      

             
          );
        }
         void Kernel_ComponentRegistered(string key, Castle.MicroKernel.IHandler handler)
        {
            //Intercept all methods of all repositories.
            if (UnitOfWorkHelper.IsRepositoryClass(handler.ComponentModel.Implementation))
            {
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(NhUnitOfWorkInterceptor)));
            }

            //Intercept all methods of classes those have at least one method that has UnitOfWork attribute.
            foreach (var method in handler.ComponentModel.Implementation.GetMethods())
            {
                if (UnitOfWorkHelper.HasUnitOfWorkAttribute(method))
                {
                    handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(NhUnitOfWorkInterceptor)));
                    return;
                }
            }
        }
    }
}