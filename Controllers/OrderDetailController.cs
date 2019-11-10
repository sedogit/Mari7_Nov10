using System;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Mari7.Models;
using Mari7.Services;
using Mari7.Entities;
using Mari7.Helpers;

namespace Mari7.Controllers
{
    [Authorize]
       [ApiController]
    [Route("api/[controller]")]   
    public class OrderDetailController : ControllerBase
    {
/*         private readonly IConfiguration Configuration;
         public OrderDetailController(IConfiguration configuration)
        {
                    Configuration = configuration;
        }  */
      private readonly MariContext _context;
       
        public OrderDetailController(MariContext context)
        {
            _context = context;
        } 
        [HttpGet]
        public ActionResult<List<OrderDetail>> GetAll()
        {
            return _context.OrderDetails.ToList();
        }
         [HttpPost]
        public  ActionResult<List<OrderDetail>>  Create(OrderDetail OrderDetail)
        {  
                //_context.OrderDetails.Add(new OrderDetail { ID=id });
                _context.OrderDetails.Add(OrderDetail);
                _context.SaveChanges();
                return _context.OrderDetails.ToList();
        }

    }
}