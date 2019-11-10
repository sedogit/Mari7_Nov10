
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mari7.Models
{
    public class Product
    {
        public long ID { get; set; }
        [StringLength(100)]
        public string Code { get; set; }
        [StringLength(100)]
        public string NameTR { get; set; }

         [StringLength(100)]
        public string NameEN { get; set; }
        [StringLength(1000)]
        public string DescriptionTR { get; set; }
        [StringLength(1000)]
        public string DescriptionEN { get; set; }

            
    public long InsertUser { get; set; }

        
        public long UpdateUser { get; set; }
        public long UpdateDate { get; set; }
        public long InsertDate { get; set; }

    }

}