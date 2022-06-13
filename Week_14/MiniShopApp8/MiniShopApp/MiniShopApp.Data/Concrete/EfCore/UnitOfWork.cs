using MiniShopApp.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShopApp.Data.Concrete.EfCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MiniShopContext _context;

        public UnitOfWork(MiniShopContext context)
        {
            _context = context;
        }
        private EfCoreCardRepository _cardRepository;
        private EfCoreCategoryRepository _categoryRepository;
        private EfCoreOrderRepository _orderRepository;
        private EfCoreProductRepository _productRepository;
        public ICardRepository Cards => _cardRepository = _cardRepository ?? new EfCoreCardRepository(_context);  //boş gelmişse (yoksa) oluştur demek için 

        public ICategoryRepository Category => _categoryRepository = _categoryRepository ?? new EfCoreCategoryRepository(_context);

        public IOrderRepository Order => _orderRepository = _orderRepository ?? new EfCoreOrderRepository(_context) ;

        public IProductRepository Product => _productRepository = _productRepository ?? new EfCoreProductRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
