using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUniteOfWork : IDisposable
    {
        public IGenericRepo<T> GetGenericRepo<T>() where T : BassEntity;
        public int Complete();
    }
}
