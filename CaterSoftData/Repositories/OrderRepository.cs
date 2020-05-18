using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CaterSoftDomain.Contracts;
using CaterSoftDomain.IRepositories;
using CaterSoftDomain.Models;
using CaterSoftDomain.Views;
using NHibernate.Transform;

namespace CaterSoftData.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        IFindFunction findFunction;
        IWorkingContext workingContext;

       
        public OrderRepository(IFindFunction find,IWorkingContext context)
        {
            findFunction = find;
            workingContext = context;
        }
       
        public Task<List<SaleDetail>> GetOrdersPerPeriodType(DateTime from,DateTime to,PeriodType periodType)
        {

           
            var query=  findFunction.SalePerPeriodQuery[periodType](workingContext.Tenant,from,to);
            var sqlQuery=Session.CreateSQLQuery(query);
           var saledetails= sqlQuery.SetResultTransformer(Transformers.AliasToBean<SaleDetail>()).List<SaleDetail>().ToList();
            return Task.FromResult(saledetails);
            
        }
       

        public Task<bool> SyncOrdersAsync(Order syncOrder)
        {
          try{
           
              Session.SaveAsync(syncOrder);
             
       
             return Task.FromResult(true);
           }
           catch(Exception exp){
               return Task.FromResult(false);
           }
           
        }

        public Task<bool> TestOrder()
        {
            return Task.FromResult(true);
        }
    }
}