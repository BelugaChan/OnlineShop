using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    [Table("Users")]
    public class User : IdentityUser
    {
        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiry { get; set; }
    }
}