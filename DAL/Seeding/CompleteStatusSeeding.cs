using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seeding
{
    public class CompleteStatusSeeding
    {
        List<CompleteStatus> List = new()
        {
            new CompleteStatus
            {
                ExerciseId = 1,
                UserId = 1,
                Status = true
            },
            new CompleteStatus
            {
                ExerciseId = 2,
                UserId = 1,
                Status = true
            },
            new CompleteStatus
            {
                ExerciseId = 3,
                UserId = 1,
                Status = false
            },
            new CompleteStatus
            {
                ExerciseId = 4,
                UserId = 1,
                Status = true
            },
            new CompleteStatus
            {
                ExerciseId = 5,
                UserId = 1,
                Status = false
            },
            new CompleteStatus
            {
                ExerciseId = 6,
                UserId = 1,
                Status = false
            },
            new CompleteStatus
            {
                ExerciseId = 1,
                UserId = 2,
                Status = true
            },
            new CompleteStatus
            {
                ExerciseId = 2,
                UserId = 2,
                Status = true
            },
            new CompleteStatus
            {
                ExerciseId = 3,
                UserId = 2,
                Status = false
            },
            new CompleteStatus
            {
                ExerciseId = 4,
                UserId = 2,
                Status = true
            },
            new CompleteStatus
            {
                ExerciseId = 5,
                UserId = 2,
                Status = true
            },
            new CompleteStatus
            {
                ExerciseId = 6,
                UserId = 2,
                Status = false
            },
        };
        public void Seeding(EntityTypeBuilder<CompleteStatus> builder) => builder.HasData(List); 
    }
}
