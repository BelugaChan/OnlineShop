using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Lamps")]
    public class Lamp : Product
    {
        public string Company { get; set; } = string.Empty;

        public int Power { get; set; } //мощность, ватт
    }
}