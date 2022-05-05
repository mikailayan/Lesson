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
        List<Student> GetPopularStudens();
    }
}
