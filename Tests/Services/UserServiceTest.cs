using AutoMapper;
using BLL.DTO.Request;
using BLL.DTO.Response;
using BLL.MapperConfig;
using BLL.Services.Realizations;
using DAL.Entities;
using DAL.Repo.Interfaces;
using FakeItEasy;

namespace Tests.Services
{
    public class UserServiceTest
    {
        private static IMapper Mapper;

        public UserServiceTest()
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
        public async Task UserService_GetUserById_ReturnUserById()
        {
            //Arrange
            var Repo = A.Fake<IUserRepository>();
            A.CallTo(() => Repo.GetById(1)).Returns(new User()
            {
                Id = 1,
                Login = "UserLogin",
                Email = "UserEmail",
                Password = "UserPassword",
                IsEmailConfirmed = true
            });

            UserResponse expectedResponse = new UserResponse()
            {
                Id = 1,
                Login = "UserLogin",
                Email = "UserEmail",
                Password = "UserPassword",
                IsEmailConfirmed = true
            };

            var Service = new UserService(Repo, Mapper);

            //Act
            var actualResponse = await Service.GetUserById(1);

            //Assert 
            Assert.Equivalent(expectedResponse, actualResponse);
        }

        [Fact]
        public async Task UserService_AddUser_AddingUser()
        {
            //Arrage
            User fakeUser = new()
            {
                Id = 1,
                Login = "UserLogin",
                Email = "UserEmail",
                Password = "UserPassword",
                IsEmailConfirmed = true
            };
            UserRequest fakeDTO = new()
            {
                Id = 1,
                Login = "UserLogin",
                Email = "UserEmail",
                Password = "UserPassword",
                IsEmailConfirmed = true
            };
            var Repo = A.Fake<IUserRepository>();
            var Service = new UserService(Repo, Mapper);

            //Act 
            await Service.AddUser(fakeDTO);

            //Assert
            Assert.Equivalent(fakeUser, Mapper.Map<User>(fakeDTO));
            A.CallTo(() => Repo.Insert(A<User>._)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task UserService_UpdateUser_UpdatingUser()
        {
            //Arrage
            User fakeUser = new()
            {
                Id = 1,
                Login = "UserLogin",
                Email = "UserEmail",
                Password = "UserPassword",
                IsEmailConfirmed = true
            };
            UserRequest fakeDTO = new()
            {
                Id = 1,
                Login = "UserLogin",
                Email = "UserEmail",
                Password = "UserPassword",
                IsEmailConfirmed = true
            };
            var Repo = A.Fake<IUserRepository>();
            var Service = new UserService(Repo, Mapper);


            //Act 
            await Service.UpdateUser(fakeDTO);

            //Assert
            Assert.Equivalent(fakeUser, Mapper.Map<User>(fakeDTO));
            A.CallTo(() => Repo.Update(A<User>._)).MustHaveHappenedOnceExactly();
        }
        [Fact]
        public async Task UserService_DeleteUserById_DeletingUser()
        {
            //Arrage
            int Id = 1;
            var Repo = A.Fake<IUserRepository>();
            var Service = new UserService(Repo, Mapper);

            //Act 
            await Service.DeleteUser(Id);

            //Assert
            A.CallTo(() => Repo.Delete(Id)).MustHaveHappenedOnceExactly();
        }
    }
}
