﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Okul.DAL.Concrete;

namespace Okul.DAL.Migrations
{
    [DbContext(typeof(OkulDbContext))]
    [Migration("20220505104157_mig-2")]
    partial class mig2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Okul.DAL.Entities.Departmen", b =>
                {
                    b.Property<int>("DepartmenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmenHead")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmenName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmenId");

                    b.ToTable("Departmens");
                });

            modelBuilder.Entity("Okul.DAL.Entities.Lesson", b =>
                {
                    b.Property<int>("LessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LessonCredit")
                        .HasColumnType("int");

                    b.Property<string>("LessonName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LessonSemester")
                        .HasColumnType("int");

                    b.Property<string>("LessonTeacher")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LessonId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Okul.DAL.Entities.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmenId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StudentDateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StudentDateOfRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("StudentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentSemester")
                        .HasColumnType("int");

                    b.Property<string>("StudentSurName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("DepartmenId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Okul.DAL.Entities.StudentLesson", b =>
                {
                    b.Property<int>("StudentLessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("StudentLessonId");

                    b.HasIndex("LessonId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentLessons");
                });

            modelBuilder.Entity("Okul.DAL.Entities.Student", b =>
                {
                    b.HasOne("Okul.DAL.Entities.Departmen", "Departmen")
                        .WithMany("Students")
                        .HasForeignKey("DepartmenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departmen");
                });

            modelBuilder.Entity("Okul.DAL.Entities.StudentLesson", b =>
                {
                    b.HasOne("Okul.DAL.Entities.Lesson", "Lesson")
                        .WithMany("StudentLessons")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Okul.DAL.Entities.Student", "Student")
                        .WithMany("StudentLessons")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Okul.DAL.Entities.Departmen", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Okul.DAL.Entities.Lesson", b =>
                {
                    b.Navigation("StudentLessons");
                });

            modelBuilder.Entity("Okul.DAL.Entities.Student", b =>
                {
                    b.Navigation("StudentLessons");
                });
#pragma warning restore 612, 618
        }
    }
}
