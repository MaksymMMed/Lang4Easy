using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DAL.Seeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace DAL.Configuration
{
    public class TranslateExerciseConfiguration : IEntityTypeConfiguration<TranslateExercise>
    {
        public void Configure(EntityTypeBuilder<TranslateExercise> builder)
        {
            builder
                .Property(x => x.Question)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasOne(x => x.Lesson)
                .WithMany(x => x.TranslateExercises);

            new TranslateSeeding().Seeding(builder);
        }
    }
}
