using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace kol2poprawa_ko_s22106.Models
{
    public class TeamDbContext : DbContext
    {
        public TeamDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>(builder =>
            {
                builder.HasKey(e => e.organizationID);
                builder.Property(e => e.organizationName).HasMaxLength(100).IsRequired();
                builder.Property(e => e.organizationDomain).HasMaxLength(50).IsRequired();

                builder.HasData(
                    new Organization
                    {
                        organizationID = 1,
                        organizationName = "org1",
                        organizationDomain = "domain"
                    },
                    new Organization
                    {
                        organizationID = 2,
                        organizationName = "org2",
                        organizationDomain = "domain2"
                    }
                    );
                builder.ToTable("Organization");
            });
            modelBuilder.Entity<Team>(builder =>
            {
                builder.HasKey(e => e.teamId);
                builder.HasOne(e => e.Organization).WithMany(e => e.Teams).HasForeignKey(e => e.organizationId).OnDelete(DeleteBehavior.ClientCascade);
                builder.Property(e => e.teamName).HasMaxLength(50).IsRequired();
                builder.Property(e => e.description).HasMaxLength(500);

                builder.HasData(new Team
                {
                    teamId = 1,
                    teamName = "team1",
                    organizationId = 1,
                    description = "description"
                });
                builder.ToTable("Team");
            });
            modelBuilder.Entity<Member>(builder =>
            {
                builder.HasKey(e => e.memberId);
                builder.HasOne(e => e.Organization).WithMany(e => e.Members).HasForeignKey(e => e.organizationId).OnDelete(DeleteBehavior.ClientCascade);
                builder.Property(e => e.memberName).HasMaxLength(20).IsRequired();
                builder.Property(e => e.memberName).HasMaxLength(50).IsRequired();
                builder.Property(e => e.memberName).HasMaxLength(20);

                builder.HasData(new Member
                {
                    memberId = 1,
                    organizationId = 1,
                    memberName = "name",
                    memberSurname = "surname",
                    memberNickname = "nickname"
                },
                new Member
                {
                    memberId = 2,
                    organizationId = 1,
                    memberName = "name2",
                    memberSurname = "surname2",
                    memberNickname = "nickname2"
                },
                new Member
                {
                    memberId = 3,
                    organizationId = 2,
                    memberName = "name3",
                    memberSurname = "surname3",
                    memberNickname = "nickname3"
                });
                builder.ToTable("Member");
            });
            modelBuilder.Entity<Membership>(builder =>
            {
                builder.HasKey(e => new { e.memberId, e.teamId });
                builder.HasOne(e => e.Member).WithMany(e => e.Membperships).HasForeignKey(e => e.memberId).OnDelete(DeleteBehavior.ClientSetNull);
                builder.HasOne(e => e.Team).WithMany(e => e.Memberships).HasForeignKey(e => e.teamId).OnDelete(DeleteBehavior.ClientSetNull);
                builder.Property(e => e.membershipDate).IsRequired();

                builder.HasData(new Membership
                {
                    memberId = 1,
                    teamId = 1,
                    membershipDate = DateTime.Now
                });
                builder.ToTable("Membership");
            });
            modelBuilder.Entity<File>(builder =>
            {
                builder.HasKey(e => new { e.fileId, e.teamId });
                builder.HasOne(e => e.Team).WithMany(e => e.Files).HasForeignKey(e => e.teamId).OnDelete(DeleteBehavior.ClientCascade);
                builder.Property(e => e.fileName).HasMaxLength(100).IsRequired();
                builder.Property(e => e.fileExtension).HasMaxLength(4).IsRequired();
                builder.Property(e => e.fileSize).IsRequired();

                builder.HasData(new File
                {
                    fileId = 1,
                    teamId = 1,
                    fileName = "name",
                    fileExtension = "ext",
                    fileSize = 16
                });
                builder.ToTable("File");
            });

        }
    }
}