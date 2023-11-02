﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillAssessment.Data;

#nullable disable

namespace SkillAssessment.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SkillAssessment.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("answer");
                });

            modelBuilder.Entity("SkillAssessment.Models.Assessment", b =>
                {
                    b.Property<int>("Assessment_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Assessment_ID"));

                    b.Property<string>("Assesment_Departmenr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Assessment_DateOfCompletion")
                        .HasColumnType("datetime2");

                    b.Property<int>("Assessment_NoOfQuestions")
                        .HasColumnType("int");

                    b.Property<int>("Assessment_Points")
                        .HasColumnType("int");

                    b.Property<DateTime>("Assessment_Requested_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Assessment_SelectedLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Assessment_SelectedTopic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Assessment_TimeDuration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Assessment_type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LevelsLevelId")
                        .HasColumnType("int");

                    b.Property<int?>("TopicsTopic_Id")
                        .HasColumnType("int");

                    b.Property<int?>("UsersUser_ID")
                        .HasColumnType("int");

                    b.HasKey("Assessment_ID");

                    b.HasIndex("LevelsLevelId");

                    b.HasIndex("TopicsTopic_Id");

                    b.HasIndex("UsersUser_ID");

                    b.ToTable("Assessments");
                });

            modelBuilder.Entity("SkillAssessment.Models.Level", b =>
                {
                    b.Property<int>("LevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LevelId"));

                    b.Property<string>("LevelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TopicsTopic_Id")
                        .HasColumnType("int");

                    b.HasKey("LevelId");

                    b.HasIndex("TopicsTopic_Id");

                    b.ToTable("levels");
                });

            modelBuilder.Entity("SkillAssessment.Models.QuestionAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AnswerId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int?>("QuestionsQnId")
                        .HasColumnType("int");

                    b.Property<int>("SelectedOption")
                        .HasColumnType("int");

                    b.Property<int>("topic_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("QuestionsQnId");

                    b.ToTable("questionAnswers");
                });

            modelBuilder.Entity("SkillAssessment.Models.Questions", b =>
                {
                    b.Property<int>("QnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QnId"));

                    b.Property<int>("Answer")
                        .HasColumnType("int");

                    b.Property<string>("Explanation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LevelsLevelId")
                        .HasColumnType("int");

                    b.Property<string>("Option1")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Option2")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Option3")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Option4")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("QnInWords")
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("topicsTopic_Id")
                        .HasColumnType("int");

                    b.HasKey("QnId");

                    b.HasIndex("LevelsLevelId");

                    b.HasIndex("topicsTopic_Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("SkillAssessment.Models.Result", b =>
                {
                    b.Property<int>("result_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("result_id"));

                    b.Property<int>("AnsweredQuestions")
                        .HasColumnType("int");

                    b.Property<int?>("Assessment_ID")
                        .HasColumnType("int");

                    b.Property<string>("TimeLeft")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TopicsTopic_Id")
                        .HasColumnType("int");

                    b.Property<int>("TotalQuestions")
                        .HasColumnType("int");

                    b.Property<int>("UnansweredQuestions")
                        .HasColumnType("int");

                    b.Property<int>("WrongAnsweredQuestions")
                        .HasColumnType("int");

                    b.Property<string>("date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("endtime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passorfail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("points")
                        .HasColumnType("int");

                    b.Property<string>("starttime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("usersUser_ID")
                        .HasColumnType("int");

                    b.HasKey("result_id");

                    b.HasIndex("Assessment_ID");

                    b.HasIndex("TopicsTopic_Id");

                    b.HasIndex("usersUser_ID");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("SkillAssessment.Models.Topics", b =>
                {
                    b.Property<int>("Topic_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Topic_Id"));

                    b.Property<string>("Topic_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Topic_Id");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_ID"));

                    b.Property<string>("User_Address")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("User_DOB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Departmenr")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("User_Designation")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("User_EduLevel")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("User_Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("User_FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("User_Gender")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("User_Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("User_Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("User_PhoneNo")
                        .HasColumnType("bigint");

                    b.HasKey("User_ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SkillAssessment.Models.Assessment", b =>
                {
                    b.HasOne("SkillAssessment.Models.Level", "Levels")
                        .WithMany("Assessment")
                        .HasForeignKey("LevelsLevelId");

                    b.HasOne("SkillAssessment.Models.Topics", "Topics")
                        .WithMany("Assessment")
                        .HasForeignKey("TopicsTopic_Id");

                    b.HasOne("User", "Users")
                        .WithMany("assessments")
                        .HasForeignKey("UsersUser_ID");

                    b.Navigation("Levels");

                    b.Navigation("Topics");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("SkillAssessment.Models.Level", b =>
                {
                    b.HasOne("SkillAssessment.Models.Topics", null)
                        .WithMany("Levels")
                        .HasForeignKey("TopicsTopic_Id");
                });

            modelBuilder.Entity("SkillAssessment.Models.QuestionAnswer", b =>
                {
                    b.HasOne("SkillAssessment.Models.Answer", null)
                        .WithMany("QuestionAnswers")
                        .HasForeignKey("AnswerId");

                    b.HasOne("SkillAssessment.Models.Questions", "Questions")
                        .WithMany()
                        .HasForeignKey("QuestionsQnId");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("SkillAssessment.Models.Questions", b =>
                {
                    b.HasOne("SkillAssessment.Models.Level", "Levels")
                        .WithMany("Questions")
                        .HasForeignKey("LevelsLevelId");

                    b.HasOne("SkillAssessment.Models.Topics", "topics")
                        .WithMany("Questions")
                        .HasForeignKey("topicsTopic_Id");

                    b.Navigation("Levels");

                    b.Navigation("topics");
                });

            modelBuilder.Entity("SkillAssessment.Models.Result", b =>
                {
                    b.HasOne("SkillAssessment.Models.Assessment", "assessment")
                        .WithMany()
                        .HasForeignKey("Assessment_ID");

                    b.HasOne("SkillAssessment.Models.Topics", "Topics")
                        .WithMany("Results")
                        .HasForeignKey("TopicsTopic_Id");

                    b.HasOne("User", "users")
                        .WithMany("results")
                        .HasForeignKey("usersUser_ID");

                    b.Navigation("Topics");

                    b.Navigation("assessment");

                    b.Navigation("users");
                });

            modelBuilder.Entity("SkillAssessment.Models.Answer", b =>
                {
                    b.Navigation("QuestionAnswers");
                });

            modelBuilder.Entity("SkillAssessment.Models.Level", b =>
                {
                    b.Navigation("Assessment");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("SkillAssessment.Models.Topics", b =>
                {
                    b.Navigation("Assessment");

                    b.Navigation("Levels");

                    b.Navigation("Questions");

                    b.Navigation("Results");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Navigation("assessments");

                    b.Navigation("results");
                });
#pragma warning restore 612, 618
        }
    }
}
