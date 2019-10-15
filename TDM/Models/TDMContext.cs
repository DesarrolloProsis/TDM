using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using static TDM.Models.DataContext;

namespace TDM.Models
{
    public class TDMContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TDMContext() : base("name=DefaultConnection")
        {


            Database.SetInitializer<AppDbContext>(new CreateDatabaseIfNotExists<AppDbContext>());
        }

        public System.Data.Entity.DbSet<TDM.Models.Articles> Articles { get; set; }

        public System.Data.Entity.DbSet<TDM.Models.Sections> Sections { get; set; }

        public System.Data.Entity.DbSet<TDM.Models.Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ArticlesMap());
            modelBuilder.Configurations.Add(new SectionsMap());
            modelBuilder.Configurations.Add(new UsersMap());

            base.OnModelCreating(modelBuilder);
        }

        public class ArticlesMap : EntityTypeConfiguration<Articles>
        {
            public ArticlesMap()
            {
                ToTable("Articles");
                HasKey(x => x.IdArticle);
                Property(x => x.URL).HasMaxLength(100);
                Property(x => x.Nombre).HasMaxLength(100);
                HasRequired<Sections>(x => x.Sections).WithMany(x => x.Articles).HasForeignKey(x => x.IdSection);
                HasRequired<Users>(x => x.Users).WithMany(x => x.Articles).HasForeignKey(x => x.IdUser);

            }

        }

        public class SectionsMap : EntityTypeConfiguration<Sections>
        {
            public SectionsMap()
            {
                ToTable("Sections");
                HasKey(x => x.IdSection);
                Property(x => x.Nombre).HasMaxLength(50);

            }

        }

        public class UsersMap : EntityTypeConfiguration<Users>
        {
            public UsersMap()
            {
                ToTable("Users");
                HasKey(x => x.IdUser);
                Property(x => x.UserName).HasMaxLength(70);
                Property(x => x.Nombre).HasMaxLength(50);
                Property(x => x.Apellido).HasMaxLength(50);
                Property(x => x.ImagenURL).HasMaxLength(100);
            }

        }
    }
}
