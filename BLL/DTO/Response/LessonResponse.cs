using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Response
{
    public class LessonResponse
    {
        public int Id { get; set; }
        public string? LessonName { get; set; }
        public string? LessonDescription { get; set; }
        
        public List<GrammarExercise>? GrammarExercises { get; set; }
        public List<VoiceExercise>? VoiceExercises { get; set; }
        public List<TranslateExercise>? TranslateExercises { get; set; }
    }
}
