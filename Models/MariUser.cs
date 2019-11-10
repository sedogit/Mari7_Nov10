
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mari7.Models
{
    public class MariUser
    {

        public long ID { get; set; }
        [StringLength(100)]
        public string Username { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }        
        public List<UserRole> RoleList { get; set; }        

    public long InsertUser { get; set; }
   
    public long UpdateUser { get; set; }
    public long UpdateDate { get; set; }
    public long InsertDate { get; set; }

    }

}