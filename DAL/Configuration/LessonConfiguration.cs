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
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.LessonName)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x=>x.LessonDescription)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .HasMany(x => x.Exercises)
                .WithOne(x => x.Lesson);
        }
    }
}
