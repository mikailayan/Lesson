using Okul.DAL.Abstract;
using Okul.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul.DAL.Concrete.DAL
{
    public class StudentLessonDAL : BaseRepository<StudentLesson>, IStudentLessonRepository
    {
        public StudentLessonDAL(OkulDbContext context) : base(context)
        {

        }
        private OkulDbContext Context
        {
            get { return _context as OkulDbContext; }
        }

        public List<StudentLesson> GetPopularStudentLesson()
        {
            throw new NotImplementedException();
        }
    }
}