using DAL.Entities;
using DAL.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.Realizations
{
    public class GrammarExerciseRepository : GenericRepository<GrammarExercise>, IGrammarExerciseRepository
    {
        public GrammarExerciseRepository(Context context) : base(context)
        {
        }

        public async Task<GrammarExercise> FindByData(string Name, int LessonId, string Question, string Answer)
        {
            var item = await table.Where(x => x.LessonId == LessonId && x.Question == Question
            && x.Answer == Answer && x.Name == Name).FirstOrDefaultAsync();
            return item!;
        }

        public override async Task<GrammarExercise> GetById(int id)
        {
            var item = await table.Where(x => x.Id == id).FirstOrDefaultAsync();
            return item!;
        }
    }
}
