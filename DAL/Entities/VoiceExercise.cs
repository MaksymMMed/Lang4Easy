using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class VoiceExercise:Exercise
    {
        public enum TypeOfExercise
        {
            Listen,
            Repeat
        }
        public string? TextToSay { get; set; } 
        public TypeOfExercise Type { get; set; }
    }
}
