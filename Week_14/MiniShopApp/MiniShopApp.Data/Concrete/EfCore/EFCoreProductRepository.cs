﻿using Microsoft.EntityFrameworkCore;
using MiniShopApp.Data.Abstract;
using MiniShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShopApp.Data.Concrete.EfCore
{
    public class EFCoreProductRepository : EfCoreGenericRepository<Product, MiniShopContext>, IProductRepository
    {
        private string ConvertLower(string text)
        {
            //İstanbul Irak Üzgün Şelaleler Satırarası
            text = text.Replace("I", "i");//İstanbul irak Üzgün Şelaleler Satırarası
            text = text.Replace("İ", "i");//istanbul irak Üzgün Şelaleler Satırarası
            text = text.Replace("İ", "i");//istanbul irak Üzgün Şelaleler Satirarasi

            text = text.ToLower();//istanbul irak üzgün şelaleler satirarasi
            text = text.Replace("ç", "c");
            text = text.Replace("ö", "o");
            text = text.Replace("ü", "u");
            text = text.Replace("ş", "s");
            text = text.Replace("ğ", "g");
            return text;
        }
        public List<Product> GetSearchResult(string searchString)
        {
            searchString = ConvertLower(searchString);
            //Burada metodun döndürdüğü değer string ama biz linq sorgularıyla çalışırken işimize yaramıyor düzeltilecek 
            using (var context = new MiniShopContext())
            {
                var products = context
                    .Products
                    .Where(i => i.IsApproved && (ConvertLower(i.Name).Contains(searchString) || ConvertLower(i.Description).Contains(searchString)))
                    .ToList();
                return products;
            }
        }
        public List<Product> GetHomePageProducts()
        {
            using (var context = new MiniShopContext())
            {
                return context
                    .Products
                    .Where(i => i.IsApproved && i.IsHome)
                    .ToList();
            }
        }

        public Product GetProductDetails(string url)
        {
            using (var context = new MiniShopContext())
            {
                return context
                    .Products
                    .Where(i => i.Url == url)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .FirstOrDefault();
                //Buraya daha sonra ilgili ürünün kategori adını da getirecek eklemeler yapacağız
            }
        }

        //Burada görünmeseler de EfCoreGenericRepository classımızdaki tüm metotlar var.
        //Temel CRUD işlemlerini yapan 5 metot.
        public List<Product> GetProductsByCategory(string name)
        {
            using (var context = new MiniShopContext())
            {
                var products = context
                    .Products
                    .Where(i => i.IsApproved)
                    .AsQueryable(); //kontrol eklemek için eklemeseydik .ınclude diyerek devam edebilirdik.
                if (!string.IsNullOrEmpty(name))
                {
                    products = products
                        .Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.ProductCategories.Any(a => a.Category.Url == name));
                }
                return products.ToList();
            }
        }

      
    }
}
