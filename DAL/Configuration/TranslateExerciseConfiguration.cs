using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .Property(x => x.UseBlocks)
                .IsRequired();

            builder
                .Property(x => x.UseBlocks)
                .HasMaxLength(10)
                .IsRequired();

        }
    }
}
