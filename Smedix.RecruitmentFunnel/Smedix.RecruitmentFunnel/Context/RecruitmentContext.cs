using Microsoft.EntityFrameworkCore;
using Smedix.RecruitmentFunnel.Models;

namespace Smedix.RecruitmentFunnel.Context
{
	public class RecruitmentContext : DbContext
	{
		private readonly IConfiguration _configuration;

		public RecruitmentContext(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public DbSet<Candidate> Candidates { get; set; }
		public DbSet<CandidateFile> CandidateFiles { get; set; }
		public DbSet<CandidateHistory> CandidateHistories { get; set; }
		public DbSet<CandidateStatus> CandidateStatuses { get; set; }
		public DbSet<CandidateTechnology> CandidateTechnologies { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Stage> Stages { get; set; }
		public DbSet<StageStatus> StageStatuses { get; set; }
		public DbSet<Status> Statuses { get; set; }
		public DbSet<Technology> Technologies { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(_configuration.GetConnectionString("RecruitmentFunnelDatabase"));
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Technology
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 1, Name = "Select..." });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 2, Name = ".NET" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 3, Name = "Javascript" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 4, Name = "Full Stack" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 5, Name = "QA Automation" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 6, Name = "QA" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 7, Name = "DevOps" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 8, Name = "Sys Administraton" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 9, Name = "Delphi" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 10, Name = "Requirements" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 11, Name = "LabVIEW" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 12, Name = "Front end" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 13, Name = "Back end" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 14, Name = "Recruitment" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 15, Name = "Administration" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 16, Name = "Python" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 17, Name = "Product Owner" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 18, Name = "Management" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 19, Name = "Java" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 20, Name = "PHP" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 21, Name = "Embedded C/C++" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 22, Name = "Embedded C" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 23, Name = "C++" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 24, Name = "Angular" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 25, Name = "Angular JS" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 26, Name = "React JS" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 27, Name = "Node JS" });
			modelBuilder.Entity<Technology>().HasData(new Technology { Id = 28, Name = "Cybersecurity" });

