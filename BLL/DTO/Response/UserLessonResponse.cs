using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Response
{
    public class UserLessonResponse
    {
        public int Id { get; set; }
        public string? LessonName { get; set; }
        public string? LessonDescription { get; set; }

        public List<UserGrammarExerciseResponse>? GrammarExercises { get; set; }
        public List<UserVoiceExerciseResponse>? VoiceExercises { get; set; }
        public List<UserTranslateExerciseResponse>? TranslateExercises { get; set; }
    }
}
