using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Specification
{
    public interface ISpecification<T> where T : BassEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Func<IQueryable<T>, IQueryable<T>>> IncludeExpressions { get; }
    }
}