			//Role
			modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = "Select..." });
			modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = "Software Tester Manual" });
			modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = "Software Tester Automation" });
			modelBuilder.Entity<Role>().HasData(new Role { Id = 4, Name = "Software Tester" });
			modelBuilder.Entity<Role>().HasData(new Role { Id = 5, Name = "System Tester" });
			modelBuilder.Entity<Role>().HasData(new Role { Id = 6, Name = "Software Developer" });
			modelBuilder.Entity<Role>().HasData(new Role { Id = 7, Name = "Business Analyst" });
			modelBuilder.Entity<Role>().HasData(new Role { Id = 8, Name = "Requirements Analyst" });
			modelBuilder.Entity<Role>().HasData(new Role { Id = 9, Name = "Product Owner" });
			modelBuilder.Entity<Role>().HasData(new Role { Id = 10, Name = "Scrum Master" });
			modelBuilder.Entity<Role>().HasData(new Role { Id = 11, Name = "Project Manager" });
			modelBuilder.Entity<Role>().HasData(new Role { Id = 12, Name = "Delivery Manager" });
			modelBuilder.Entity<Role>().HasData(new Role { Id = 13, Name = "Director" });
			modelBuilder.Entity<Role>().HasData(new Role { Id = 14, Name = "QA Architect" });
			modelBuilder.Entity<Role>().HasData(new Role { Id = 15, Name = "Development Architect" });
			modelBuilder.Entity<Role>().HasData(new Role { Id = 16, Name = "DevOps" });
			modelBuilder.Entity<Role>().HasData(new Role { Id = 17, Name = "Sys Admin" });
			modelBuilder.Entity<Role>().HasData(new Role { Id = 18, Name = "Recruiter" });
			modelBuilder.Entity<Role>().HasData(new Role { Id = 19, Name = "HR Specialist" });
			modelBuilder.Entity<Role>().HasData(new Role { Id = 20, Name = "Business Development Manager" });

			//Candidate Status
			//common
			modelBuilder.Entity<Status>().HasData(new Status { Id = 1, Name = "Accepted" });
			modelBuilder.Entity<Status>().HasData(new Status { Id = 2, Name = "Rejected" });
			modelBuilder.Entity<Status>().HasData(new Status { Id = 3, Name = "Declined" });

			//contacted
			modelBuilder.Entity<Status>().HasData(new Status { Id = 4, Name = "Not Interested" });
			modelBuilder.Entity<Status>().HasData(new Status { Id = 5, Name = "Review in 6 months" });
			modelBuilder.Entity<Status>().HasData(new Status { Id = 6, Name = "No Answer" });
			modelBuilder.Entity<Status>().HasData(new Status { Id = 7, Name = "Renegotiated" });
			modelBuilder.Entity<Status>().HasData(new Status { Id = 8, Name = "Feedback sent" });
			modelBuilder.Entity<Status>().HasData(new Status { Id = 9, Name = "Hired" });

			modelBuilder.Entity<Status>().HasData(new Status { Id = 10, Name = "None" });


			//Candidate Status
			modelBuilder.Entity<CandidateStatus>().HasData(new CandidateStatus { Id = 1, Name = "Select...", ColorHex = "#40E0D0" });
			modelBuilder.Entity<CandidateStatus>().HasData(new CandidateStatus { Id = 2, Name = "Applied", ColorHex = "#3655B3" });
			modelBuilder.Entity<CandidateStatus>().HasData(new CandidateStatus { Id = 3, Name = "Contacted", ColorHex = "#800080" });
			modelBuilder.Entity<CandidateStatus>().HasData(new CandidateStatus { Id = 4, Name = "Recontacted", ColorHex = "#5A0049" });
			modelBuilder.Entity<CandidateStatus>().HasData(new CandidateStatus { Id = 5, Name = "Uncontacted", ColorHex = "#F07443" });
			modelBuilder.Entity<CandidateStatus>().HasData(new CandidateStatus { Id = 6, Name = "Hired", ColorHex = "#008000" });
			modelBuilder.Entity<CandidateStatus>().HasData(new CandidateStatus { Id = 7, Name = "In process", ColorHex = "#E04DB0" });
			modelBuilder.Entity<CandidateStatus>().HasData(new CandidateStatus { Id = 8, Name = "Blacklist", ColorHex = "#B30000" });
			modelBuilder.Entity<CandidateStatus>().HasData(new CandidateStatus { Id = 9, Name = "Rejected", ColorHex = "#F50A0A" });
			modelBuilder.Entity<CandidateStatus>().HasData(new CandidateStatus { Id = 10, Name = "Not Interested", ColorHex = "#595260" });
			modelBuilder.Entity<CandidateStatus>().HasData(new CandidateStatus { Id = 11, Name = "Decline Offer", ColorHex = "#444444" });
			modelBuilder.Entity<CandidateStatus>().HasData(new CandidateStatus { Id = 12, Name = "Withdrew", ColorHex = "#6D8299" });
			modelBuilder.Entity<CandidateStatus>().HasData(new CandidateStatus { Id = 13, Name = "Keep in mind", ColorHex = "#DAAB05" });
			modelBuilder.Entity<CandidateStatus>().HasData(new CandidateStatus { Id = 14, Name = "Former employee", ColorHex = "#0B4619" });

			//Stages
			modelBuilder.Entity<Stage>().HasData(new Stage { Id = 1, Name = "Sourced" });
			modelBuilder.Entity<Stage>().HasData(new Stage { Id = 2, Name = "Contacted" });
			modelBuilder.Entity<Stage>().HasData(new Stage { Id = 3, Name = "HR Interview" });
			modelBuilder.Entity<Stage>().HasData(new Stage { Id = 4, Name = "Technical Interview" });
			modelBuilder.Entity<Stage>().HasData(new Stage { Id = 5, Name = "Offer" });
			modelBuilder.Entity<Stage>().HasData(new Stage { Id = 6, Name = "Final Status" });

			//Departments
			modelBuilder.Entity<Department>().HasData(new Department { Id = 1, Name = "Administrative" });
			modelBuilder.Entity<Department>().HasData(new Department { Id = 2, Name = "Bioinformatics" });
			modelBuilder.Entity<Department>().HasData(new Department { Id = 3, Name = "Development" });
			modelBuilder.Entity<Department>().HasData(new Department { Id = 4, Name = "HR" });
			modelBuilder.Entity<Department>().HasData(new Department { Id = 5, Name = "IT" });
			modelBuilder.Entity<Department>().HasData(new Department { Id = 6, Name = "Management" });
			modelBuilder.Entity<Department>().HasData(new Department { Id = 7, Name = "Requirements" });
			modelBuilder.Entity<Department>().HasData(new Department { Id = 8, Name = "Testing" });

			//StageStatus
			modelBuilder.Entity<StageStatus>().HasData(new StageStatus { Id = 1, StageId = 2, StatusId = 1 });
			modelBuilder.Entity<StageStatus>().HasData(new StageStatus { Id = 2, StageId = 2, StatusId = 4 });
			modelBuilder.Entity<StageStatus>().HasData(new StageStatus { Id = 3, StageId = 2, StatusId = 5 });
			modelBuilder.Entity<StageStatus>().HasData(new StageStatus { Id = 4, StageId = 2, StatusId = 6 });

			modelBuilder.Entity<StageStatus>().HasData(new StageStatus { Id = 5, StageId = 3, StatusId = 1 });
			modelBuilder.Entity<StageStatus>().HasData(new StageStatus { Id = 6, StageId = 3, StatusId = 2 });

			modelBuilder.Entity<StageStatus>().HasData(new StageStatus { Id = 7, StageId = 4, StatusId = 1 });
			modelBuilder.Entity<StageStatus>().HasData(new StageStatus { Id = 8, StageId = 4, StatusId = 2 });

			modelBuilder.Entity<StageStatus>().HasData(new StageStatus { Id = 9, StageId = 5, StatusId = 1 });
			modelBuilder.Entity<StageStatus>().HasData(new StageStatus { Id = 10, StageId = 5, StatusId = 3 });
			modelBuilder.Entity<StageStatus>().HasData(new StageStatus { Id = 11, StageId = 5, StatusId = 7 });

			modelBuilder.Entity<StageStatus>().HasData(new StageStatus { Id = 12, StageId = 6, StatusId = 2 });
			modelBuilder.Entity<StageStatus>().HasData(new StageStatus { Id = 13, StageId = 6, StatusId = 9 });
			modelBuilder.Entity<StageStatus>().HasData(new StageStatus { Id = 14, StageId = 6, StatusId = 8 });

			modelBuilder.Entity<StageStatus>().HasData(new StageStatus { Id = 15, StageId = 1, StatusId = 10 });
			modelBuilder.Entity<StageStatus>().HasData(new StageStatus { Id = 16, StageId = 2, StatusId = 10 });
			modelBuilder.Entity<StageStatus>().HasData(new StageStatus { Id = 17, StageId = 3, StatusId = 10 });
			modelBuilder.Entity<StageStatus>().HasData(new StageStatus { Id = 18, StageId = 4, StatusId = 10 });
			modelBuilder.Entity<StageStatus>().HasData(new StageStatus { Id = 19, StageId = 5, StatusId = 10 });
			modelBuilder.Entity<StageStatus>().HasData(new StageStatus { Id = 20, StageId = 6, StatusId = 10 });


		}

	}
}
