﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kol2poprawa_ko_s22106.Models;

namespace kol2poprawa_ko_s22106.Migrations
{
    [DbContext(typeof(TeamDbContext))]
    [Migration("20220623103403_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("kol2poprawa_ko_s22106.Models.File", b =>
                {
                    b.Property<int>("fileId")
                        .HasColumnType("int");

                    b.Property<int>("teamId")
                        .HasColumnType("int");

                    b.Property<string>("fileExtension")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("fileName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("fileSize")
                        .HasColumnType("int");

                    b.HasKey("fileId", "teamId");

                    b.HasIndex("teamId");

                    b.ToTable("File");

                    b.HasData(
                        new
                        {
                            fileId = 1,
                            teamId = 1,
                            fileExtension = "ext",
                            fileName = "name",
                            fileSize = 16
                        });
                });

            modelBuilder.Entity("kol2poprawa_ko_s22106.Models.Member", b =>
                {
                    b.Property<int>("memberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("memberName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("memberNickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("memberSurname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("organizationId")
                        .HasColumnType("int");

                    b.HasKey("memberId");

                    b.HasIndex("organizationId");

                    b.ToTable("Member");

                    b.HasData(
                        new
                        {
                            memberId = 1,
                            memberName = "name",
                            memberNickname = "nickname",
                            memberSurname = "surname",
                            organizationId = 1
                        });
                });

            modelBuilder.Entity("kol2poprawa_ko_s22106.Models.Membership", b =>
                {
                    b.Property<int>("memberId")
                        .HasColumnType("int");

                    b.Property<int>("teamId")
                        .HasColumnType("int");

                    b.Property<DateTime>("membershipDate")
                        .HasColumnType("datetime2");

                    b.HasKey("memberId", "teamId");

                    b.HasIndex("teamId");

                    b.ToTable("Membership");

                    b.HasData(
                        new
                        {
                            memberId = 1,
                            teamId = 1,
                            membershipDate = new DateTime(2022, 6, 23, 12, 34, 2, 815, DateTimeKind.Local).AddTicks(3750)
                        });
                });

            modelBuilder.Entity("kol2poprawa_ko_s22106.Models.Organization", b =>
                {
                    b.Property<int>("organizationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("organizationDomain")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("organizationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("organizationID");

                    b.ToTable("Organization");

                    b.HasData(
                        new
                        {
                            organizationID = 1,
                            organizationDomain = "domain",
                            organizationName = "org1"
                        });
                });

            modelBuilder.Entity("kol2poprawa_ko_s22106.Models.Team", b =>
                {
                    b.Property<int>("teamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("organizationId")
                        .HasColumnType("int");

                    b.Property<string>("teamName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("teamId");

                    b.HasIndex("organizationId");

                    b.ToTable("Team");

                    b.HasData(
                        new
                        {
                            teamId = 1,
                            description = "description",
                            organizationId = 1,
                            teamName = "team1"
                        });
                });

            modelBuilder.Entity("kol2poprawa_ko_s22106.Models.File", b =>
                {
                    b.HasOne("kol2poprawa_ko_s22106.Models.Team", "Team")
                        .WithMany("Files")
                        .HasForeignKey("teamId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("kol2poprawa_ko_s22106.Models.Member", b =>
                {
                    b.HasOne("kol2poprawa_ko_s22106.Models.Organization", "Organization")
                        .WithMany("Members")
                        .HasForeignKey("organizationId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("kol2poprawa_ko_s22106.Models.Membership", b =>
                {
                    b.HasOne("kol2poprawa_ko_s22106.Models.Member", "Member")
                        .WithMany("Membperships")
                        .HasForeignKey("memberId")
                        .IsRequired();

                    b.HasOne("kol2poprawa_ko_s22106.Models.Team", "Team")
                        .WithMany("Memberships")
                        .HasForeignKey("teamId")
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("kol2poprawa_ko_s22106.Models.Team", b =>
                {
                    b.HasOne("kol2poprawa_ko_s22106.Models.Organization", "Organization")
                        .WithMany("Teams")
                        .HasForeignKey("organizationId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("kol2poprawa_ko_s22106.Models.Member", b =>
                {
                    b.Navigation("Membperships");
                });

            modelBuilder.Entity("kol2poprawa_ko_s22106.Models.Organization", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("kol2poprawa_ko_s22106.Models.Team", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("Memberships");
                });
#pragma warning restore 612, 618
        }
    }
}
