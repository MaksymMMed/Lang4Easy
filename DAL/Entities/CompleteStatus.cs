using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class CompleteStatus
    {
        public int UserId { get; set; }
        public User? User { get; set; }
        public int ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }
        public bool Status { get; set; }
    }
}
