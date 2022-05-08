using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul.DAL.Entities
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        public int No { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public sbyte Period { get; set; }
        public int DepartmenId { get; set; }
        public Departmen Departmen { get; set; }
        public List<Lesson> SelectedLesson { get; set; }
    }
}
