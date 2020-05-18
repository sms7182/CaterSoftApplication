using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaterSoftDomain.IRepositories;
using CaterSoftDomain.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CaterSoftApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        private readonly ILogger<ReportController> _logger;
       private IOrderRepository orderRepository;
      
        public ReportController(ILogger<ReportController> logger, IOrderRepository orderRep)
        {
            _logger = logger;
           orderRepository = orderRep;
          
        }

        [HttpGet("getOdersPerDay")]
        public async Task<IActionResult> GetOdersPerDay(DateTime from, DateTime to)
        {

            var result = await orderRepository.GetOrdersPerPeriodType(from, to, PeriodType.Day);
            return Ok(result);
        }

        [HttpGet("getOdersPerWeek")]
        public async Task<IActionResult> GetOdersPerWeek(DateTime from, DateTime to)
        {

            var result = await orderRepository.GetOrdersPerPeriodType(from, to, PeriodType.Week);
            return Ok(result);
        }

        [HttpGet("getOdersPerMonth")]
        public async Task<IActionResult> GetOdersPerMonth(DateTime from, DateTime to)
        {

            var result = await orderRepository.GetOrdersPerPeriodType(from, to, PeriodType.Month);
            return Ok(result);
        }

        [HttpGet("getOdersPerYear")]
        public async Task<IActionResult> GetOdersPerYear(DateTime from, DateTime to)
        {

            var result = await orderRepository.GetOrdersPerPeriodType(from, to, PeriodType.Year);
            return Ok(result);
        }



    }
}