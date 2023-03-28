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
    public class GrammarExerciseConfiguration : IEntityTypeConfiguration<GrammarExercise>
    {
        public void Configure(EntityTypeBuilder<GrammarExercise> builder)
        {
            builder
                .Property(x => x.Question)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.Variables)
                .IsRequired();
        }
    }
}
