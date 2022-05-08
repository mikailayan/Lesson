using Okul.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul.DAL.Abstract
{
    public interface IStudentRepository : IRepository<Student>
    {
        public void GetWithDepartmen();
        public Student GetByIdwithLessons(int id);
    }
}
