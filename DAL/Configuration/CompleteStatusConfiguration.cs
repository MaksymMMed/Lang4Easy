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
    public class CompleteStatusConfiguration : IEntityTypeConfiguration<CompleteStatus>
    {
        public void Configure(EntityTypeBuilder<CompleteStatus> builder)
        {
            builder
                .HasKey(x => new
                {
                    x.UserId,
                    x.ExerciseId
                });

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.CompletedExercise)
                .HasForeignKey(x => x.UserId);

            builder
                .HasOne(x => x.Exercise)
                .WithMany(x => x.CompleteForUser)
                .HasForeignKey(x => x.ExerciseId);

            builder
                .Property(x => x.Status)
                .IsRequired();

            new CompleteStatusSeeding().Seeding(builder);
        }
    }
}
