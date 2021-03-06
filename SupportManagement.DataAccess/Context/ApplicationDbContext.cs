using Microsoft.EntityFrameworkCore;
using SupportManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MSI\MSSQLSERVER14;Database=SupportManagementDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamMember>()
                 .HasOne(t => t.Team)
                 .WithMany(tm => tm.TeamMembers)
                 .HasForeignKey(fk => fk.TeamId);

            modelBuilder.Entity<TeamMember>()
               .HasOne(t => t.Seniority)
               .WithMany(tm => tm.TeamMembers)
               .HasForeignKey(fk => fk.SeniorityId);

            modelBuilder.Entity<Chat>()
               .HasOne(t => t.User)
               .WithMany(tm => tm.Chats)
               .HasForeignKey(fk => fk.UserId);

            modelBuilder.Entity<Chat>()
               .HasOne(t => t.TeamMember)
               .WithMany(tm => tm.Chats)
               .HasForeignKey(fk => fk.TeamMemberId);

            modelBuilder.Entity<SupportQueue>()
               .HasOne(t => t.TeamMember)
               .WithMany(tm => tm.SupportQueues)
               .HasForeignKey(fk => fk.TeamMemberId);

            modelBuilder.Entity<User>().HasData(
              new User
              {
                  Id=1,
                  UserName="User 1"
              });

            modelBuilder.Entity<Seniority>().HasData(
              new Seniority
              {
                  Id = 1,
                  SeniorityName = "Junior",
                  Multiplier = 0.4,
                  AssignmentOrder = 1
              },
              new Seniority
              {
                  Id = 2,
                  SeniorityName = "Mid-Level",
                  Multiplier = 0.6,
                  AssignmentOrder = 2
              },
              new Seniority
              {
                  Id = 3,
                  SeniorityName = "Senior",
                  Multiplier = 0.8,
                  AssignmentOrder = 3
              },
              new Seniority
              {
                  Id = 4,
                  SeniorityName = "Team Lead",
                  Multiplier = 0.5,
                  AssignmentOrder = 4
              });

            modelBuilder.Entity<Team>().HasData(
               new Team
               {
                   Id = 1,
                   TeamName = "Team A",
                   ShiftStarts = new TimeSpan(8, 0, 0),
                   ShiftEnds = new TimeSpan(15, 59, 59),
                   IsOverflowTeam = false,
                   WorksInOfficeHours = true,
               },
               new Team
               {
                   Id = 2,
                   TeamName = "Team B",
                   ShiftStarts = new TimeSpan(16, 0, 0),
                   ShiftEnds = new TimeSpan(23, 59, 59),
                   IsOverflowTeam = false,
                   WorksInOfficeHours = false,
               },
               new Team
               {
                   Id = 3,
                   TeamName = "Team C",
                   ShiftStarts = new TimeSpan(0, 0, 0),
                   ShiftEnds = new TimeSpan(7, 59, 59),
                   IsOverflowTeam = false,
                   WorksInOfficeHours = false,
               },
               new Team
               {
                   Id = 4,
                   TeamName = "Overflow Team",
                   ShiftStarts = new TimeSpan(0, 0, 0),
                   ShiftEnds = new TimeSpan(23, 59, 59),
                   IsOverflowTeam = true,
                   WorksInOfficeHours = true,
               });

            modelBuilder.Entity<TeamMember>().HasData(
               new TeamMember
               {
                   Id = 1,
                   TeamId = 1,
                   SeniorityId = 4,
                   QueueName="member_1"
               },
               new TeamMember
               {
                   Id = 2,
                   TeamId = 1,
                   SeniorityId = 2,
                   QueueName = "member_2"
               },
               new TeamMember
               {
                   Id = 3,
                   TeamId = 1,
                   SeniorityId = 2,
                   QueueName = "member_3"
               },
               new TeamMember
               {
                   Id = 4,
                   TeamId = 1,
                   SeniorityId = 1,
                   QueueName = "member_4"
               },


               new TeamMember
               {
                   Id = 5,
                   TeamId = 2,
                   SeniorityId = 3,
                   QueueName = "member_5"
               },
               new TeamMember
               {
                   Id = 6,
                   TeamId = 2,
                   SeniorityId = 2,
                   QueueName = "member_6"
               },
               new TeamMember
               {
                   Id = 7,
                   TeamId = 2,
                   SeniorityId = 1,
                   QueueName = "member_7"
               },
               new TeamMember
               {
                   Id = 8,
                   TeamId = 2,
                   SeniorityId = 1,
                   QueueName = "member_8"
               },


               new TeamMember
               {
                   Id = 9,
                   TeamId = 3,
                   SeniorityId = 2,
                   QueueName = "member_9"
               },
               new TeamMember
               {
                   Id = 10,
                   TeamId = 3,
                   SeniorityId = 2,
                   QueueName = "member_10"
               },


               new TeamMember
               {
                   Id = 11,
                   TeamId = 4,
                   SeniorityId = 1,
                   QueueName = "member_11"
               },
               new TeamMember
               {
                   Id = 12,
                   TeamId = 4,
                   SeniorityId = 1,
                   QueueName = "member_12"
               },
               new TeamMember
               {
                   Id = 13,
                   TeamId = 4,
                   SeniorityId = 1,
                   QueueName = "member_13"
               },
               new TeamMember
               {
                   Id = 14,
                   TeamId = 4,
                   SeniorityId = 1,
                   QueueName = "member_14"
               },
               new TeamMember
               {
                   Id = 15,
                   TeamId = 4,
                   SeniorityId = 1,
                   QueueName = "member_15"
               },
               new TeamMember
               {
                   Id = 16,
                   TeamId = 4,
                   SeniorityId = 1,
                   QueueName = "member_16"
               });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Seniority> Seniorities { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SupportQueue> SupportQueues { get; set; }
    }
}
