using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShopApp.Data.Abstract
{
    public interface IUnitOfWork: IDisposable //Tek bir nesneden diğer tüm repositorylerime erişebilmem için.
    {
        ICardRepository Cards { get; }
        ICategoryRepository Category { get; }
        IOrderRepository Order { get; }
        IProductRepository Product { get; }
        void Save();
    }
}
