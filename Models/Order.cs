
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mari7.Models
{
    public class Order
    {
        public long ID { get; set; }

        [StringLength(100)]
        public string RFQ   { get; set; }
        public int ETA {get;set;} /* datetime */

        [StringLength(100)]
        public string DeliveryPlace { get; set; }
        public long CustomerID { get; set; }  
        [StringLength(250)]
        public string IMO { get; set; }
        [StringLength(250)]
        public string Firm { get; set; }
        [StringLength(250)]
        public string CustomerName { get; set; }
        public ICollection<OrderDetail> Detail { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        [StringLength(20)]
        public string Currency { get; set; }
        public long CurrentUserID { get; set; }
        public int OrderStatus { get; set; } /* Eksik girişli havuzda, Havuzda, Fiyat Alındı, Teklif verildi, Teklif onaylandı..... */
        public int CurrentStepID { get; set; } /* içinde bulunduğu stepID */
        public int PrevStepID { get; set; }
        public int RequestDate { get; set; }
        public int CompletionDate { get; set; }

public long EntryUserID { get; set; }
public long PriceAskUserID { get; set; }
public long SaleOfferUserID { get; set; }
public long SaleApprovedUserID { get; set; }
public long PurchasePlacedUserD {get;set;}
public long OperationUserID { get; set; }
public long DeliveryUserID { get; set; }
public long AccountantUserID { get; set; }


    public long InsertUser { get; set; }

    public long UpdateUser { get; set; }
    public long UpdateDate { get; set; }
    public long InsertDate { get; set; }


    }

}