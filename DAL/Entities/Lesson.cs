using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public string? LessonName { get; set; }
        public string? LessonDescription { get; set;}
        public virtual List<GrammarExercise>? GrammarExercises { get; set; }
        public virtual List<VoiceExercise>? VoiceExercises { get; set; }
        public virtual List<TranslateExercise>? TranslateExercises { get; set; }
    }
}
