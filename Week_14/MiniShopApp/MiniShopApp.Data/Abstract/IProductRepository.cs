﻿using MiniShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShopApp.Data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        //Product'a özgü metot ve memberlarımı buraya yazabilirim.
        List<Product> GetProductsByCategory(string name);
    }
}
