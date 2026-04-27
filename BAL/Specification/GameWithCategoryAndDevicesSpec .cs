using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Specification
{
    public class GameWithCategoryAndDevicesSpec : BassSpecification<Game>
    {
        public GameWithCategoryAndDevicesSpec() : base(g => true)
        {
            IncludeExpressions.Add(q => q.Include(g => g.Category));
            IncludeExpressions.Add(query =>
                query.Include(g => g.GameDevices)
                     .ThenInclude(gd => gd.Device));
        }
        public GameWithCategoryAndDevicesSpec(int id) : base(g => g.Id == id)
        {
            IncludeExpressions.Add(q => q.Include(g => g.Category));
            IncludeExpressions.Add(query =>
                query.Include(g => g.GameDevices)
                     .ThenInclude(gd => gd.Device));
        }
    }
}
