﻿// <auto-generated />
using System;
using DigitalQueue.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DigitalQueue.Web.Migrations
{
    [DbContext(typeof(DigitalQueueContext))]
    [Migration("20220407175314_AddRequestEntity")]
    partial class AddRequestEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("CourseUser", b =>
                {
                    b.Property<string>("TeacherOfId")
                        .HasColumnType("TEXT")
                        .HasColumnName("course_id");

                    b.Property<string>("TeachersId")
                        .HasColumnType("TEXT")
                        .HasColumnName("teacher_id");

                    b.HasKey("TeacherOfId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("course_teacher", (string)null);
                });

            modelBuilder.Entity("DigitalQueue.Web.Data.Entities.Course", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("create_at");

                    b.Property<bool>("IsArchived")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false)
                        .HasColumnName("is_archived");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT")
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.HasIndex("Title", "Year")
                        .IsUnique();

                    b.ToTable("courses", (string)null);
                });

            modelBuilder.Entity("DigitalQueue.Web.Data.Entities.Request", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<bool>("Completed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false)
                        .HasColumnName("completed");

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("course_id");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("create_at");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("creator_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("CreatorId");

                    b.ToTable("requests", (string)null);
                });

            modelBuilder.Entity("DigitalQueue.Web.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT")
                        .HasColumnName("concurrency_stamp");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("create_at");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER")
                        .HasColumnName("email_confirmed");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("normalized_username");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT")
                        .HasColumnName("password_hash");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT")
                        .HasColumnName("security_stamp");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("normalized_name");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "22ab653d-66bc-4d26-9220-9df162a07cfc",
                            Name = "administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "9bfc1d9d-a633-42f2-9c99-44896161b6f9",
                            Name = "user",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("users_claims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("users_roles", (string)null);
                });

            modelBuilder.Entity("CourseUser", b =>
                {
                    b.HasOne("DigitalQueue.Web.Data.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("TeacherOfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalQueue.Web.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DigitalQueue.Web.Data.Entities.Request", b =>
                {
                    b.HasOne("DigitalQueue.Web.Data.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalQueue.Web.Data.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DigitalQueue.Web.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalQueue.Web.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
