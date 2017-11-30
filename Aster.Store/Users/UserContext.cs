using Aster.Users.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Store.Users
{
    public class UserContext: DbContext 
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<User>(ConfigureUser);            
        }
        
        private void ConfigureUser(EntityTypeBuilder<User> builder) {
            builder.ToTable("Users");
            builder.Property(c => c.Id)
                .IsRequired();

            builder.Property(c => c.UserName)
                .IsRequired();
            
            builder.Property(c => c.Email)
                .IsRequired();
            
            builder.Property(c => c.PasswordHash)
                .IsRequired();
        }

    }


}
