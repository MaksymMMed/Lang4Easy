using AutoMapper;
using BLL.DTO.Response;
using BLL.MapperConfig;
using BLL.Services.Realizations;
using DAL.Entities;
using DAL.Repo.Interfaces;
using FakeItEasy;
namespace Tests.Services
{
    public class LessonServiceTest
    {
        private static IMapper Mapper;

        public LessonServiceTest()
        {
            if (Mapper == null)
            {
                var mappingConfig = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MapperProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                Mapper = mapper;
            }
        }

        [Fact]
        public async Task LessonService_GetLessonById_ReturnLessonById()
        {
            //Arrange
            var Repo = A.Fake<ILessonRepository>();
            A.CallTo(() => Repo.GetById(1)).Returns(new Lesson()
            {
                Id = 1,
                LessonDescription = "none",
                LessonName = "none",
                GrammarExercises = new List<GrammarExercise>(),
                VoiceExercises = new List<VoiceExercise>(),
                TranslateExercises = new List<TranslateExercise>()
            });

            LessonResponse expectedResponse = new LessonResponse()
            {
                Id = 1,
                LessonDescription = "none",
                LessonName = "none",
                GrammarExercises = new List<GrammarExercise>(),
                VoiceExercises = new List<VoiceExercise>(),
                TranslateExercises = new List<TranslateExercise>()
            };

            var Service = new LessonService(Repo, Mapper);

            //Act
            var actualResponse = await Service.getLessonById(1);

            //Assert 
            Assert.Equivalent(expectedResponse,actualResponse);
        }
    }
}
