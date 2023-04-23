using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Exercise
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Answer { get; set; }
        public int LessonId { get; set; }
        public Lesson? Lesson { get; set; }
        public List<CompleteStatus>? CompleteForUser { get; set; }
    }
}
