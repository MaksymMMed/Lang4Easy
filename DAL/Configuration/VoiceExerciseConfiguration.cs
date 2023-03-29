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
    public class VoiceExerciseConfiguration : IEntityTypeConfiguration<VoiceExercise>
    {
        public void Configure(EntityTypeBuilder<VoiceExercise> builder)
        {
            builder
                .Property(x => x.TextToSay)
                .HasMaxLength(100)
                .IsRequired();

            new VoiceSeeding().Seeding(builder);
        }
    }
}
