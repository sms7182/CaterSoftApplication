using CaterSoftDomain.Contracts;
using CaterSoftDomain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CaterSoftDomain.IRepositories
{
    public interface IOrderRepository:IRepository<Order>
    {
         Task<bool> SyncOrdersAsync(Order syncOrder);
        Task<bool> TestOrder();
    }
}