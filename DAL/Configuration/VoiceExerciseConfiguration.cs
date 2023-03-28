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
    public class VoiceExerciseConfiguration : IEntityTypeConfiguration<VoiceExercise>
    {
        public void Configure(EntityTypeBuilder<VoiceExercise> builder)
        {
            builder
                .Property(x => x.TextToSay)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
