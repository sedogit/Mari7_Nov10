
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mari7.Models
{
    public class MariRole
    {
        public int ID { get; set; }       
         [Key]
        public int RoleID { get; set; } 
        [StringLength(50)]
        public string RoleName { get; set; }
        [StringLength(250)]
        public string RoleDescription { get; set; }

    public long InsertUser { get; set; }
   
    public long UpdateUser { get; set; }
    public long UpdateDate { get; set; }
    public long InsertDate { get; set; }

    }

}