using Microsoft.EntityFrameworkCore;
using Okul.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul.DAL.Concrete
{
    public class OkulDbContext : DbContext
    {
        public OkulDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Departmen> Departmens { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentLesson> StudentLessons { get; set; }

        
    }
    
    
}
