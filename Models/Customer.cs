
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mari7.Models
{
public class Customer
{

    public long ID { get; set; }

    [StringLength(250)]
    public string Name { get; set; }

    [StringLength(100)]    
    public string IMONumber { get; set; }

    [StringLength(100)]
    public string Type { get; set; }

    [StringLength(250)]
    public string CustomerFirm { get; set; }

       
    public long InsertUser { get; set; }
    

    public long UpdateUser { get; set; }
    public long UpdateDate { get; set; }
    public long InsertDate { get; set; }
}

}