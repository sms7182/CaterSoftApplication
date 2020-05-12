using System;

namespace CaterSoftDomain.Models
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            Id=Guid.NewGuid();
            SyncDate=DateTime.UtcNow;
        }
        public virtual Guid Id { get; set; }
        public virtual string Tenant { get; set; }

        public virtual DateTime SyncDate { get; set; }
    }
}