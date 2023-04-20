using DAL.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            IUserRepository userRepository,
            ILessonRepository lessonRepository,
            IVoiceExerciseRepository voiceExerciseRepository,
            IGrammarExerciseRepository grammarExerciseRepository,
            ITranslateExerciseRepository translateExerciseRepository,
            ICompleteStatusRepository completeStatusRepository)
        {
            this.UserRepository = userRepository;
            this.LessonRepository = lessonRepository;
            this.voiceExerciseRepository = voiceExerciseRepository;
            this.grammarExerciseRepository = grammarExerciseRepository;
            this.translateExerciseRepository = translateExerciseRepository;
            this.completeStatusRepository = completeStatusRepository;
        }

        public IUserRepository UserRepository { get; }

        public ILessonRepository LessonRepository { get; }

        public IVoiceExerciseRepository voiceExerciseRepository { get; }

        public IGrammarExerciseRepository grammarExerciseRepository { get; }

        public ITranslateExerciseRepository translateExerciseRepository { get; }

        public ICompleteStatusRepository completeStatusRepository { get; }
    }
}
