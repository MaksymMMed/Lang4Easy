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
    public class TranslateSeeding
    {
        public List<TranslateExercise> TranslateList = new List<TranslateExercise>()
        {
            new TranslateExercise()
            {
                Id = 3,
                LessonId = 1,
                Name = "Translate sentence",
                Question = "Ти їв вчора?",
                Answer = "You ate yesterday?",
                UseBlocks = true,
                TextBlocks = new(){"You","ate","yesterday?"},

            },
            new TranslateExercise()
            {
                Id = 4,
                LessonId = 2,
                Name = "Translate sentence",
                Question = "You ate yesterday?",
                Answer = "Ти їв учора?",
                UseBlocks = false,
                TextBlocks = new(){},
            }
        };

        public void Seeding(EntityTypeBuilder<TranslateExercise> builder) => builder.HasData(TranslateList);
    }
}
