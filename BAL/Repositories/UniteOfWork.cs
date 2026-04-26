using BLL.Interfaces;
using DAL.DBContext;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly AppDBContext dBContext;
        private Hashtable _repos;
        public UniteOfWork(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
            _repos = new Hashtable();
        }
        public int Complete() => dBContext.SaveChanges();

        public void Dispose()=> dBContext.Dispose();

        public IGenericRepo<T> GetGenericRepo<T>() where T : BassEntity
        {
            var key = typeof(T).Name;

            if (!_repos.ContainsKey(key))
            {
                var repos = new GenericRepo<T>(dBContext);
                _repos.Add(key, repos);
            }
            return (IGenericRepo<T>)_repos[key]!;
        }
    }
}
