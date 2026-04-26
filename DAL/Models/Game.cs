using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Game : BassEntity
    {
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [MaxLength(500)]
        public string Cover { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
        public ICollection<GameDevice> GameDevices { get; set; } = new HashSet<GameDevice>();
    }
}
