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
    public class SupplierController : ControllerBase
    {
/*         private readonly IConfiguration Configuration;
         public SupplierController(IConfiguration configuration)
        {
                    Configuration = configuration;
        }  */
      private readonly MariContext _context;
       
        public SupplierController(MariContext context)
        {
            _context = context;
        } 
        [HttpGet]
        public ActionResult<List<Supplier>> GetAll()
        {
            return _context.Suppliers.ToList();
        }
         [HttpPost]
        public  ActionResult<List<Supplier>>  Create(Supplier Supplier)
        {  
                //_context.Suppliers.Add(new Supplier { ID=id });
                _context.Suppliers.Add(Supplier);
                _context.SaveChanges();
                return _context.Suppliers.ToList();
        }

    }
}