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
                .Property(x => x.UseBlocks)
                .IsRequired();

            builder
                .Property(x => x.TextBlocks)
                .HasMaxLength(100)
                .HasConversion(
                    x => JsonSerializer.Serialize(x, (JsonSerializerOptions)null),
                    x => JsonSerializer.Deserialize<List<string>>(x, (JsonSerializerOptions)null),
                    new ValueComparer<List<string>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => (List<string>)c.ToList()))
                .IsRequired();

            new TranslateSeeding().Seeding(builder);
        }
    }
}
