using FinallyProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallyProject.Business.Abstract
{
    public interface IProductService
    {
        void Create(Product entity);
        void Delete(Product entity);
        void Update(Product entity);
        Task<Product> GetById(int entity);
        Task<IEnumerable<Product>> GetAll();
    }
}
