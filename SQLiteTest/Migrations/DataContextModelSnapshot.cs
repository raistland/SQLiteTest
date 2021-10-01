﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SQLiteTest;

namespace SQLiteTest.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("SQLiteTest.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsTrue")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuestionID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SelectedTime")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("QuestionID");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsTrue = false,
                            QuestionID = 1,
                            SelectedTime = 1,
                            Text = "Cevap 1"
                        },
                        new
                        {
                            Id = 2,
                            IsTrue = false,
                            QuestionID = 1,
                            SelectedTime = 0,
                            Text = "Cevap 2"
                        },
                        new
                        {
                            Id = 3,
                            IsTrue = true,
                            QuestionID = 1,
                            SelectedTime = 0,
                            Text = "Cevap 3"
                        });
                });

            modelBuilder.Entity("SQLiteTest.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Text = "Soru 1"
                        },
                        new
                        {
                            Id = 2,
                            Text = "Soru 2"
                        });
                });

            modelBuilder.Entity("SQLiteTest.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsAdmin = true,
                            Name = "Admin User",
                            Password = "admin",
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            IsAdmin = false,
                            Name = "End User 1",
                            Password = "enduser1",
                            Username = "enduser"
                        });
                });

            modelBuilder.Entity("SQLiteTest.Models.UserAnswers", b =>
                {
                    b.Property<int>("AnswerID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("AnswerID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("UserAnswers");

                    b.HasData(
                        new
                        {
                            AnswerID = 1,
                            UserID = 2,
                            Id = 0
                        });
                });

            modelBuilder.Entity("SQLiteTest.Models.Answer", b =>
                {
                    b.HasOne("SQLiteTest.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("SQLiteTest.Models.UserAnswers", b =>
                {
                    b.HasOne("SQLiteTest.Models.Answer", "Answer")
                        .WithMany("UserAnswers")
                        .HasForeignKey("AnswerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SQLiteTest.Models.User", "User")
                        .WithMany("UserAnswers")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SQLiteTest.Models.Answer", b =>
                {
                    b.Navigation("UserAnswers");
                });

            modelBuilder.Entity("SQLiteTest.Models.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("SQLiteTest.Models.User", b =>
                {
                    b.Navigation("UserAnswers");
                });
#pragma warning restore 612, 618
        }
    }
}
