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
    public class ExerciseSeeding
    {
        public List<Exercise> UserList = new List<Exercise>()
        {
            new GrammarExercise()
            {
                Id = 1,
                LessonId = 1,
                Question = "_ done your homework?",
                Answer = "Have",
                Variables = new(){"Have","Has","Had"},
                IsComplete = false,
                Name = "Choose right verb"
            },
            new GrammarExercise()
            {
                Id = 2,
                LessonId = 2,
                Question = "Last month I _ to Scotland on holiday.",
                Answer = "Went",
                Variables = new(){"Go","Went"},
                IsComplete = false,
                Name = "Choose right verb"
            },
            new TranslateExercise()
            {
                Id = 3,
                LessonId = 1,
                Name = "Translate sentence",
                Question = "Ти їв вчора?",
                Answer = "You ate yesterday?",
                UseBlocks = true,
                TextBlocks = new(){"You","ate","yesterday?"},
                IsComplete = false

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
                IsComplete = false
            },

            new VoiceExercise()
            {
                Id = 5,
                LessonId = 1,
                Name = "Translate sentence",
                TextToSay = "You ate yesterday",
                Answer = "Ти їв учора?",
                IsComplete = false
            },
            new VoiceExercise()
            {
                Id = 6,
                LessonId = 2,
                Name = "Translate sentence",
                Answer = "You ate yesterday",
                TextToSay = "Ти їв учора?",
                IsComplete = false
            },
        };

        public void Seeding(EntityTypeBuilder<Exercise> builder) => builder.HasData(UserList);
    }
}
