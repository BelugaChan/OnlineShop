using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Flashlights")]
    public class Flashlight : Product
    {
        public string Company { get; set; } = string.Empty;

        public string Version { get; set; } = string.Empty;
    }
}