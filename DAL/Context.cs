using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<GrammarExercise> GrammarExercise { get; set; }
        public virtual DbSet<TranslateExercise> TranslateExercise { get; set; }
        public virtual DbSet<VoiceExercise> VoiceExercise { get; set; }
    }
}
