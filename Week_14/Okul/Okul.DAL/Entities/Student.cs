using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul.DAL.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurName { get; set; }
        public DateTime StudentDateOfBirth { get; set; }
        public DateTime StudentDateOfRegistration { get; set; }
        public sbyte StudentSemester { get; set; }
        public int DepartmenId { get; set; }
        public Departmen Departmen  { get; set; }
        public List<StudentLesson> StudentLessons { get; set; }

    }
}
