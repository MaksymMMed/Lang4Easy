using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seeding
{
    public class UserSeeding
    {
        public List<User> UserList = new List<User>()
        {
            new User()
            {
                Id = 1,
                Login = "BenderRobot",
                Password = "4F9F4BC23FD3DEF1E733A6D2105285474675822E79940B94D5D542E740DD601C",
                Email = "Bender03@gmail.com",
                IsEmailConfirmed = true,
                Role = "user"
                
            },
            new User()
            {
                Id = 2,
                Login = "Jack",
                Password = "8467A710529EB35155AA4A2CC30DA2D9897C6143D7556B0BCA32B8033350CEA0",
                Email = "JackD@gmail.com",
                IsEmailConfirmed = true,
                Role = "admin"

            },
        };

        public void Seeding(EntityTypeBuilder<User> builder) => builder.HasData(UserList);
    }
}
