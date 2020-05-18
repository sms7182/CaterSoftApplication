using System;
using System.Collections.Generic;
using System.Text;

namespace CaterSoftDomain.IRepositories
{
    public interface IWorkingContext
    {
        public string Tenant { get; set; }
    }
}
