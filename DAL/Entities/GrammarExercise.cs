using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class GrammarExercise:Exercise
    {
        public string? Question { get; set; }
        public List<string>? Variables { get; set; }
        public bool UseVariables { get; set; }
    }
}
