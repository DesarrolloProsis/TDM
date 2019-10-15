using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace TDM.Models
{
    public class DataContext
    {

        public class AppDbContext : DbContext
        {
            public AppDbContext() : base("name=DefaultConnection")
            {
                Database.SetInitializer<AppDbContext>(new CreateDatabaseIfNotExists<AppDbContext>());
            }

            public DbSet<Articles> Articles { get; set; }
            public DbSet<Sections> Sections { get; set; }
            public DbSet<Tags> Tags { get; set; }
            public DbSet<ArticuloTag> ArticuloTags{ get; set; }
            public DbSet<Users> Users { get; set; }


            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Configurations.Add(new ArticlesMap());
                modelBuilder.Configurations.Add(new SectionsMap());
                modelBuilder.Configurations.Add(new TagsMap());
                modelBuilder.Configurations.Add(new ArticuloTagMap());
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

            public class TagsMap : EntityTypeConfiguration<Tags>
            {
                public TagsMap()
                {
                    ToTable("Tags");
                    HasKey(x => x.IdTag);
                    Property(x => x.NombreTag).HasMaxLength(30);

                }

            }


            public class ArticuloTagMap : EntityTypeConfiguration<ArticuloTag>
            {
                public ArticuloTagMap()
                {
                    ToTable("ArticuloTag");
                    HasKey(x => new { x.IdTag, x.IdArticle });

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
}