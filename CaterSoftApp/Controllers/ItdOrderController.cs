using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using CaterSoftDomain.Contracts;
using CaterSoftDomain.IRepositories;
using CaterSoftDomain.Models;
using CaterSoftDomain.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace CaterSoftApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ItdOrderController:ControllerBase
    {
        private readonly ILogger<ItdOrderController> _logger;
        private IOrderRepository orderRepository;
        IMapper mapper;
        public ItdOrderController(ILogger<ItdOrderController> logger,IOrderRepository orderRep,IMapper _mapper)
        {
            _logger = logger;
           orderRepository=orderRep;
            mapper = _mapper;
        }

        [HttpPost("saveorder")]
        public async Task<IActionResult> SaveItdOrderAsync(SyncModel syncmodel)
        {
            for(var i = 0; i < syncmodel.Orders.Count; i++)
            {
              var order= mapper.Map<Order>(syncmodel.Orders[i]);
                order.Tenant = syncmodel.Tenant;
                orderRepository.SyncOrdersAsync(order);
            }
            _logger.LogInformation("starting api");
            try
            {
                
                //var res = true;
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                return BadRequest("Error");
            }
         

          
        }

       
        [HttpGet("apitesting")]
        public IActionResult GetTest()
        {
            _logger.LogInformation("starting api");
            return Ok("yes");


        }




    }
   
}