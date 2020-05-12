using System.Collections.Generic;

namespace CaterSoftDomain.Contracts
{
    public class SyncModel
    {
        public SyncModel()
        {
            Orders=new List<OrderContract>();
        }
        public string Tenant { get; set; }
        public List<OrderContract> Orders { get; set; }
    }
}