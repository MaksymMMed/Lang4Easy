using DAL.Entities;
using DAL.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasDiscriminator<string>("ExerciseType")
                .HasValue<GrammarExercise>("Grammar")
                .HasValue<TranslateExercise>("Translate")
                .HasValue<VoiceExercise>("Voice");

            builder
                .Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x=>x.IsComplete) 
                .IsRequired();

            builder
                .Property(x => x.Answer)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasOne(x => x.Lesson)
                .WithMany(x => x.Exercises);

        }
    }
}
