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
    public class VoiceExerciseRepository : GenericRepository<VoiceExercise>, IVoiceExerciseRepository
    {
        public VoiceExerciseRepository(Context context) : base(context)
        {
        }

        public async Task<VoiceExercise> FindByData(string Name, int LessonId, string Question, string Answer)
        {
            var item = await table.Where(x => x.LessonId == LessonId && x.TextToSay == Question
            && x.Answer == Answer && x.Name == Name).FirstOrDefaultAsync();
            return item!;
        }

        public override async Task<VoiceExercise> GetById(int id)
        {
            var item = await table.Where(x => x.Id == id).FirstOrDefaultAsync();
            return item!;
        }
    }
}
