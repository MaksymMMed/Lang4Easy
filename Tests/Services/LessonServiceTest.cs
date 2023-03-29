using AutoMapper;
using BLL.DTO.Request;
using BLL.DTO.Response;
using BLL.MapperConfig;
using BLL.Services.Realizations;
using DAL.Entities;
using DAL.Repo.Interfaces;
using FakeItEasy;
using Xunit;

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
                Exercises = new List<Exercise>()
            });

            LessonResponse expectedResponse = new LessonResponse()
            {
                Id = 1,
                LessonDescription = "none",
                LessonName = "none",
                Exercises = new List<Exercise>()
            };

            var Service = new LessonService(Repo, Mapper);

            //Act
            var actualResponse = await Service.GetLessonById(1);

            //Assert 
            Assert.Equivalent(expectedResponse,actualResponse);
        }
        [Fact]
        public async Task LessonService_AddLesson_AddingLesson()
        {
            //Arrage
            Lesson fakeLesson = new()
            {
                Id = 1,
                LessonName = "lesson1",
                LessonDescription = "none",
                Exercises = null
            };
            LessonRequest fakeDTO = new()
            {
                Id = 1,
                LessonName="lesson1",
                LessonDescription = "none"
            };
            var Repo = A.Fake<ILessonRepository>();
            var Service = new LessonService(Repo, Mapper);

            
            //Act 
            await Service.AddLesson(fakeDTO);

            //Assert
            Assert.Equivalent(fakeLesson,Mapper.Map<Lesson>(fakeDTO));
            A.CallTo(() => Repo.Insert(A<Lesson>._)).MustHaveHappenedOnceExactly();
        }
        [Fact]
        public async Task LessonService_UpdateLesson_UpdatingLesson()
        {
            //Arrage
            Lesson fakeLesson = new()
            {
                Id = 1,
                LessonName = "lesson1",
                LessonDescription = "none",
                Exercises = null
            };
            LessonRequest fakeDTO = new()
            {
                Id = 1,
                LessonName = "lesson1",
                LessonDescription = "none"
            };
            var Repo = A.Fake<ILessonRepository>();
            var Service = new LessonService(Repo, Mapper);


            //Act 
            await Service.UpdateLesson(fakeDTO);

            //Assert
            Assert.Equivalent(fakeLesson, Mapper.Map<Lesson>(fakeDTO));
            A.CallTo(() => Repo.Update(A<Lesson>._)).MustHaveHappenedOnceExactly();
        }
        [Fact]
        public async Task LessonService_DeleteLessonById_DeletingLesson()
        {
            //Arrage
            int Id = 1;
            var Repo = A.Fake<ILessonRepository>();
            var Service = new LessonService(Repo, Mapper);

            //Act 
            await Service.DeleteLesson(Id);

            //Assert
            A.CallTo(() => Repo.Delete(Id)).MustHaveHappenedOnceExactly();
        }
    }
}
