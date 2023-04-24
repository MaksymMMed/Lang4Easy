﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Entities.CompleteStatus", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "ExerciseId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("CompleteStatus");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            ExerciseId = 1,
                            Status = true
                        },
                        new
                        {
                            UserId = 1,
                            ExerciseId = 2,
                            Status = true
                        },
                        new
                        {
                            UserId = 1,
                            ExerciseId = 3,
                            Status = false
                        },
                        new
                        {
                            UserId = 1,
                            ExerciseId = 4,
                            Status = true
                        },
                        new
                        {
                            UserId = 1,
                            ExerciseId = 5,
                            Status = false
                        },
                        new
                        {
                            UserId = 1,
                            ExerciseId = 6,
                            Status = false
                        },
                        new
                        {
                            UserId = 2,
                            ExerciseId = 1,
                            Status = true
                        },
                        new
                        {
                            UserId = 2,
                            ExerciseId = 2,
                            Status = true
                        },
                        new
                        {
                            UserId = 2,
                            ExerciseId = 3,
                            Status = false
                        },
                        new
                        {
                            UserId = 2,
                            ExerciseId = 4,
                            Status = true
                        },
                        new
                        {
                            UserId = 2,
                            ExerciseId = 5,
                            Status = true
                        },
                        new
                        {
                            UserId = 2,
                            ExerciseId = 6,
                            Status = false
                        });
                });

            modelBuilder.Entity("DAL.Entities.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ExerciseType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Exercise");

                    b.HasDiscriminator<string>("ExerciseType").HasValue("Exercise");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DAL.Entities.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LessonDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LessonName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Lesson");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LessonDescription = "it is first lesson",
                            LessonName = "lesson1"
                        },
                        new
                        {
                            Id = 2,
                            LessonDescription = "it is second lesson",
                            LessonName = "lesson2"
                        });
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Bender03@gmail.com",
                            IsEmailConfirmed = true,
                            Login = "BenderRobot",
                            Password = "qwerty01",
                            Role = "user"
                        },
                        new
                        {
                            Id = 2,
                            Email = "JackD@gmail.com",
                            IsEmailConfirmed = true,
                            Login = "Jack",
                            Password = "qwerty02",
                            Role = "admin"
                        });
                });

            modelBuilder.Entity("DAL.Entities.GrammarExercise", b =>
                {
                    b.HasBaseType("DAL.Entities.Exercise");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Variables")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasIndex("LessonId");

                    b.HasDiscriminator().HasValue("Grammar");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Answer = "Have",
                            LessonId = 1,
                            Name = "Choose right verb",
                            Question = "_ done your homework?",
                            Variables = "[\"Have\",\"Has\",\"Had\"]"
                        },
                        new
                        {
                            Id = 2,
                            Answer = "Went",
                            LessonId = 2,
                            Name = "Choose right verb",
                            Question = "Last month I _ to Scotland on holiday.",
                            Variables = "[\"Go\",\"Went\"]"
                        });
                });

            modelBuilder.Entity("DAL.Entities.TranslateExercise", b =>
                {
                    b.HasBaseType("DAL.Entities.Exercise");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasIndex("LessonId");

                    b.ToTable("Exercise", t =>
                        {
                            t.Property("Question")
                                .HasColumnName("TranslateExercise_Question");
                        });

                    b.HasDiscriminator().HasValue("Translate");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Answer = "You ate yesterday?",
                            LessonId = 1,
                            Name = "Translate sentence",
                            Question = "Ти їв вчора?"
                        },
                        new
                        {
                            Id = 4,
                            Answer = "Ти їв учора?",
                            LessonId = 2,
                            Name = "Translate sentence",
                            Question = "You ate yesterday?"
                        });
                });

            modelBuilder.Entity("DAL.Entities.VoiceExercise", b =>
                {
                    b.HasBaseType("DAL.Entities.Exercise");

                    b.Property<string>("TextToSay")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasIndex("LessonId");

                    b.HasDiscriminator().HasValue("Voice");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            Answer = "Ти їв учора?",
                            LessonId = 1,
                            Name = "Translate sentence",
                            TextToSay = "You ate yesterday",
                            Type = "Listen"
                        },
                        new
                        {
                            Id = 6,
                            Answer = "You ate yesterday",
                            LessonId = 2,
                            Name = "Translate sentence",
                            TextToSay = "You ate yesterday",
                            Type = "Repeat"
                        });
                });

            modelBuilder.Entity("DAL.Entities.CompleteStatus", b =>
                {
                    b.HasOne("DAL.Entities.Exercise", "Exercise")
                        .WithMany("CompleteForUser")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.User", "User")
                        .WithMany("CompletedExercise")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.GrammarExercise", b =>
                {
                    b.HasOne("DAL.Entities.Lesson", "Lesson")
                        .WithMany("GrammarExercises")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("DAL.Entities.TranslateExercise", b =>
                {
                    b.HasOne("DAL.Entities.Lesson", "Lesson")
                        .WithMany("TranslateExercises")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("DAL.Entities.VoiceExercise", b =>
                {
                    b.HasOne("DAL.Entities.Lesson", "Lesson")
                        .WithMany("VoiceExercises")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("DAL.Entities.Exercise", b =>
                {
                    b.Navigation("CompleteForUser");
                });

            modelBuilder.Entity("DAL.Entities.Lesson", b =>
                {
                    b.Navigation("GrammarExercises");

                    b.Navigation("TranslateExercises");

                    b.Navigation("VoiceExercises");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Navigation("CompletedExercise");
                });
#pragma warning restore 612, 618
        }
    }
}
