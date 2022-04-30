using System;
using System.Collections.Generic;
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
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Accepted { get; set; } = string.Empty;
        public Role? Role { get; set; }
        public int RoleId { get; set; }

    }
}