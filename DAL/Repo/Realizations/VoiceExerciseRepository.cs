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

        public override async Task<VoiceExercise> GetById(int id)
        {
            var item = await table.Where(x => x.Id == id).FirstOrDefaultAsync();
            return item!;
        }
    }
}
