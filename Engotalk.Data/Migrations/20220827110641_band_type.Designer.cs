﻿// <auto-generated />
using Engotalk.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Engotalk.Data.Migrations
{
    [DbContext(typeof(EngotalkDbContext))]
    [Migration("20220827110641_band_type")]
    partial class band_type
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Engotalk.Model.CountryM", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"), 1L, 1);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Engotalk.Model.CourseM", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"), 1L, 1);

                    b.Property<string>("Band")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseDuration")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("IELTSRequirment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ListeningBand")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ReadingBand")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("SpeakingBand")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("WritingBand")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CourseId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Engotalk.Model.DepartmentM", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("DepartmentId");

                    b.HasIndex("UniversityId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Engotalk.Model.UniversityM", b =>
                {
                    b.Property<int>("UniversityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UniversityId"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<string>("University")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniversityType")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("UniversityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("Engotalk.Model.CourseM", b =>
                {
                    b.HasOne("Engotalk.Model.DepartmentM", "department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });

            modelBuilder.Entity("Engotalk.Model.DepartmentM", b =>
                {
                    b.HasOne("Engotalk.Model.UniversityM", "university")
                        .WithMany()
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("university");
                });

            modelBuilder.Entity("Engotalk.Model.UniversityM", b =>
                {
                    b.HasOne("Engotalk.Model.CountryM", "country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("country");
                });
#pragma warning restore 612, 618
        }
    }
}
