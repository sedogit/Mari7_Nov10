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
    public class InvoiceController : ControllerBase
    {
/*         private readonly IConfiguration Configuration;
         public InvoiceController(IConfiguration configuration)
        {
                    Configuration = configuration;
        }  */
      private readonly MariContext _context;
       
        public InvoiceController(MariContext context)
        {
            _context = context;        
        } 
        [HttpGet]
        public ActionResult<List<Invoice>> GetAll()
        {
            return _context.Invoices.ToList();
        }
         [HttpPost]
        public  ActionResult<List<Invoice>>  Create(Invoice Invoice)
        {  
                //_context.Invoices.Add(new Invoice { ID=id });
                _context.Invoices.Add(Invoice);
                _context.SaveChanges();
                return _context.Invoices.ToList();
        }

    }
}