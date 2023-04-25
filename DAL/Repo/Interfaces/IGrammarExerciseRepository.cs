using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.Interfaces
{
    public interface IGrammarExerciseRepository:IRepository<GrammarExercise>
    {
        Task<GrammarExercise> FindByData(string Name, int LessonId, string Question, string Answer);
    }
}
