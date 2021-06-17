﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecretaryApp.EntityFramework;

namespace SecretaryApp.EntityFramework.Migrations
{
    [DbContext(typeof(SecretaryAppDbContext))]
    [Migration("20210613141013_WorklabelNameColumn")]
    partial class WorklabelNameColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SecretaryApp.Domain.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("DoctoralStudent")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("WorkingTime")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("SecretaryApp.Domain.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfStudents")
                        .HasColumnType("int");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<string>("Shortcut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudyForm")
                        .HasColumnType("int");

                    b.Property<int>("StudyType")
                        .HasColumnType("int");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("SecretaryApp.Domain.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassSize")
                        .HasColumnType("int");

                    b.Property<int>("HoursOfExcercises")
                        .HasColumnType("int");

                    b.Property<int>("HoursOfLectures")
                        .HasColumnType("int");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfCredits")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfWeeks")
                        .HasColumnType("int");

                    b.Property<string>("Shortcut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WayOfCompletion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("SecretaryApp.Domain.Models.WorkLabel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<int>("LectureType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfHours")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfStudents")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfWeeks")
                        .HasColumnType("int");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SubjectId");

                    b.ToTable("WorkLabels");
                });

            modelBuilder.Entity("SecretaryApp.Domain.Models.Group", b =>
                {
                    b.HasOne("SecretaryApp.Domain.Models.Subject", "Subject")
                        .WithMany("Groups")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SecretaryApp.Domain.Models.WorkLabel", b =>
                {
                    b.HasOne("SecretaryApp.Domain.Models.Employee", "Employee")
                        .WithMany("WorkLabels")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("SecretaryApp.Domain.Models.Subject", "Subject")
                        .WithMany("WorkLabels")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Employee");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SecretaryApp.Domain.Models.Employee", b =>
                {
                    b.Navigation("WorkLabels");
                });

            modelBuilder.Entity("SecretaryApp.Domain.Models.Subject", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("WorkLabels");
                });
#pragma warning restore 612, 618
        }
    }
}
