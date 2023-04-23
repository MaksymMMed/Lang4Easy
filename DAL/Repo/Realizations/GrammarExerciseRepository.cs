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

        public override async Task<GrammarExercise> GetById(int id)
        {
            var item = await table.Where(x => x.Id == id).FirstOrDefaultAsync();
            return item!;
        }
    }
}
