using Aster.Core.Domain;
using Aster.Core.Domain.Security;
using Aster.System.Localization;
using Aster.System.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Core.DataMigration
{
    class AppDbContext:DbContext
    {

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LocaleString> LocaleStrings { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB;Database=AsterDBCore; Trusted_Connection=True;");
        }

    }
}
