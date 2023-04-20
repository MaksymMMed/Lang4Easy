using DAL.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ILessonRepository LessonRepository { get; }
        IVoiceExerciseRepository voiceExerciseRepository { get; }
        IGrammarExerciseRepository grammarExerciseRepository { get; }
        ITranslateExerciseRepository translateExerciseRepository { get; }
        ICompleteStatusRepository completeStatusRepository { get; }
    }
}
