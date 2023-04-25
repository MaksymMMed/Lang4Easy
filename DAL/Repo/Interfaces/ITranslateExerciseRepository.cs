using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.Interfaces
{
    public interface ITranslateExerciseRepository:IRepository<TranslateExercise>
    {
        Task<TranslateExercise> FindByData(string Name, int LessonId, string Question, string Answer);
    }
}
