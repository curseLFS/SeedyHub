using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedyHub.Shared
{
    public class Members
    {
        [Key]
        public int MemberId { get; set; }

        [Required(ErrorMessage ="Please enter {0}.")]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Suffix { get; set; } = string.Empty;
        public DateTime? Birthday { get; set; } = DateTime.Now;
        public string Image { get; set; } = string.Empty;
        public DateTime? Accepted { get; set; } = DateTime.Now;
        public Role? Role { get; set; }
        public int RoleId { get; set; }       
    }
}