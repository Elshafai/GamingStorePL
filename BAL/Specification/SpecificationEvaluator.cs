using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Specification
{
    public static class SpecificationEvaluator<TEntity> where TEntity : BassEntity
    {
        public static IQueryable<TEntity> GetQuary(IQueryable<TEntity> InputQuary, ISpecification<TEntity> specification)
        {
            var Quary = InputQuary;
            if(specification.Criteria is not  null)
                Quary = Quary.Where(specification.Criteria);
            Quary = specification.Includes.Aggregate(Quary, (Current, Include) => Current.Include(Include));
            return Quary;
        }
    }
}
