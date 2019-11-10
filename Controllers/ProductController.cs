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
    
       [ApiController]
    [Route("api/[controller]")]   
    public class ProductController : ControllerBase
    {
/*         private readonly IConfiguration Configuration;
         public ProductController(IConfiguration configuration)
        {
                    Configuration = configuration;
        }  */
      private readonly MariContext _context;
       
        public ProductController(MariContext context)
        {
            _context = context;
         if (_context.Products.Count() == 0)
            {
                _context.Products.Add(new Product { ID = 1 , NameEN="Dummy", Code="DUMMY"});
                 _context.SaveChanges();
            }
        } 
        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return _context.Products.ToList();
        }
         [HttpPost]
        public  ActionResult<List<Product>>  Create(Product product)
        {  
                //_context.Products.Add(new Product { ID=id });
                if(_context.Products.Where(x=>x.Code == product.Code) !=null)
                return BadRequest(new { message = "Ürün zaten kayıtlı!"});

                _context.Products.Add(product);
                _context.SaveChanges();
                return _context.Products.ToList();
        }

    }
}