﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Smedix.RecruitmentFunnel.Context;

#nullable disable

namespace Smedix.RecruitmentFunnel.Migrations
{
    [DbContext(typeof(RecruitmentContext))]
    [Migration("20220428110613_fixed-technical-interview-statuses")]
    partial class fixedtechnicalinterviewstatuses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Smedix.RecruitmentFunnel.Models.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CandidateStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LinkedIn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferredBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YearsOfExperience")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CandidateStatusId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("RoleId");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("Smedix.RecruitmentFunnel.Models.CandidateFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("CandidateFiles");
                });

            modelBuilder.Entity("Smedix.RecruitmentFunnel.Models.CandidateHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CandidateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EntryDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Issuer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manager")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PlannedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StageStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("StageStatusId");

                    b.ToTable("CandidateHistories");
                });

            modelBuilder.Entity("Smedix.RecruitmentFunnel.Models.CandidateStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ColorHex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CandidateStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ColorHex = "#40E0D0",
                            Name = "Select..."
                        },
                        new
                        {
                            Id = 2,
                            ColorHex = "#3655B3",
                            Name = "Applied"
                        },
                        new
                        {
                            Id = 3,
                            ColorHex = "#800080",
                            Name = "Contacted"
                        },
                        new
                        {
                            Id = 4,
                            ColorHex = "#5A0049",
                            Name = "Recontacted"
                        },
                        new
                        {
                            Id = 5,
                            ColorHex = "#F07443",
                            Name = "Uncontacted"
                        },
                        new
                        {
                            Id = 6,
                            ColorHex = "#008000",
                            Name = "Hired"
                        },
                        new
                        {
                            Id = 7,
                            ColorHex = "#E04DB0",
                            Name = "In process"
                        },
                        new
                        {
                            Id = 8,
                            ColorHex = "#B30000",
                            Name = "Blacklist"
                        },
                        new
                        {
                            Id = 9,
                            ColorHex = "#F50A0A",
                            Name = "Rejected"
                        },
                        new
                        {
                            Id = 10,
                            ColorHex = "#595260",
                            Name = "Not Interested"
                        },
                        new
                        {
                            Id = 11,
                            ColorHex = "#444444",
                            Name = "Decline Offer"
                        },
                        new
                        {
                            Id = 12,
                            ColorHex = "#6D8299",
                            Name = "Withdrew"
                        },
                        new
                        {
                            Id = 13,
                            ColorHex = "#DAAB05",
                            Name = "Keep in mind"
                        },
                        new
                        {
                            Id = 14,
                            ColorHex = "#0B4619",
                            Name = "Former employee"
                        });
                });

            modelBuilder.Entity("Smedix.RecruitmentFunnel.Models.CandidateTechnology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<int>("TechnologyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("TechnologyId");

                    b.ToTable("CandidateTechnologies");
                });

            modelBuilder.Entity("Smedix.RecruitmentFunnel.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Administrative"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bioinformatics"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Development"
                        },
                        new
                        {
                            Id = 4,
                            Name = "HR"
                        },
                        new
                        {
                            Id = 5,
                            Name = "IT"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Management"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Requirements"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Testing"
                        });
                });

            modelBuilder.Entity("Smedix.RecruitmentFunnel.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Select..."
                        },
                        new
                        {
                            Id = 2,
                            Name = "Software Tester Manual"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Software Tester Automation"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Software Tester"
                        },
                        new
                        {
                            Id = 5,
                            Name = "System Tester"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Software Developer"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Business Analyst"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Requirements Analyst"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Product Owner"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Scrum Master"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Project Manager"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Delivery Manager"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Director"
                        },
                        new
                        {
                            Id = 14,
                            Name = "QA Architect"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Development Architect"
                        },
                        new
                        {
                            Id = 16,
                            Name = "DevOps"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Sys Admin"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Recruiter"
                        },
                        new
                        {
                            Id = 19,
                            Name = "HR Specialist"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Business Development Manager"
                        });
                });

            modelBuilder.Entity("Smedix.RecruitmentFunnel.Models.Stage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sourced"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Contacted"
                        },
                        new
                        {
                            Id = 3,
                            Name = "HR Interview"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Technical Interview"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Offer"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Final Status"
                        });
                });

            modelBuilder.Entity("Smedix.RecruitmentFunnel.Models.StageStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("StageId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StageId");

                    b.HasIndex("StatusId");

                    b.ToTable("StageStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StageId = 2,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 2,
                            StageId = 2,
                            StatusId = 4
                        },
                        new
                        {
                            Id = 3,
                            StageId = 2,
                            StatusId = 5
                        },
                        new
                        {
                            Id = 4,
                            StageId = 2,
                            StatusId = 6
                        },
                        new
                        {
                            Id = 5,
                            StageId = 3,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 6,
                            StageId = 3,
                            StatusId = 2
                        },
                        new
                        {
                            Id = 7,
                            StageId = 4,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 8,
                            StageId = 4,
                            StatusId = 2
                        });
                });

            modelBuilder.Entity("Smedix.RecruitmentFunnel.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Accepted"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Rejected"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Declined"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Not Interested"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Review in 6 months"
                        },
                        new
                        {
                            Id = 6,
                            Name = "No Answer"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Renegotiated"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Feedback sent"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Hired"
                        });
                });

            modelBuilder.Entity("Smedix.RecruitmentFunnel.Models.Technology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Technologies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Select..."
                        },
                        new
                        {
                            Id = 2,
                            Name = ".NET"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Javascript"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Full Stack"
                        },
                        new
                        {
                            Id = 5,
                            Name = "QA Automation"
                        },
                        new
                        {
                            Id = 6,
                            Name = "QA"
                        },
                        new
                        {
                            Id = 7,
                            Name = "DevOps"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Sys Administraton"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Delphi"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Requirements"
                        },
                        new
                        {
                            Id = 11,
                            Name = "LabVIEW"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Front end"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Back end"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Recruitment"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Administration"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Python"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Product Owner"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Management"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Java"
                        },
                        new
                        {
                            Id = 20,
                            Name = "PHP"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Embedded C/C++"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Embedded C"
                        },
                        new
                        {
                            Id = 23,
                            Name = "C++"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Angular"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Angular JS"
                        },
                        new
                        {
                            Id = 26,
                            Name = "React JS"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Node JS"
                        },
                        new
                        {
                            Id = 28,
                            Name = "Cybersecurity"
                        });
                });

            modelBuilder.Entity("Smedix.RecruitmentFunnel.Models.Candidate", b =>
                {
                    b.HasOne("Smedix.RecruitmentFunnel.Models.CandidateStatus", "CandidateStatus")
                        .WithMany()
                        .HasForeignKey("CandidateStatusId");

                    b.HasOne("Smedix.RecruitmentFunnel.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("Smedix.RecruitmentFunnel.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("CandidateStatus");

                    b.Navigation("Department");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Smedix.RecruitmentFunnel.Models.CandidateFile", b =>
                {
                    b.HasOne("Smedix.RecruitmentFunnel.Models.Candidate", "Candidate")
                        .WithMany("CandidateFiles")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("Smedix.RecruitmentFunnel.Models.CandidateHistory", b =>
                {
                    b.HasOne("Smedix.RecruitmentFunnel.Models.Candidate", "Candidate")
                        .WithMany("CandidateHistories")
                        .HasForeignKey("CandidateId");

                    b.HasOne("Smedix.RecruitmentFunnel.Models.StageStatus", "StageStatus")
                        .WithMany()
                        .HasForeignKey("StageStatusId");

                    b.Navigation("Candidate");

                    b.Navigation("StageStatus");
                });

            modelBuilder.Entity("Smedix.RecruitmentFunnel.Models.CandidateTechnology", b =>
                {
                    b.HasOne("Smedix.RecruitmentFunnel.Models.Candidate", "Candidate")
                        .WithMany("CandidateTechnologies")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Smedix.RecruitmentFunnel.Models.Technology", "Technology")
                        .WithMany()
                        .HasForeignKey("TechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Technology");
                });

            modelBuilder.Entity("Smedix.RecruitmentFunnel.Models.StageStatus", b =>
                {
                    b.HasOne("Smedix.RecruitmentFunnel.Models.Stage", "Stage")
                        .WithMany()
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Smedix.RecruitmentFunnel.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stage");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Smedix.RecruitmentFunnel.Models.Candidate", b =>
                {
                    b.Navigation("CandidateFiles");

                    b.Navigation("CandidateHistories");

                    b.Navigation("CandidateTechnologies");
                });
#pragma warning restore 612, 618
        }
    }
}
