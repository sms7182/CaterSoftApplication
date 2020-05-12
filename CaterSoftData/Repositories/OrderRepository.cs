using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CaterSoftDomain.Contracts;
using CaterSoftDomain.IRepositories;
using CaterSoftDomain.Models;


namespace CaterSoftData.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
       
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