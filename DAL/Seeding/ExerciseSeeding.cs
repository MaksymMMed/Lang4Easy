using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seeding
{
    public class ExerciseSeeding
    {
        public List<User> UserList = new List<User>()
        {
            new User()
            {
                Id = 1,
                Login = "BenderRobot",
                Password = "qwerty01",
                Email = "Bender03@gmail.com"
            },
            new User()
            {
                Id = 2,
                Login = "Jack",
                Password = "qwerty02",
                Email = "JackD@gmail.com"
            },
        };

        public void Seeding(EntityTypeBuilder<Exercise> builder) => builder.HasData(UserList);
    }
}
