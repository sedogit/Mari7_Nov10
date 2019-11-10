
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mari7.Models
{

public class ProductPrice
{

    public long ID { get; set; }
    public Product Product { get; set; }
    public long ProductID {get;set;}
    public Supplier Supplier { get; set; }
    public long SupplierID {get;set;}
    public int PriceDate { get; set; }
    public int MinQuantity { get; set; }
    public decimal UnitPrice { get; set; }
    
    [StringLength(20)]
    public string Size { get; set; }
  
  public Currency Currency { get; set; }
    public int CurrencyID { get; set; }

   
    public long InsertUser { get; set; }
    
    public long UpdateUser { get; set; }
    public long UpdateDate { get; set; }
    public long InsertDate { get; set; }

}

}