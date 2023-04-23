using DAL.Entities;
using DAL.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Login)
                .HasMaxLength(50)
                .IsRequired();

            builder
               .Property(x => x.Email)
               .HasMaxLength(100)
               .IsRequired();

            builder
               .Property(x => x.Password)
               .HasMaxLength(30)
               .IsRequired();

            builder
               .Property(x => x.Role)
               .IsRequired();

            builder
               .Property(x => x.IsEmailConfirmed)
               .IsRequired();

            new UserSeeding().Seeding(builder);
        }
    }
}
