using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class GameDevice
    {
        public int GameId { get; set; }
        public Game Game { get; set; } = default!;
        public int DeviceId { get; set; }
        public Device Device { get; set; } = default!;
    }
}
