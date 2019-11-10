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
    public class OrderPoolController : ControllerBase
    {
/*         private readonly IConfiguration Configuration;
         public OrderPoolController(IConfiguration configuration)
        {
                    Configuration = configuration;
        }  */
      private readonly MariContext _context;
       
        public OrderPoolController(MariContext context)
        {
            _context = context;
        } 

        [HttpGet]
        public ActionResult<List<Order>> GetAll()
        {
            // Eğer yönetici veya admin ise tüm orderları çekebilsin.
            if (User.IsInRole(Role.Admin) ||User.IsInRole(Role.Manager))
                 return _context.Orders.ToList();

            // diğer userlar kendi rollerinin görebileceği ve tamamlanmamışları görebilsinler
            List<Order> allOrders = _context.Orders.ToList();
            List<Order>userOrders = new List<Order>();
            List<StepRole> stepRoles  = new List<StepRole>();          
            foreach(Order order in allOrders)
            {   
                stepRoles = _context.StepRoles.Where(x=>x.StepID == order.CurrentStepID).ToList();/* orderin bulunduğu step için izin verilen Rolleri alıyoruz */
                if(stepRoles.Any(x=>User.IsInRole(x.RoleID.ToString()))) /* Kullanıcın Rolu, Step rollerinden biri ise o orderi ekleyeceğiz. */
                {
                    order.Detail = _context.OrderDetails.Where(x=>x.OrderID == order.ID).ToList();/* her bir ordera one-to-many detaylarını da ekliyoruz. */
                    userOrders.Add(order);
                }              
            }
            return userOrders;
        }



    }
}