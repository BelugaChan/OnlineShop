using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Nightlights")]
    public class Nightlight : Product
    {
        public string Company { get; set; } = string.Empty;

        public string CountryProduction { get; set; } = string.Empty;

        public int ExpirationDate { get; set; }
    }
}