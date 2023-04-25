using AutoMapper;
using BLL.DTO.Request;
using BLL.DTO.Response;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MapperConfig
{
    public class MapperProfile:Profile
    {
        void LessonProfile()
        {
            CreateMap<Lesson, LessonResponse>();
            CreateMap<LessonRequest, Lesson>();
        }
        void UserProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserRequest, User>();
        }
        void GrammarProfile()
        {
            CreateMap<GrammarExercise, GrammarExerciseResponse>();
            CreateMap<GrammarExerciseRequest, GrammarExercise>();
        }
        void VoiceProfile()
        {
            CreateMap<VoiceExercise,VoiceExerciseResponse>();
            CreateMap<VoiceExerciseRequest,VoiceExercise>();
        }
        void TranslateProfile()
        {
            CreateMap<TranslateExercise, TranslateExerciseResponse>();
            CreateMap<TranslateExerciseRequest, TranslateExercise>();
        }
        public MapperProfile()
        {
            LessonProfile();
            UserProfile();
            GrammarProfile();
            VoiceProfile();
            TranslateProfile();
        }
    }
}
