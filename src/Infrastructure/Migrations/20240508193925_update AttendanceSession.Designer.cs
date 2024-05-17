﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ExamServiceDbContext))]
    [Migration("20240508193925_update AttendanceSession")]
    partial class updateAttendanceSession
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Data.Entities.AttendanceRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AttendanceSessionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Justification")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<double>("StudentLatitude")
                        .HasColumnType("double precision");

                    b.Property<double>("StudentLongitude")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("SubmissionTimestamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AttendanceSessionId");

                    b.HasIndex("StudentId");

                    b.ToTable("AttendanceRecords");
                });

            modelBuilder.Entity("Data.Entities.AttendanceSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EndAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("InstructorId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDynamic")
                        .HasColumnType("boolean");

                    b.Property<double?>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uuid");

                    b.Property<double?>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Radius")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("StartAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("InstructorId");

                    b.HasIndex("LocationId");

                    b.ToTable("AttendanceSessions");
                });

            modelBuilder.Entity("Data.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("courses", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Instructor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("Data.Entities.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Data.Entities.Module", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int?>("AssignedCapacity")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("QuizId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("TotalGrade")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "QuizId" }, "IX_Modules_QuizId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("Data.Entities.Option", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "QuestionId" }, "IX_Options_QuestionId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("Data.Entities.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Duration")
                        .HasColumnType("numeric");

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Points")
                        .HasColumnType("numeric");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CourseId" }, "IX_Questions_CourseId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Data.Entities.Quiz", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ClosedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<double>("Duration")
                        .HasColumnType("double precision");

                    b.Property<decimal>("Grade")
                        .HasColumnType("numeric");

                    b.Property<Guid>("InstructorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CourseId" }, "IX_Quizs_CourseId");

                    b.HasIndex(new[] { "InstructorId" }, "IX_Quizs_InstructorId");

                    b.ToTable("Quizs");
                });

            modelBuilder.Entity("Data.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("AcademicId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Data.Entities.StudentQuiz", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("QuizId")
                        .HasColumnType("uuid");

                    b.Property<int>("AttemptStatus")
                        .HasColumnType("integer");

                    b.Property<bool>("Enrolled")
                        .HasColumnType("boolean");

                    b.Property<Guid>("ModuleId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SubmissionId")
                        .HasColumnType("uuid");

                    b.HasKey("StudentId", "QuizId");

                    b.HasIndex(new[] { "ModuleId" }, "IX_StudentQuizzes_ModuleId");

                    b.HasIndex(new[] { "QuizId" }, "IX_StudentQuizzes_QuizId");

                    b.HasIndex(new[] { "SubmissionId" }, "IX_StudentQuizzes_SubmissionId");

                    b.ToTable("StudentQuizzes");
                });

            modelBuilder.Entity("Data.Entities.Submission", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ModuleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("SubmitAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeOnly>("TimeTaken")
                        .HasColumnType("time without time zone");

                    b.Property<decimal>("TotalGrade")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ModuleId" }, "IX_Submissions_ModuleId");

                    b.HasIndex(new[] { "StudentId" }, "IX_Submissions_StudentId");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("InstructorCourse", b =>
                {
                    b.Property<Guid>("InstructorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uuid");

                    b.HasKey("InstructorId", "CourseId");

                    b.HasIndex(new[] { "CourseId" }, "IX_InstructorCourses_CourseId");

                    b.ToTable("InstructorCourses", (string)null);
                });

            modelBuilder.Entity("ModuleQuestion", b =>
                {
                    b.Property<Guid>("ModuleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid");

                    b.HasKey("ModuleId", "QuestionId");

                    b.HasIndex(new[] { "QuestionId" }, "IX_ModuleQuestion_QuestionId");

                    b.ToTable("ModuleQuestion", (string)null);
                });

            modelBuilder.Entity("StudentCourse", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uuid");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex(new[] { "CourseId" }, "IX_StudentCourses_CourseId");

                    b.ToTable("StudentCourses", (string)null);
                });

            modelBuilder.Entity("Data.Entities.AttendanceRecord", b =>
                {
                    b.HasOne("Data.Entities.AttendanceSession", "AttendanceSession")
                        .WithMany("AttendanceRecords")
                        .HasForeignKey("AttendanceSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Student", "Student")
                        .WithMany("AttendanceRecords")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttendanceSession");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Data.Entities.AttendanceSession", b =>
                {
                    b.HasOne("Data.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Instructor", "instructor")
                        .WithMany("AttendanceSessions")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.Navigation("Course");

                    b.Navigation("Location");

                    b.Navigation("instructor");
                });

            modelBuilder.Entity("Data.Entities.Module", b =>
                {
                    b.HasOne("Data.Entities.Quiz", "Quiz")
                        .WithMany("Modules")
                        .HasForeignKey("QuizId");

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("Data.Entities.Option", b =>
                {
                    b.HasOne("Data.Entities.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Data.Entities.Question", b =>
                {
                    b.HasOne("Data.Entities.Course", "Course")
                        .WithMany("Questions")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Data.Entities.Quiz", b =>
                {
                    b.HasOne("Data.Entities.Course", "Course")
                        .WithMany("Quizzes")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Instructor", "Instructor")
                        .WithMany("Quizzes")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Data.Entities.StudentQuiz", b =>
                {
                    b.HasOne("Data.Entities.Module", "Module")
                        .WithMany("StudentQuizzes")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Quiz", "Quiz")
                        .WithMany("StudentQuizzes")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Student", "Student")
                        .WithMany("StudentQuizzes")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Submission", "Submission")
                        .WithMany("StudentQuizzes")
                        .HasForeignKey("SubmissionId");

                    b.Navigation("Module");

                    b.Navigation("Quiz");

                    b.Navigation("Student");

                    b.Navigation("Submission");
                });

            modelBuilder.Entity("Data.Entities.Submission", b =>
                {
                    b.HasOne("Data.Entities.Module", "Module")
                        .WithMany("Submissions")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Student", "Student")
                        .WithMany("Submissions")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("InstructorCourse", b =>
                {
                    b.HasOne("Data.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Instructor", null)
                        .WithMany()
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ModuleQuestion", b =>
                {
                    b.HasOne("Data.Entities.Module", null)
                        .WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Question", null)
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentCourse", b =>
                {
                    b.HasOne("Data.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.AttendanceSession", b =>
                {
                    b.Navigation("AttendanceRecords");
                });

            modelBuilder.Entity("Data.Entities.Course", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Quizzes");
                });

            modelBuilder.Entity("Data.Entities.Instructor", b =>
                {
                    b.Navigation("AttendanceSessions");

                    b.Navigation("Quizzes");
                });

            modelBuilder.Entity("Data.Entities.Module", b =>
                {
                    b.Navigation("StudentQuizzes");

                    b.Navigation("Submissions");
                });

            modelBuilder.Entity("Data.Entities.Question", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("Data.Entities.Quiz", b =>
                {
                    b.Navigation("Modules");

                    b.Navigation("StudentQuizzes");
                });

            modelBuilder.Entity("Data.Entities.Student", b =>
                {
                    b.Navigation("AttendanceRecords");

                    b.Navigation("StudentQuizzes");

                    b.Navigation("Submissions");
                });

            modelBuilder.Entity("Data.Entities.Submission", b =>
                {
                    b.Navigation("StudentQuizzes");
                });
#pragma warning restore 612, 618
        }
    }
}
