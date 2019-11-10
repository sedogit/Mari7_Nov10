
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mari7.Models
{

public class Invoice
{

    public long ID  { get; set; }
    public long ProductID {get;set;}
  [StringLength(250)]
    public string ProductIMPACode { get; set; }
[StringLength(250)]
    public string ProductNameTR { get; set; }
[StringLength(250)]
    public string ProductNameEN { get; set; }
    public int RequestedQuantity { get; set; }
    public decimal SaleUnitPrice { get; set; }
    public decimal SaleTotalPrice { get; set; }
    [StringLength(250)]
    public string SupplierName { get; set; }
    public int SupplierID { get; set; }
    public int InvoiceDate { get; set; }
      
    public long InsertUser { get; set; }


    public long UpdateUser { get; set; }
    public long UpdateDate { get; set; }
    public long InsertDate { get; set; }

}

}