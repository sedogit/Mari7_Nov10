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
using Mari7.Models;

namespace Mari7.Controllers
{
       [ApiController]
    [Route("api/[controller]")]   
    public class ProductPriceController : ControllerBase
    {
/*         private readonly IConfiguration Configuration;
         public ProductPriceController(IConfiguration configuration)
        {
                    Configuration = configuration;
        }  */
      private readonly MariContext _context;
       
        public ProductPriceController(MariContext context)
        {
            _context = context;
        } 
        [HttpGet]
        public ActionResult<List<ProductPrice>> GetAll()
        {
            return _context.ProductPrices.ToList();
        }
         [HttpPost]
        public  ActionResult<List<ProductPrice>>  Create(ProductPrice ProductPrice)
        {  
                //_context.ProductPrices.Add(new ProductPrice { ID=id });
                _context.ProductPrices.Add(ProductPrice);
                _context.SaveChanges();
                return _context.ProductPrices.ToList();
        }

    }
}