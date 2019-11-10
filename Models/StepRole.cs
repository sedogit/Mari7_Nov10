using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mari7.Models
{
    public  class StepRole
    {
        public int ID { get; set; }       

        public int StepID { get; set; } /* ilgili step */
        public OrderStep Step { get; set; } /* foreignkey */

         public int RoleID { get; set; } /* izin verilen roller */
        public MariRole Role { get; set; } /* Foreignkey */

           
    public long InsertUser { get; set; }
    
    public long UpdateUser { get; set; }
    public long UpdateDate { get; set; }
    public long InsertDate { get; set; }
    }
}