using DAL.Configuration;
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
        public virtual DbSet<Exercise> Exercise { get; set; }
        public virtual DbSet<CompleteStatus> CompleteStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new VoiceExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new GrammarExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new TranslateExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new CompleteStatusConfiguration());
        }
    }
}
