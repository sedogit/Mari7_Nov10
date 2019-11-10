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
    public class OrderController : ControllerBase
    {

        private IUserService _userService;
        private IOrderService  _orderService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly ILogger<UserController> _logger;
       
        public OrderController(IUserService userService,IOrderService  orderService, IMapper mapper, IOptions<AppSettings> appSettings, ILogger<UserController> logger)
        {
            _userService = userService;
            _orderService = orderService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _logger = logger;
        }
        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public ActionResult<List<Order>> GetAll()
        {
            return _orderService.GetAll().ToList();;
        }
        
        
        [HttpGet("CheckOrderEntryAuth")]
        public  ActionResult<int>  CheckOrderEntryAuth()
        {  
          
            /* Admin, yönetici veya satış görevlisi yapabilir sadece! */
            if(!User.IsInRole(Role.Admin) && !User.IsInRole(Role.Manager )&& !User.IsInRole(Role.Salesman)  )
                        return Forbid();

            return Step.OrderEntry;
        }
         
        [HttpPost("CreateCompleteOrder")]
        public  ActionResult<Order>  CreateCompleteOrder(Order order)
        {  
            /* Admin, yönetici veya satış görevlisi yapabilir sadece! */
            if(!User.IsInRole(Role.Admin) && !User.IsInRole(Role.Manager )&& !User.IsInRole(Role.Salesman)  )
                        return Forbid();

            /* Satış elemanı gelen siparişini tamamen girmiştir ve onu kaydedip sonraki adımdaki kişilerin görmesini istemektedir */
              _orderService.CreateOrder(order);
              _orderService.SetNewStep(order.ID,Step.PriceAsk,Status.OrderEntered,MariAction.NextStep);
              return order;
        }
          
        [HttpPost("CreatePartialOrder")]
        public  ActionResult<Order>  CreatePartialOrder(Order order)
        {  
                        /* Admin, yönetici veya satış görevlisi yapabilir sadece! */
            if(!User.IsInRole(Role.Admin) && !User.IsInRole(Role.Manager )&& !User.IsInRole(Role.Salesman)  )
                        return Forbid();

                /* SAtış elemanı gelen siparin bir kısmını girmiştir, kendisi kaldığı yerden devam edecektir. Girmiş oldu ksıımlar için sonraki adımdaki eleman çalışabilecektir. */
              _orderService.CreateOrder(order);              
              _orderService.SetNewStep(order.ID,Step.PartialPriceAsk,Status.PriceAndOrderEntry,MariAction.PartialNextStep);
              return order;
        }
        
        [HttpPost("CreatePausedOrder")]
        public  ActionResult<Order>  CreatePauseOrder(Order order)
        {  
            /* Admin, yönetici veya satış görevlisi yapabilir sadece! */
            if(!User.IsInRole(Role.Admin) && !User.IsInRole(Role.Manager )&& !User.IsInRole(Role.Salesman)  )
                        return Forbid();

                /* Satış elemanı gelen siparin bir kısmını girmiştir, kalan ksımında kimse çalışmayacak kendisi çalışmaya devam edecektir.*/
              _orderService.CreateOrder(order);                
              _orderService.SetNewStep(order.ID,Step.OrderEntry,Status.OrderPaused,MariAction.PauseStep);
              return order;          
        }
    }
}