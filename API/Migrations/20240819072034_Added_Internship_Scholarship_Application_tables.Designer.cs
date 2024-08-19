﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240819072034_Added_Internship_Scholarship_Application_tables")]
    partial class Added_Internship_Scholarship_Application_tables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Administrator", b =>
                {
                    b.Property<Guid>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AdminID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("Domain.Entities.ApplicationForm", b =>
                {
                    b.Property<Guid>("ApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InternshipID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReviewedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ReviewedByAdminID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ScholarshipID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("StudentID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ApplicationID");

                    b.HasIndex("InternshipID");

                    b.HasIndex("ReviewedByAdminID");

                    b.HasIndex("ScholarshipID");

                    b.HasIndex("StudentID");

                    b.ToTable("ApplicationForms");
                });

            modelBuilder.Entity("Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.Course", b =>
                {
                    b.Property<Guid>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InstructorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseID");

                    b.HasIndex("InstructorID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Domain.Entities.Feedback", b =>
                {
                    b.Property<Guid>("FeedbackID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CourseID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid>("StudentID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SubmittedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("FeedbackID");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentID");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Domain.Entities.Instructor", b =>
                {
                    b.Property<Guid>("InstructorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Faculty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("InstructorID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("Domain.Entities.Internship", b =>
                {
                    b.Property<Guid>("InternshipID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EligibilityCriteria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PostedByAdminID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InternshipID");

                    b.HasIndex("PostedByAdminID");

                    b.ToTable("Internships");
                });

            modelBuilder.Entity("Domain.Entities.Notification", b =>
                {
                    b.Property<Guid>("NotificationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("NotificationID");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Domain.Entities.PostContent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Domain.Entities.Scholarship", b =>
                {
                    b.Property<Guid>("ScholarshipID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ApplicationDeadline")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset?>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EligibilityCriteria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PostedByAdminID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ScholarshipID");

                    b.HasIndex("PostedByAdminID");

                    b.ToTable("Scholarships");
                });

            modelBuilder.Entity("Domain.Entities.Student", b =>
                {
                    b.Property<Guid>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("CGPA")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset?>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnrollmentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("YearOfStudy")
                        .HasColumnType("int");

                    b.HasKey("StudentID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Domain.Entities.Administrator", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", "ApplicationUser")
                        .WithOne("Administrator")
                        .HasForeignKey("Domain.Entities.Administrator", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Domain.Entities.ApplicationForm", b =>
                {
                    b.HasOne("Domain.Entities.Internship", "Internship")
                        .WithMany("ApplicationForms")
                        .HasForeignKey("InternshipID");

                    b.HasOne("Domain.Entities.Administrator", "ReviewedByAdmin")
                        .WithMany()
                        .HasForeignKey("ReviewedByAdminID");

                    b.HasOne("Domain.Entities.Scholarship", "Scholarship")
                        .WithMany("ApplicationForms")
                        .HasForeignKey("ScholarshipID");

                    b.HasOne("Domain.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Internship");

                    b.Navigation("ReviewedByAdmin");

                    b.Navigation("Scholarship");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Domain.Entities.Course", b =>
                {
                    b.HasOne("Domain.Entities.Instructor", "Instructor")
                        .WithMany()
                        .HasForeignKey("InstructorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Domain.Entities.Feedback", b =>
                {
                    b.HasOne("Domain.Entities.Course", "Course")
                        .WithMany("Feedbacks")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Domain.Entities.Instructor", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", "ApplicationUser")
                        .WithOne("Instructor")
                        .HasForeignKey("Domain.Entities.Instructor", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Domain.Entities.Internship", b =>
                {
                    b.HasOne("Domain.Entities.Administrator", "PostedByAdmin")
                        .WithMany()
                        .HasForeignKey("PostedByAdminID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PostedByAdmin");
                });

            modelBuilder.Entity("Domain.Entities.Notification", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Domain.Entities.Scholarship", b =>
                {
                    b.HasOne("Domain.Entities.Administrator", "PostedByAdmin")
                        .WithMany()
                        .HasForeignKey("PostedByAdminID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PostedByAdmin");
                });

            modelBuilder.Entity("Domain.Entities.Student", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", "ApplicationUser")
                        .WithOne("Student")
                        .HasForeignKey("Domain.Entities.Student", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Domain.Entities.ApplicationUser", b =>
                {
                    b.Navigation("Administrator")
                        .IsRequired();

                    b.Navigation("Instructor")
                        .IsRequired();

                    b.Navigation("Student")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Course", b =>
                {
                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("Domain.Entities.Internship", b =>
                {
                    b.Navigation("ApplicationForms");
                });

            modelBuilder.Entity("Domain.Entities.Scholarship", b =>
                {
                    b.Navigation("ApplicationForms");
                });
#pragma warning restore 612, 618
        }
    }
}
