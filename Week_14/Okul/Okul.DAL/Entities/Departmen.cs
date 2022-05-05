using System.Collections.Generic;

namespace Okul.DAL.Entities
{
    public class Departmen
    {
        public int DepartmenId { get; set; }
        public string DepartmenName { get; set; }
        public string DepartmenHead { get; set; }

        public List<Student> Students { get; set; }

    }
}
