using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class TranslateExercise:Exercise
    {
        public string? Question { get; set; }
        public bool UseBlocks { get; set; }
        public List<string>? TextBlocks { get; set; }
    }
}
