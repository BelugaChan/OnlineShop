using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Lustre
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;

        public string PicLink { get; set; } = String.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }

        public string Company { get; set; } = String.Empty;
        
        public int BulbCount { get; set; }

        public int Weight { get; set; }
    }
}