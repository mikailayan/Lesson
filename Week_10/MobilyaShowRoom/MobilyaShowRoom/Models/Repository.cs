using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilyaShowRoom.Models
{
    public static class Repository
    {
        public static List<Product> AllProducts()
        {
            var products = new List<Product>
            {
                new Product {ID=540, ProductName="Sürgülü Kapılı Dolap", ProductDetail="Sürgülü Kapılı Dolap Aynalı Model", Price=4500, Resim="https://picsum.photos/id/120/500/900"},
                new Product {ID=545, ProductName="Soba Bacası", ProductDetail="Soba Bacası Tırtıklı", Price=5500,  Resim="https://picsum.photos/id/122/500/900"},
                new Product {ID=640, ProductName="Bisiklet Koltuğu", ProductDetail="Bisiklet Koltuğu Yumuşak", Price=6500,  Resim="https://picsum.photos/id/124/500/900"},
                new Product {ID=340, ProductName="Bebek Bezi", ProductDetail="Bebek Bezi Esktra Sızdırmaz", Price=7500,  Resim="https://picsum.photos/id/125/500/900"},
                new Product {ID=510, ProductName="İphone", ProductDetail="İphone 13 Pro 128GB", Price=8500,  Resim="https://picsum.photos/id/126/500/900"},
                new Product {ID=590, ProductName="Traş Makinesi", ProductDetail="Traş Makinesi Büyük Boy", Price=9500,  Resim="https://picsum.photos/id/128/500/900"}

            };
            return products;
        }
    }
}
