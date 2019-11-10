
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mari7.Models
{
    public class OrderStep
    {
        public long ID { get; set; }
         [Key]
        public int StepID { get; set; }
        public Order Order { get; set; }
        public long OrderID { get; set; }
        public MariUser User { get; set; }
        public long UserID { get; set; }

        [StringLength(500)]
        public string StepExplanation { get; set; }

        public int OrderStatus { get; set; }

        public int ActionID { get; set; }

        public long ActionUserID { get; set; }

   
    public long InsertUser { get; set; }
    
    public long UpdateUser { get; set; }
    public long UpdateDate { get; set; }
    public long InsertDate { get; set; }


    }

}