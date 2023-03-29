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
    public class GrammarSeeding
    {
        public List<GrammarExercise> GrammarList = new List<GrammarExercise>()
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
        };

        public void Seeding(EntityTypeBuilder<GrammarExercise> builder) => builder.HasData(GrammarList);
    }
}
