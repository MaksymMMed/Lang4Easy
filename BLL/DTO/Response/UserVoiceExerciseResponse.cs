using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Response
{
    public class UserVoiceExerciseResponse
    {
        public int IdUser { get; set; }
        public int IdExercise { get; set; }

        public User? User { get; set; }
        public VoiceExercise? VoiceExercise { get; set; }
        public bool Status { get; set; }
    }
}
