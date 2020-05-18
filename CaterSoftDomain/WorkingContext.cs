using CaterSoftDomain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaterSoftDomain
{
    public class WorkingContext : IWorkingContext
    {
        public string Tenant { get; set; }
    }
}
