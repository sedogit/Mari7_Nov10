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
    public class CustomerController : ControllerBase
    {
/*         private readonly IConfiguration Configuration;
         public CustomerController(IConfiguration configuration)
        {
                    Configuration = configuration;
        }  */
      private readonly MariContext _context;
       
        public CustomerController(MariContext context)
        {
            _context = context;
        } 
        [HttpGet]
        public ActionResult<List<Customer>> GetAll()
        {
            return _context.Customers.ToList();
        }
         [HttpPost]
        public  ActionResult<List<Customer>>  Create(Customer Customer)
        {  
                //_context.Customers.Add(new Customer { ID=id });
                _context.Customers.Add(Customer);
                _context.SaveChanges();
                return _context.Customers.ToList();
        }

    }
}