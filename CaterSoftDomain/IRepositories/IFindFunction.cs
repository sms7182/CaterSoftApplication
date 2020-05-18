using CaterSoftDomain.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CaterSoftDomain.IRepositories
{
    public interface IFindFunction
    {
        public Dictionary<PeriodType, Func<string,DateTime,DateTime, string>> SalePerPeriodQuery { get; set; }
    }
}
