
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mari7.Models
{
public class Currency
{

    public int ID { get; set; }
   
    [StringLength(10)]
    public string Code { get; set; }
  
    [StringLength(100)]
    public string Name { get; set; }
  
    
    public long InsertUser { get; set; }
    
    public long UpdateUser { get; set; }
    public long UpdateDate { get; set; }
    public long InsertDate { get; set; }
}

}