using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seeding
{
    public class VoiceSeeding
    {
        public List<VoiceExercise> VoiceList = new List<VoiceExercise>()
        {
            new VoiceExercise()
            {
                Id = 5,
                LessonId = 1,
                Name = "Translate sentence",
                TextToSay = "You ate yesterday",
                Answer = "Ти їв учора?",
                Type = VoiceExercise.TypeOfExercise.Listen
            },
            new VoiceExercise()
            {
                Id = 6,
                LessonId = 2,
                Name = "Translate sentence",
                Answer = "You ate yesterday",
                TextToSay = "You ate yesterday",
                Type = VoiceExercise.TypeOfExercise.Repeat
            },
        };

        public void Seeding(EntityTypeBuilder<VoiceExercise> builder) => builder.HasData(VoiceList);
    }
}
