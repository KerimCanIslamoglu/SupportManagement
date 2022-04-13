﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SupportManagement.DataAccess.Context;

namespace SupportManagement.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220413183256_added-chat")]
    partial class addedchat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SupportManagement.Entities.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SentOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("TeamMemberId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamMemberId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("SupportManagement.Entities.Seniority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssignmentOrder")
                        .HasColumnType("int");

                    b.Property<double>("Multiplier")
                        .HasColumnType("float");

                    b.Property<string>("SeniorityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Seniorities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssignmentOrder = 1,
                            Multiplier = 0.40000000000000002,
                            SeniorityName = "Junior"
                        },
                        new
                        {
                            Id = 2,
                            AssignmentOrder = 2,
                            Multiplier = 0.59999999999999998,
                            SeniorityName = "Mid-Level"
                        },
                        new
                        {
                            Id = 3,
                            AssignmentOrder = 3,
                            Multiplier = 0.80000000000000004,
                            SeniorityName = "Senior"
                        },
                        new
                        {
                            Id = 4,
                            AssignmentOrder = 4,
                            Multiplier = 0.5,
                            SeniorityName = "Team Lead"
                        });
                });

            modelBuilder.Entity("SupportManagement.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsOverflowTeam")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("ShiftEnds")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("ShiftStarts")
                        .HasColumnType("time");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsOverflowTeam = false,
                            ShiftEnds = new TimeSpan(0, 15, 59, 59, 0),
                            ShiftStarts = new TimeSpan(0, 8, 0, 0, 0),
                            TeamName = "Team A"
                        },
                        new
                        {
                            Id = 2,
                            IsOverflowTeam = false,
                            ShiftEnds = new TimeSpan(0, 23, 59, 59, 0),
                            ShiftStarts = new TimeSpan(0, 16, 0, 0, 0),
                            TeamName = "Team B"
                        },
                        new
                        {
                            Id = 3,
                            IsOverflowTeam = false,
                            ShiftEnds = new TimeSpan(0, 7, 59, 59, 0),
                            ShiftStarts = new TimeSpan(0, 0, 0, 0, 0),
                            TeamName = "Team C"
                        },
                        new
                        {
                            Id = 4,
                            IsOverflowTeam = true,
                            ShiftEnds = new TimeSpan(0, 23, 59, 59, 0),
                            ShiftStarts = new TimeSpan(0, 0, 0, 0, 0),
                            TeamName = "Overflow Team"
                        });
                });

            modelBuilder.Entity("SupportManagement.Entities.TeamMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SeniorityId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SeniorityId")
                        .IsUnique();

                    b.HasIndex("TeamId");

                    b.ToTable("TeamMembers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SeniorityId = 4,
                            TeamId = 1
                        },
                        new
                        {
                            Id = 2,
                            SeniorityId = 2,
                            TeamId = 1
                        },
                        new
                        {
                            Id = 3,
                            SeniorityId = 2,
                            TeamId = 1
                        },
                        new
                        {
                            Id = 4,
                            SeniorityId = 1,
                            TeamId = 1
                        },
                        new
                        {
                            Id = 5,
                            SeniorityId = 3,
                            TeamId = 2
                        },
                        new
                        {
                            Id = 6,
                            SeniorityId = 2,
                            TeamId = 2
                        },
                        new
                        {
                            Id = 7,
                            SeniorityId = 1,
                            TeamId = 2
                        },
                        new
                        {
                            Id = 8,
                            SeniorityId = 1,
                            TeamId = 2
                        },
                        new
                        {
                            Id = 9,
                            SeniorityId = 2,
                            TeamId = 3
                        },
                        new
                        {
                            Id = 10,
                            SeniorityId = 2,
                            TeamId = 3
                        },
                        new
                        {
                            Id = 11,
                            SeniorityId = 1,
                            TeamId = 4
                        },
                        new
                        {
                            Id = 12,
                            SeniorityId = 1,
                            TeamId = 4
                        },
                        new
                        {
                            Id = 13,
                            SeniorityId = 1,
                            TeamId = 4
                        },
                        new
                        {
                            Id = 14,
                            SeniorityId = 1,
                            TeamId = 4
                        },
                        new
                        {
                            Id = 15,
                            SeniorityId = 1,
                            TeamId = 4
                        },
                        new
                        {
                            Id = 16,
                            SeniorityId = 1,
                            TeamId = 4
                        });
                });

            modelBuilder.Entity("SupportManagement.Entities.Chat", b =>
                {
                    b.HasOne("SupportManagement.Entities.TeamMember", "TeamMember")
                        .WithMany("Chats")
                        .HasForeignKey("TeamMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TeamMember");
                });

            modelBuilder.Entity("SupportManagement.Entities.TeamMember", b =>
                {
                    b.HasOne("SupportManagement.Entities.Seniority", "Seniority")
                        .WithOne("TeamMember")
                        .HasForeignKey("SupportManagement.Entities.TeamMember", "SeniorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SupportManagement.Entities.Team", "Team")
                        .WithMany("TeamMembers")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seniority");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("SupportManagement.Entities.Seniority", b =>
                {
                    b.Navigation("TeamMember");
                });

            modelBuilder.Entity("SupportManagement.Entities.Team", b =>
                {
                    b.Navigation("TeamMembers");
                });

            modelBuilder.Entity("SupportManagement.Entities.TeamMember", b =>
                {
                    b.Navigation("Chats");
                });
#pragma warning restore 612, 618
        }
    }
}
