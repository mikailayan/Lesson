using MiniShopApp.Data.Abstract;
using MiniShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShopApp.Data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category, MiniShopContext>, ICategoryRepository
    {
        //Burada görünmeselerde EfCoreGenericRepository classımızdaki tüm metotlar var.
        //Temel CRUD işlemlerini yapan 5 metot.
        public Category GetByIdWhithCategories(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
