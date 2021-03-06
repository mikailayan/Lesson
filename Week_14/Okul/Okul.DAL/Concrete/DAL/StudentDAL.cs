using Microsoft.EntityFrameworkCore;
using Okul.DAL.Abstract;
using Okul.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul.DAL.Concrete.DAL
{
    public class StudentDAL : BaseRepository<Student>, IStudentRepository
    {
        public StudentDAL(OkulDbContext context) : base(context)
        {

        }
        private OkulDbContext Context
        {
            get { return _context as OkulDbContext; }
        }
        public Student GetByIdwithLessons(int id)
        {
 
                return Context.Students
                    .Where(x => x.StudentId == id)
                    .Include(x => x.StudentLessons)
                    .ThenInclude(x => x.Lesson)
                    .FirstOrDefault();
                    
            
        }
        public void GetWithDepartmen()
        {
            throw new NotImplementedException();
        }
    }
}