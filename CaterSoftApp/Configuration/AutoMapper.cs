using AutoMapper;
using CaterSoftDomain.Contracts;
using CaterSoftDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaterSoftApp.Configuration
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<OrderContract, Order>(); 
        }
    }
}
