
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mari7.Models
{
    public class UserRole
    {

        public int ID { get; set; }       
        public MariUser User { get; set; } /* ForeignKey */
        public long UserID { get; set; } /* ilgili user */         
         public int RoleID { get; set; } /* izin verilen roller */
        public MariRole Role { get; set; } /* Foreignkey */
        
    public long InsertUser { get; set; }
    
    public long UpdateUser { get; set; }
    public long UpdateDate { get; set; }
    public long InsertDate { get; set; }

    }

}