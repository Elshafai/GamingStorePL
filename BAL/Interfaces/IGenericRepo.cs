using BLL.Specification;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGenericRepo<T> where T : BassEntity
    {
        public void Create(T Entity);
        public void Update(T Entity);
        public void Delete(T Entity);
        public T? Get(int id);
        public IEnumerable<T> GetAll();
        public T? GetWithSpec(ISpecification<T> Spec);
        public IEnumerable<T> GetAllWithSpec(ISpecification<T> Spec);
    }
}
