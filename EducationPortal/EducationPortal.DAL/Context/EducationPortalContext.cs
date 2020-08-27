using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.Core.Entities;
using EducationPortal.Core;

namespace EducationPortal.DAL.Context
{
    public class EducationPortalContext : DbContext, IEducationPortalContext
    {
        static EducationPortalContext()
        {
            Database.SetInitializer(new DBInitializer());
        }

        public EducationPortalContext() : base("DBConnection")
        {
        }

        //public EducationPortalContext(string connection) : base(connection)
        //{
        //}

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<BaseMaterial> BaseMaterials { get; set; }

        public DbSet<ArticleMaterial> ArticleMaterials { get; set; }

        public DbSet<VideoMaterial> VideoMaterials { get; set; }

        public DbSet<BookMaterial> BookMaterials { get; set; }

        public DbSet<CourseBaseMaterials> CourseBaseMaterials { get; set; }

        public DbSet<CourseSkills> CourseSkills { get; set; }

        public DbSet<UserCourses> UserCourses { get; set; }

        public DbSet<UserBaseMaterials> UserMaterials { get; set; }

        public DbSet<UserSkills> UserSkills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCourses>().HasKey(k =>
                new
                {
                    k.UserId,
                    k.CourseId
                });

            modelBuilder.Entity<UserSkills>().HasKey(k =>
                new
                {
                    k.UserId,
                    k.SkillId
                });

            modelBuilder.Entity<UserBaseMaterials>().HasKey(k =>
                new
                {
                    k.UserId,
                    k.BaseMaterialId
                });

            modelBuilder.Entity<CourseBaseMaterials>().HasKey(k =>
                new
                {
                    k.CourseId,
                    k.BaseMaterialId
                });

            modelBuilder.Entity<CourseSkills>().HasKey(k =>
                new
                {
                    k.CourseId,
                    k.SkillId
                });

            //modelBuilder.Entity<User>()
            //    .HasRequired(t => t.Role)
            //    .WithMany(t => t.Users)
            //    .HasForeignKey(t => t.RoleId);

            modelBuilder.Entity<UserCourses>()
                .HasRequired(t => t.User)
                .WithMany(t => t.UserCourses)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<UserCourses>()
                .HasRequired(t => t.Course)
                .WithMany(t => t.UserCourses)
                .HasForeignKey(t => t.CourseId);

            modelBuilder.Entity<UserSkills>()
                .HasRequired(t => t.User)
                .WithMany(t => t.UserSkills)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<UserSkills>()
                .HasRequired(t => t.Skill)
                .WithMany(t => t.UserSkills)
                .HasForeignKey(t => t.SkillId);

            modelBuilder.Entity<UserBaseMaterials>()
                .HasRequired(t => t.User)
                .WithMany(t => t.UserMaterials)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<UserBaseMaterials>()
                .HasRequired(t => t.BaseMaterial)
                .WithMany(t => t.UserBaseMaterials)
                .HasForeignKey(t => t.BaseMaterialId);

            modelBuilder.Entity<CourseSkills>()
                .HasRequired(t => t.Course)
                .WithMany(t => t.CourseSkills)
                .HasForeignKey(t => t.CourseId);

            modelBuilder.Entity<CourseSkills>()
                .HasRequired(t => t.Skill)
                .WithMany(t => t.CourseSkills)
                .HasForeignKey(t => t.SkillId);

            modelBuilder.Entity<CourseBaseMaterials>()
                .HasRequired(t => t.Course)
                .WithMany(t => t.CourseBaseMaterials)
                .HasForeignKey(t => t.CourseId);

            modelBuilder.Entity<CourseBaseMaterials>()
                .HasRequired(t => t.BaseMaterial)
                .WithMany(t => t.CourseBaseMaterials)
                .HasForeignKey(t => t.BaseMaterialId);

            //modelBuilder.Entity<BaseMaterial>()
            //    .HasRequired(c => c.ArticleMaterial);

            //modelBuilder.Entity<BaseMaterial>()
            //    .HasRequired(c => c.ArticleMaterial);

            //modelBuilder.Entity<BaseMaterial>()
            //    .HasRequired(c => c.ArticleMaterial);


            //modelBuilder.Entity<VideoMaterial>()
            //    .HasRequired(c => c.BaseMaterial)
            //    .WithRequiredPrincipal(c => c.VideoMaterial);

            //modelBuilder.Entity<ArticleMaterial>()
            //    .HasRequired(c => c.BaseMaterial)
            //    .WithRequiredPrincipal(c => c.ArticleMaterial);

            //modelBuilder.Entity<BookMaterial>()
            //    .HasRequired(c => c.BaseMaterial)
            //    .WithRequiredPrincipal(c => c.BookMaterial);

            //modelBuilder.Entity<BaseMaterial>()
            //     .Map(m =>
            //     {
            //         m.MapInheritedProperties();
            //         m.ToTable("BaseMaterials");
            //     });

            //modelBuilder.Entity<BookMaterial>().Map(m =>
            //    {
            //        m.MapInheritedProperties();
            //        m.ToTable("BookMaterials");
            //    });

            //modelBuilder.Entity<ArticleMaterial>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("ArticleMaterials");
            //});

            //modelBuilder.Entity<VideoMaterial>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("VideoMaterials");
            //});
        }
    }
}
