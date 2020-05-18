using System;
using CaterSoftData.Mappings;
using CaterSoftDomain.Models;

using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace CaterSoftData.Configuration { 
    public class ORMSession
    {
      public static IConfiguration configuration;
       public static ISessionFactory CreateMSSqlNhSessionFactory(){
           
          var automappings= AutoMap.AssemblyOf<OrderMapping>();
       var constring= configuration.GetConnectionString("DefaultConnectionString");
         var dbConfig=MsSqlConfiguration.MsSql2012.
                         
                ConnectionString(constring);
               //  .Provider("System.Data.SqlClient");
            var mappings= Fluently.Configure().
                Database(dbConfig.ShowSql())
               
               .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<Order>().
               UseOverridesFromAssemblyOf<OrderMapping>()
              .Where(d=>d.BaseType==typeof(BaseModel)
               )
               ));


             ISessionFactory buildSessionFactory=null ;
            try{
               FluentConfiguration fluentConfiguration=mappings.ExposeConfiguration(d => 
               { new SchemaUpdate(d).Execute(false,true);
                            new SchemaExport(d)
                .Create(false,false);});
               buildSessionFactory= fluentConfiguration.BuildSessionFactory();
               }
               catch(Exception ex){
                     Console.Write("exeption is ",ex.StackTrace);
               }
            return buildSessionFactory;
       }       
          
    }
}