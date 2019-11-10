
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mari7.Models
{
    public class OrderDetail
    {
        public long ID { get; set; }
        public long OrderID { get; set; }
        public Order Order {get;set;}
        public long ProductID { get; set; }
        public Product Product { get; set; }
        [StringLength(250)]
        public string ProductNameTR { get; set; }
        [StringLength(250)]
        public string ProductNameEN { get; set; }
        public int StockQuantity { get; set; }
        public decimal StockUnitPrice { get; set; }
        public int PurchaseQuantity { get; set; }
        public int RequestedQuantity { get; set; }
        [StringLength(20)]
        public string Size {get;set;}        
        public decimal PrePurchaseUnitPrice { get; set; }
        public decimal PrePurchaseTotalPrice { get; set; }
        public long PrePurchaseSupplierID {get;set;}
        public int PrePurchaseDate { get; set; }
        public decimal PurchaseUnitPrice { get; set; }
        public decimal PurchaseTotalPrice { get; set; }        
        public long PurchaseSupplierID {get;set;}
        public int PurchaseDate { get; set; }
        public decimal ProfitRate {get;set;}
        public decimal SaleOfferUnitPrice { get; set; }
        public decimal SaleOfferTotalPrice { get; set; }
        public int SaleOfferDate { get; set; }
        public int SaleApprovalDate { get; set; }
        [StringLength(1000)]
        public string ReceiveOperationExpanation { get; set; }
        public int ReceiveDate { get; set; }

        [StringLength(1000)]
        public string DeliveryOperationExplanation { get; set; }
        public int DeliveryDate { get; set; }


    public long InsertUser { get; set; }

    public long UpdateUser { get; set; }
    public long UpdateDate { get; set; }
    public long InsertDate { get; set; }


    }

}