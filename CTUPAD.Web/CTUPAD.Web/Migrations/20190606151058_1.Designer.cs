﻿// <auto-generated />
using System;
using CTUPAD.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CTUPAD.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190606151058_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CTUPAD.Web.Models.CustomModel.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CTUPAD.Web.Models.CustomModel.CategoryCritearia", b =>
                {
                    b.Property<int>("CategoryCriteariaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryCriteariaName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int>("CategoryID")
                        .HasColumnName("CategoryID");

                    b.HasKey("CategoryCriteariaID");

                    b.HasIndex("CategoryID");

                    b.ToTable("CategoryCritearia");
                });

            modelBuilder.Entity("CTUPAD.Web.Models.CustomModel.Contestant", b =>
                {
                    b.Property<int>("ContestantID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContestantFirstName")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("ContestantLastName")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("ContestantID");

                    b.ToTable("Contestant");
                });

            modelBuilder.Entity("CTUPAD.Web.Models.CustomModel.ContestantCategory", b =>
                {
                    b.Property<int>("ContestCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ContestCategoryID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnName("CategoryID");

                    b.Property<int>("ContestantID")
                        .HasColumnName("ContestantID");

                    b.HasKey("ContestCategoryID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ContestantID");

                    b.ToTable("ContestantCategories");
                });

            modelBuilder.Entity("CTUPAD.Web.Models.CustomModel.ContestantJugemnent", b =>
                {
                    b.Property<int>("ContestantJugemnentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ContestantJugemnentID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryCriteariaID")
                        .HasColumnName("CategoryCriteariaID");

                    b.Property<int>("CategoryID")
                        .HasColumnName("CategoryID");

                    b.Property<int>("ContestantID")
                        .HasColumnName("ContestantID");

                    b.Property<string>("JugeID")
                        .IsRequired()
                        .HasColumnName("JugeID")
                        .HasMaxLength(450);

                    b.Property<int>("Rating");

                    b.HasKey("ContestantJugemnentID");

                    b.HasIndex("CategoryCriteariaID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ContestantID");

                    b.HasIndex("JugeID");

                    b.ToTable("ContestantJugemnents");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CTUPAD.Web.Models.CustomModel.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("CTUPAD.Web.Models.CustomModel.CategoryCritearia", b =>
                {
                    b.HasOne("CTUPAD.Web.Models.CustomModel.Category", "Category")
                        .WithMany("CategoryCritearias")
                        .HasForeignKey("CategoryID")
                        .HasConstraintName("FK_CategoryItems_Categories")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CTUPAD.Web.Models.CustomModel.ContestantCategory", b =>
                {
                    b.HasOne("CTUPAD.Web.Models.CustomModel.Category", "Category")
                        .WithMany("ContestantCategories")
                        .HasForeignKey("CategoryID")
                        .HasConstraintName("FK_ContestantCategories_Categories");

                    b.HasOne("CTUPAD.Web.Models.CustomModel.Contestant", "Contestant")
                        .WithMany("ContestantCategories")
                        .HasForeignKey("ContestantID")
                        .HasConstraintName("FK_ContestantCategories_Contestant");
                });

            modelBuilder.Entity("CTUPAD.Web.Models.CustomModel.ContestantJugemnent", b =>
                {
                    b.HasOne("CTUPAD.Web.Models.CustomModel.CategoryCritearia", "CategoryCritearia")
                        .WithMany("ContestantJugemnents")
                        .HasForeignKey("CategoryCriteariaID")
                        .HasConstraintName("FK_ContestantJugemnents_CategoryCritearia");

                    b.HasOne("CTUPAD.Web.Models.CustomModel.Category", "Category")
                        .WithMany("ContestantJugemnents")
                        .HasForeignKey("CategoryID")
                        .HasConstraintName("FK_ContestantJugemnents_Categories");

                    b.HasOne("CTUPAD.Web.Models.CustomModel.Contestant", "Contestant")
                        .WithMany("ContestantJugemnents")
                        .HasForeignKey("ContestantID")
                        .HasConstraintName("FK_ContestantJugemnents_Contestant");

                    b.HasOne("CTUPAD.Web.Models.CustomModel.ApplicationUser", "Juge")
                        .WithMany("ContestantJugemnents")
                        .HasForeignKey("JugeID")
                        .HasConstraintName("FK_ContestantJugemnents_AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
