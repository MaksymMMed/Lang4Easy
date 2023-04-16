using AutoMapper;
using BLL.DTO.Request;
using BLL.DTO.Response;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repo.Interfaces;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Realizations
{
    public class LessonService : ILessonService
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;

        public LessonService(IUnitOfWork unit, IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        public async Task AddLesson(LessonRequest request)
        {
            var item = mapper.Map<Lesson>(request);
            await unit.LessonRepository.Insert(item);
        }

        public async Task DeleteLesson(int id)
        {
            await unit.LessonRepository.Delete(id);
        }

        public async Task<LessonResponse> GetLessonById(int id)
        {
            var item = await unit.LessonRepository.GetById(id);
            return mapper.Map<LessonResponse>(item);
        }

        public async Task<IEnumerable<LessonResponse>> GetLessons()
        {
            var items = await unit.LessonRepository.GetAll();
            return mapper.Map<IEnumerable<Lesson>,IEnumerable<LessonResponse>>(items); 
        }

        public async Task<IEnumerable<UserLessonResponse>> GetUserLessons(int UserId)
        {
            var user = await unit.UserRepository.GetById(UserId);
            var lessons = await unit.LessonRepository.GetAll();
            List<UserLessonResponse> userLessons = new List<UserLessonResponse>();


            foreach (var lesson in lessons)
            {
                UserLessonResponse userLesson = new UserLessonResponse();

                userLesson.Id = lesson.Id;
                userLesson.LessonName = lesson.LessonName;
                userLesson.LessonDescription = lesson.LessonDescription;

              
                List<UserGrammarExerciseResponse> grammarExercises = new();
                List<UserVoiceExerciseResponse> voiceExercises = new();
                List<UserTranslateExerciseResponse> translateExercises = new();
                

                foreach (var exercise in user.CompletedExercise)
                {
                    if (exercise.Exercise is GrammarExercise && exercise.Exercise.LessonId == lesson.Id)
                    {
                        GrammarExercise Exercise = await unit.grammarExerciseRepository.GetById(exercise.ExerciseId);
                        UserGrammarExerciseResponse userExercise = new();

                        userExercise.IdUser = UserId;
                        userExercise.IdExercise = exercise.ExerciseId;
                        userExercise.Status = exercise.Status;
                        userExercise.User = exercise.User;
                        userExercise.GrammarExercise = Exercise;

                        grammarExercises.Add(userExercise);
                    }

                    if (exercise.Exercise is VoiceExercise && exercise.Exercise.LessonId == lesson.Id)
                    {
                        VoiceExercise Exercise = await unit.voiceExerciseRepository.GetById(exercise.ExerciseId);
                        UserVoiceExerciseResponse userExercise = new();

                        userExercise.IdUser = UserId;
                        userExercise.IdExercise = exercise.ExerciseId;
                        userExercise.Status = exercise.Status;
                        userExercise.User = exercise.User;
                        userExercise.VoiceExercise = Exercise;

                        voiceExercises.Add(userExercise);
                    }

                    if (exercise.Exercise is TranslateExercise && exercise.Exercise.LessonId == lesson.Id)
                    {
                        TranslateExercise Exercise = await unit.translateExerciseRepository.GetById(exercise.ExerciseId);
                        UserTranslateExerciseResponse userExercise = new();

                        userExercise.IdUser = UserId;
                        userExercise.IdExercise = exercise.ExerciseId;
                        userExercise.Status = exercise.Status;
                        userExercise.User = exercise.User;
                        userExercise.TranslateExercise = Exercise;

                        translateExercises.Add(userExercise);
                    }
                    
                }

                userLesson.VoiceExercises = voiceExercises;
                userLesson.TranslateExercises = translateExercises;
                userLesson.GrammarExercises = grammarExercises;

                userLessons.Add(userLesson);

            }
           
            return userLessons;
        }

        public async Task UpdateLesson(LessonRequest request)
        {
            var item = mapper.Map<Lesson>(request);
            await unit.LessonRepository.Update(item);
        }
    }
}
