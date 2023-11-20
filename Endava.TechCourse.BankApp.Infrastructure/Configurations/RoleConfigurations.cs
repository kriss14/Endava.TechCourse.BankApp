using Endava.TechCourse.BankApp.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Infrastructure.Configurations
{
    public class RoleConfigurations : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            var roles = Enum.GetNames(typeof(UserRole))
                    .Select(role => new IdentityRole<Guid>(role)
                    {
                        Id = Guid.NewGuid(),
                        Name = role,
                        NormalizedName = role.Normalize(),
                    })
                .ToList();
            builder.HasData(roles);
        }
    }
}