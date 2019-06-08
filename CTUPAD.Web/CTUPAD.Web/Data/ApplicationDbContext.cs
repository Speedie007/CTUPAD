using System;
using System.Collections.Generic;
using System.Text;

using CTUPAD.Web.Models.CustomModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CTUPAD.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }

        
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryCritearia> CategoryCritearias { get; set; }
        public virtual DbSet<Contestant> Contestants { get; set; }
        public virtual DbSet<ContestantCategory> ContestantCategories { get; set; }
        public virtual DbSet<ContestantJugemnent> ContestantJugemnents { get; set; }
        //public virtual DbSet<Juge> Juges { get; set; }

        public DbQuery<ContestantResult> ContestantResults { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Query<ContestantResult>().ToView("ViewJudmentResults");

            builder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
            
            builder.Entity<CategoryCritearia>(entity =>
            {
                entity.ToTable("CategoryCritearia");

                entity.HasIndex(e => e.CategoryID);

                entity.Property(e => e.CategoryCriteariaName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryID).HasColumnName("CategoryID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryCritearias)
                    .HasForeignKey(d => d.CategoryID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CategoryItems_Categories");
            });

            builder.Entity<Contestant>(entity =>
            {
                entity.ToTable("Contestant");

                entity.Property(e => e.ContestantFirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContestantLastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            builder.Entity<ContestantCategory>(entity =>
            {
                entity.HasKey(e => e.ContestCategoryID);

                entity.HasIndex(e => e.CategoryID);

                entity.HasIndex(e => e.ContestantID);

                entity.Property(e => e.ContestCategoryID).HasColumnName("ContestCategoryID");

                entity.Property(e => e.CategoryID).HasColumnName("CategoryID");

                entity.Property(e => e.ContestantID).HasColumnName("ContestantID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ContestantCategories)
                    .HasForeignKey(d => d.CategoryID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContestantCategories_Categories");

                entity.HasOne(d => d.Contestant)
                    .WithMany(p => p.ContestantCategories)
                    .HasForeignKey(d => d.ContestantID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContestantCategories_Contestant");
            });

            builder.Entity<ContestantJugemnent>(entity =>
            {


                entity.HasIndex(e => e.ContestantID);

                entity.Property(e => e.ContestantJugemnentID).HasColumnName("ContestantJugemnentID");

                entity.Property(e => e.CategoryCriteariaID).HasColumnName("CategoryCriteariaID");

                entity.Property(e => e.CategoryID).HasColumnName("CategoryID");

                entity.Property(e => e.ContestantID).HasColumnName("ContestantID");

                entity.Property(e => e.JugeID)
                    .IsRequired()
                    .HasColumnName("JugeID")
                    .HasMaxLength(450);

                entity.HasOne(d => d.CategoryCritearia)
                    .WithMany(p => p.ContestantJugemnents)
                    .HasForeignKey(d => d.CategoryCriteariaID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContestantJugemnents_CategoryCritearia");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ContestantJugemnents)
                    .HasForeignKey(d => d.CategoryID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContestantJugemnents_Categories");

                entity.HasOne(d => d.Contestant)
                    .WithMany(p => p.ContestantJugemnents)
                    .HasForeignKey(d => d.ContestantID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContestantJugemnents_Contestant");

                entity.HasOne(d => d.Juge)
                    .WithMany(p => p.ContestantJugemnents)
                    .HasForeignKey(d => d.JugeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContestantJugemnents_AspNetUsers");
            });

           
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
