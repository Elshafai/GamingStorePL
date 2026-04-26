using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Device : BassEntity
    {
        [MaxLength(50)]
        public string Icon { get; set; } = string.Empty;
        public ICollection<GameDevice> GameDevices { get; set; } = new HashSet<GameDevice>();
    }
}
