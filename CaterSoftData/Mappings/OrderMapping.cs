using CaterSoftDomain.Models;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace CaterSoftData.Mappings
{
    public class OrderMapping : IAutoMappingOverride<Order>
    {
        public void Override(AutoMapping<Order> mapping)
        {
            mapping.Table("POrder");
            mapping.Schema("CaterSoft");
            mapping.Id(it=>it.Id);
            
            mapping.Map(it=>it.Ref).Column("RefId");
            mapping.Map(it=>it.Items).CustomType("StringClob").CustomSqlType("nvarchar(max)");
            mapping.Map(it=>it.Tenant);
        }
    }
}