using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_2504.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_2504.DAL.Concrete.EF.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.BookId);
            builder.Property(b => b.BookName).IsRequired();
            builder.Property(b => b.BookPrice).HasDefaultValue(0);
            builder.Property(b => b.BookCreatedDate).HasDefaultValue(DateTime.Now);

            builder.HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
                new Book {BookId=1, BookName="Yönetim Bilişim Sistemleri", BookImageUrl= "https://www.kelepirkitap.com/Uploads/UrunResimleri/nobel-yayinlari-yonetim-bilisim-sistemle-7411.jpg", CategoryId=1 },
                new Book {BookId=2, BookName="A dan Z ye php", BookImageUrl= "https://wmscripti.com/wp-content/uploads/2014/12/seckin-azphp.png", CategoryId=2 },
                new Book {BookId=3, BookName="Sefiller", BookImageUrl= "https://kitapdostum.com/Content/Images/Kitap/302276.jpg", CategoryId=3 }
                );

        }
    }
}
