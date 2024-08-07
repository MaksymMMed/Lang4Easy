﻿using DAL.Entities;
using DAL.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.Realizations
{
    public class TranslateExerciseRepository : GenericRepository<TranslateExercise>, ITranslateExerciseRepository
    {
        public TranslateExerciseRepository(Context context) : base(context)
        {
        }

        public override async Task<TranslateExercise> GetById(int id)
        {
            var item = await table.Where(x => x.Id == id).FirstOrDefaultAsync();
            return item!;
        }

        public async Task<TranslateExercise> FindByData(string Name, int LessonId, string Question, string Answer)
        {
            var item = await table.Where(x => x.LessonId == LessonId && x.Question == Question
            && x.Answer == Answer && x.Name == Name).FirstOrDefaultAsync();
            return item!;
        }
    }
}
