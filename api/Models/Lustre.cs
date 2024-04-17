using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Lustres")]
    public class Lustre : Product
    {
        public string Company { get; set; } = string.Empty;
        
        public int BulbCount { get; set; }

        public int Weight { get; set; }
    }
}