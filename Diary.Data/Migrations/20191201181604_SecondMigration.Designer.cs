﻿// <auto-generated />
using System;
using Diary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Diary.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191201181604_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Diary.Domain.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("CreatorId");

                    b.Property<DateTime>("Date");

                    b.Property<TimeSpan>("Duration");

                    b.Property<int>("Status");

                    b.Property<Guid>("TargetId");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("TargetId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Diary.Domain.Assignment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClassId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<DateTime>("DueAt");

                    b.Property<float>("MaxGrade");

                    b.Property<string>("NotificationJobId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("Diary.Domain.Attendance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Absent");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("Date");

                    b.Property<Guid>("StudentClassId");

                    b.HasKey("Id");

                    b.HasIndex("StudentClassId");

                    b.HasIndex("Date", "StudentClassId")
                        .IsUnique();

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("Diary.Domain.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("MaxCredits");

                    b.Property<Guid>("SchoolYearId");

                    b.Property<Guid>("SubjectId");

                    b.Property<Guid>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("SchoolYearId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Diary.Domain.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("CreatorId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<TimeSpan>("Duration");

                    b.Property<string>("NotificationEventId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Diary.Domain.Grade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AssignmentId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<float>("FirstGrade");

                    b.Property<float?>("Recovery");

                    b.Property<Guid>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("AssignmentId", "StudentId")
                        .IsUnique();

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("Diary.Domain.SchoolYear", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("Year")
                        .IsUnique();

                    b.ToTable("SchoolYears");
                });

            modelBuilder.Entity("Diary.Domain.StudentClass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClassId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<float>("FinalGrade");

                    b.Property<int>("Status");

                    b.Property<Guid>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId", "ClassId")
                        .IsUnique();

                    b.ToTable("StudentClasses");
                });

            modelBuilder.Entity("Diary.Domain.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Diary.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int>("Type");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Diary.Domain.UserEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("EventId");

                    b.Property<int>("Status");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId", "EventId")
                        .IsUnique();

                    b.ToTable("UserEvents");
                });

            modelBuilder.Entity("Diary.Domain.UserGuardian", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("GuardianId");

                    b.Property<Guid>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("GuardianId");

                    b.HasIndex("StudentId", "GuardianId")
                        .IsUnique();

                    b.ToTable("UserGuardians");
                });

            modelBuilder.Entity("Diary.Domain.Appointment", b =>
                {
                    b.HasOne("Diary.Domain.User", "Creator")
                        .WithMany("AppointmentsCreated")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Diary.Domain.User", "Target")
                        .WithMany("Appointments")
                        .HasForeignKey("TargetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Diary.Domain.Assignment", b =>
                {
                    b.HasOne("Diary.Domain.Class", "Class")
                        .WithMany("Assignments")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Diary.Domain.Attendance", b =>
                {
                    b.HasOne("Diary.Domain.StudentClass", "StudentClass")
                        .WithMany("Attendance")
                        .HasForeignKey("StudentClassId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Diary.Domain.Class", b =>
                {
                    b.HasOne("Diary.Domain.SchoolYear", "SchoolYear")
                        .WithMany("Classes")
                        .HasForeignKey("SchoolYearId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Diary.Domain.Subject", "Subject")
                        .WithMany("Classes")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Diary.Domain.User", "Teacher")
                        .WithMany("TaughtClasses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Diary.Domain.Event", b =>
                {
                    b.HasOne("Diary.Domain.User", "Creator")
                        .WithMany("EventsCreated")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Diary.Domain.Grade", b =>
                {
                    b.HasOne("Diary.Domain.Assignment", "Assignment")
                        .WithMany()
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Diary.Domain.User", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Diary.Domain.StudentClass", b =>
                {
                    b.HasOne("Diary.Domain.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Diary.Domain.User", "Student")
                        .WithMany("Classes")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Diary.Domain.UserEvent", b =>
                {
                    b.HasOne("Diary.Domain.Event", "Event")
                        .WithMany("Attendees")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Diary.Domain.User", "User")
                        .WithMany("Events")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Diary.Domain.UserGuardian", b =>
                {
                    b.HasOne("Diary.Domain.User", "Guardian")
                        .WithMany("Dependents")
                        .HasForeignKey("GuardianId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Diary.Domain.User", "Student")
                        .WithMany("Guardians")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
