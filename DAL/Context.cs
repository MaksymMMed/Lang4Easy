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

        public DbSet<User> User { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<GrammarExercise> GrammarExercise { get; set; }
        public DbSet<TranslateExercise> TranslateExercise { get; set; }
        public DbSet<VoiceExercise> VoiceExercise { get; set; }
    }
}
