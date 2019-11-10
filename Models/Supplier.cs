
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mari7.Models
{
public class Supplier
{


    public long ID { get; set; }
    [StringLength(100)]
    public string Name { get; set; }
    [StringLength(100)]
    public string Country { get; set; }
    [StringLength(500)]
    public string Description { get; set; }
   
    public long InsertUser { get; set; }
    
    public long UpdateUser { get; set; }
    public long UpdateDate { get; set; }
    public long InsertDate { get; set; }

}

}