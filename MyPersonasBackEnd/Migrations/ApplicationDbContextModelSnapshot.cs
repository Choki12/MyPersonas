﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyPersonasBackEnd.Data;

namespace MyPersonasBackEnd.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18");

            modelBuilder.Entity("MyPersonasBackEnd.Data.Questions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(500);

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(500);

                    b.Property<string>("State")
                        .HasColumnType("TEXT")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("MyPersonasBackEnd.Data.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateTaken")
                        .HasColumnType("TEXT");

                    b.Property<string>("TestState")
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("MyPersonasBackEnd.Data.TestQuestion", b =>
                {
                    b.Property<int>("TestId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(500);

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(500);

                    b.Property<int?>("QuestionsId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("State")
                        .HasColumnType("TEXT")
                        .HasMaxLength(500);

                    b.HasKey("TestId", "QuestionId");

                    b.HasIndex("QuestionsId");

                    b.ToTable("TestQuestion");
                });

            modelBuilder.Entity("MyPersonasBackEnd.Data.Testee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DOB")
                        .HasColumnType("TEXT")
                        .HasMaxLength(400);

                    b.Property<string>("Email")
                        .HasColumnType("TEXT")
                        .HasMaxLength(400);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(400);

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Testees");
                });

            modelBuilder.Entity("MyPersonasBackEnd.Data.TesteeTest", b =>
                {
                    b.Property<int>("TesteeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TestId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attempts")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DOB")
                        .HasColumnType("TEXT")
                        .HasMaxLength(400);

                    b.Property<string>("Email")
                        .HasColumnType("TEXT")
                        .HasMaxLength(400);

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastDateTaken")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(400);

                    b.HasKey("TesteeId", "TestId");

                    b.HasIndex("TestId");

                    b.ToTable("TesteeTest");
                });

            modelBuilder.Entity("MyPersonasBackEnd.Data.TestQuestion", b =>
                {
                    b.HasOne("MyPersonasBackEnd.Data.Questions", "Questions")
                        .WithMany("TestQuestion")
                        .HasForeignKey("QuestionsId");

                    b.HasOne("MyPersonasBackEnd.Data.Test", "Test")
                        .WithMany("TestQuestion")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyPersonasBackEnd.Data.TesteeTest", b =>
                {
                    b.HasOne("MyPersonasBackEnd.Data.Test", "Test")
                        .WithMany("TesteeTest")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyPersonasBackEnd.Data.Testee", "Testee")
                        .WithMany("TesteeTest")
                        .HasForeignKey("TesteeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
