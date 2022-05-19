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
    [Migration("20220519121913_FixSessionAndUserEntities")]
    partial class FixSessionAndUserEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("CourseUser", b =>
                {
                    b.Property<string>("CoursesId")
                        .HasColumnType("TEXT")
                        .HasColumnName("course_id");

                    b.Property<string>("TeachersId")
                        .HasColumnType("TEXT")
                        .HasColumnName("teacher_id");

                    b.HasKey("CoursesId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("course_teacher", (string)null);
                });

            modelBuilder.Entity("DigitalQueue.Web.Areas.Courses.Dtos.CourseQueueItem", b =>
                {
                    b.Property<string>("Course")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Student")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable((string)null);
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
                        .IsRequired()
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

            modelBuilder.Entity("DigitalQueue.Web.Data.Entities.QueueItem", b =>
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

                    b.ToTable("queue_items", (string)null);
                });

            modelBuilder.Entity("DigitalQueue.Web.Data.Entities.Session", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("access_token");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("DeviceToken")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("device_token");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("refresh_token");

                    b.Property<string>("SecurityStamp")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("security_stamp");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RefreshToken");

                    b.HasIndex("SecurityStamp");

                    b.HasIndex("UserId");

                    b.ToTable("sessions", (string)null);
                });

            modelBuilder.Entity("DigitalQueue.Web.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("create_at");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
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
                            Id = "560cf956-b220-4014-8213-3b4b136baaaf",
                            Name = "administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "0b171b48-535a-4f21-b566-b53b5b08b0c9",
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
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalQueue.Web.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DigitalQueue.Web.Data.Entities.QueueItem", b =>
                {
                    b.HasOne("DigitalQueue.Web.Data.Entities.Course", "Course")
                        .WithMany("QueueItems")
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

            modelBuilder.Entity("DigitalQueue.Web.Data.Entities.Session", b =>
                {
                    b.HasOne("DigitalQueue.Web.Data.Entities.User", "User")
                        .WithMany("Sessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
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

            modelBuilder.Entity("DigitalQueue.Web.Data.Entities.Course", b =>
                {
                    b.Navigation("QueueItems");
                });

            modelBuilder.Entity("DigitalQueue.Web.Data.Entities.User", b =>
                {
                    b.Navigation("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}
