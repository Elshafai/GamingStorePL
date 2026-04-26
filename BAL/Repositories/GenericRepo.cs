using BLL.Interfaces;
using BLL.Specification;
using DAL.DBContext;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : BassEntity
    {
        private readonly AppDBContext dBContext;

        public GenericRepo(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
        } 
        public void Create(T Entity)
        {
            dBContext.Set<T>().Add(Entity);
        }
        public void Update(T Entity)
        {
            dBContext.Set<T>().Update(Entity);
        }
        public void Delete(T Entity)
        {
            dBContext.Set<T>().Remove(Entity);
        }

        public T? Get(int id)
        {
            return dBContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return dBContext.Set<T>().AsNoTracking().ToList();
        }
        private IQueryable<T> ApplySpec(ISpecification<T> specification) 
        {
            return SpecificationEvaluator<T>.GetQuary(dBContext.Set<T>(), specification);
        }
        public T? GetWithSpec(ISpecification<T> Spec)
        {
            return ApplySpec(Spec).FirstOrDefault();
        }

        public IEnumerable<T> GetAllWithSpec(ISpecification<T> Spec)
        {
            return ApplySpec(Spec).AsNoTracking().ToList();
        }

    }
}
