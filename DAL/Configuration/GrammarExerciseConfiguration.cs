using DAL.Entities;
using DAL.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class GrammarExerciseConfiguration : IEntityTypeConfiguration<GrammarExercise>
    {
        public void Configure(EntityTypeBuilder<GrammarExercise> builder)
        {

            builder
                .HasOne(x => x.Lesson)
                .WithMany(x => x.GrammarExercises);


            builder
                .Property(x => x.Question)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.Variables)
                .HasConversion(
                    x=> JsonSerializer.Serialize(x,(JsonSerializerOptions)null),
                    x => JsonSerializer.Deserialize<List<string>>(x, (JsonSerializerOptions)null),
                    new ValueComparer<List<string>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => (List<string>)c.ToList()))
                .HasMaxLength(100)
                .IsRequired();

            new GrammarSeeding().Seeding(builder);
        }
    }
}
