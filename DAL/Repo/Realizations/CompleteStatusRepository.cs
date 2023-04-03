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
    public class CompleteStatusRepository : GenericRepository<CompleteStatus>, ICompleteStatusRepository
    {
        public CompleteStatusRepository(Context context) : base(context)
        {
        }

        public override Task<CompleteStatus> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CompleteStatus> GetComplete(int userId, int exerciseId)
        {
            var item = await table.Where(x=>x.UserId == userId && x.ExerciseId  == exerciseId).FirstOrDefaultAsync();
            return item;
        }
    }
}
