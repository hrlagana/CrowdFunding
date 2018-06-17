using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrowdFunding.Models
{
    public partial class NewCrowdFundingContext : DbContext
    {
        public NewCrowdFundingContext()
        {
        }

        public NewCrowdFundingContext(DbContextOptions<NewCrowdFundingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Backer> Backer { get; set; }
        public virtual DbSet<Benefit> Benefit { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<Progress> Progress { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectBacker> ProjectBacker { get; set; }
        public virtual DbSet<ProjectCreator> ProjectCreator { get; set; }
        public virtual DbSet<ReachGoal> ReachGoal { get; set; }
        public virtual DbSet<Video> Video { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=NewCrowdFunding;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Backer>(entity =>
            {
                entity.Property(e => e.Fund).HasColumnType("money");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Backer)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Backer_UserId");
            });

            modelBuilder.Entity<Benefit>(entity =>
            {
                entity.Property(e => e.BenefitDesciption)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.BenefitName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Benefit)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Benefit_ProjectId");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.PhotoName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PhotoPath)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Photo)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectId");
            });

            modelBuilder.Entity<Progress>(entity =>
            {
                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Progress)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Progress_ProjectId");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.AskedFund).HasColumnType("money");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.PhotoPath).HasColumnType("text");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.VideoPath).HasColumnType("text");

                entity.Property(e => e.VideoUrl).HasColumnType("text");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_CategoryId");

                entity.HasOne(d => d.ProjectCreator)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.ProjectCreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectCreatorId");
            });

            modelBuilder.Entity<ProjectBacker>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.BackerId });

                entity.HasOne(d => d.Backer)
                    .WithMany(p => p.ProjectBacker)
                    .HasForeignKey(d => d.BackerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectBacker_Backers_BackerId");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectBacker)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProjectCreator>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProjectCreator)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectCreator_UserId");
            });

            modelBuilder.Entity<ReachGoal>(entity =>
            {
                entity.Property(e => e.Flag).HasColumnName("flag");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.Property(e => e.VideoName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.VideoPath)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Video)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Video_ProjectId");
            });
        }
    }
}
