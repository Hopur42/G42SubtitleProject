using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using H42Skjatextar.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace H42Skjatextar.DAL
{
    public class H42SkjatextarContext : DbContext
    {
        public H42SkjatextarContext()
            : base("ProjectDb")
        {
        }

        public DbSet<VideoTitle> videoTitles { get; set; }
        public DbSet<SubTitleFiles> subTitleFiles { get; set; }
        public DbSet<TitleRequest> titleRequests { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}