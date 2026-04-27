using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Specification
{
    public class BassSpecification<T> : ISpecification<T> where T : BassEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set;}
        //public List<Expression<Func<T, object>>> Includes { get; set;} = new List<Expression<Func<T, object>>>();
        public List<Func<IQueryable<T>, IQueryable<T>>> IncludeExpressions { get; private set; }
            = new List<Func<IQueryable<T>, IQueryable<T>>>();
        public BassSpecification(Expression<Func<T, bool>> CriteriaExpression)
        {
            this.Criteria = CriteriaExpression;
        }
    }
}
