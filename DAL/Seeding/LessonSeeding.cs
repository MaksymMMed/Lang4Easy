using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seeding
{
    public class LessonSeeding
    {
        List<Lesson> LessonList = new()
        {
            new Lesson()
            {
                Id = 1,
                LessonName = "lesson1",
                LessonDescription = "it is first lesson",
                Exercises = new List<Exercise>()
            },
            new Lesson()
            {
                Id = 2,
                LessonName = "lesson2",
                LessonDescription = "it is second lesson",
                Exercises = new List<Exercise>()
            }

        };

        public void Seeding(EntityTypeBuilder<Lesson> builder) => builder.HasData(LessonList);

    }
}
