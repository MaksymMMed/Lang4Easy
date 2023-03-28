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
    public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(Context context) : base(context)
        {
        }

        public override async Task<Lesson> GetById(int id)
        {
            var item = await table.Where(x=>x.Id == id).Include(x=>x.GrammarExercises).Include(x=>x.TranslateExercises)
                .Include(x=>x.VoiceExercises).FirstAsync();
            return item;
        }
    }
}
