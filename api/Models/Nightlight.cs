using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Nightlight
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string PicLink { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }

        public string Company { get; set; } = String.Empty;

        public string CountryProduction { get; set; } = string.Empty;

        public int ExpirationDate { get; set; }
    }
}