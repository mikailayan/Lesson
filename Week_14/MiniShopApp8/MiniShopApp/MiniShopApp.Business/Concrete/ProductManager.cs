using MiniShopApp.Business.Abstract;
using MiniShopApp.Data.Abstract;
using MiniShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShopApp.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Product entity)
        {
            throw new NotImplementedException();
            
        }

        public void Create(Product entity, int[] categoryIds)
        {
            _unitOfWork.Product.Create(entity, categoryIds);
            _unitOfWork.Save();
        }

        public void Delete(Product entity)
        {
            _unitOfWork.Product.Delete(entity);
            _unitOfWork.Save();

        }

        public List<Product> GetAll()
        {
            //Burada ürünlerin listelenmesi sağlanıyor.
            //Fakat ürün listeleme yapan metot çalıştırılmadan önce
            //Burada çeşitli iş kuralları uygulanacak.(Validation vb.)
            //Bunu daha sonra yazacağız.
            return _unitOfWork.Product.GetAll();
        }

        public Product GetById(int id)
        {
            return _unitOfWork.Product.GetById(id);
        }

        public Product GetByIdWithCategories(int id)
        {
            return _unitOfWork.Product.GetByIdWithCategories(id);
        }

        public int GetCountByCategory(string category)
        {
            return _unitOfWork.Product.GetCountByCategory(category);
        }

        public List<Product> GetHomePageProducts()
        {
            return _unitOfWork.Product.GetHomePageProducts();
        }

        public Product GetProductDetails(string url)
        {
            return _unitOfWork.Product.GetProductDetails(url);
        }

        public List<Product> GetProductsByCategory(string name, int page, int pageSize)
        {
            return _unitOfWork.Product.GetProductsByCategory(name, page, pageSize);
        }

        public List<Product> GetSearchResult(string searchString)
        {
            return _unitOfWork.Product.GetSearchResult(searchString);
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity, int[] categoryIds)
        {
            _unitOfWork.Product.Update(entity, categoryIds);
            _unitOfWork.Save();

        }

    }
}
