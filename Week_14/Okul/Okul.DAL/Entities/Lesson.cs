using System.Collections.Generic;

namespace Okul.DAL.Entities
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public string LessonTeacher { get; set; }
        public int LessonCredit { get; set; }
        public int LessonSemester { get; set; }
        public List<StudentLesson> StudentLessons { get; set; }
    }
}
