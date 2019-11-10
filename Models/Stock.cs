
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mari7.Models
{
    public class Stock
    {
        public long ID { get; set; }
        public long ProductID { get; set; }
        public Product Product {get;set;}
        public int Quantity { get; set; }
        [StringLength(20)]
        public string Size { get; set; }
        public decimal TotalPrice { get; set; }
        [StringLength(250)]
        public string PurchasedFrom { get; set; }

   
    public long InsertUser { get; set; }
    
    public long UpdateUser { get; set; }
    public long UpdateDate { get; set; }
    public long InsertDate { get; set; }

    }

}