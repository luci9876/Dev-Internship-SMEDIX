using AutoMapper;
using Smedix.RecruitmentFunnel.Context;
using Smedix.RecruitmentFunnel.Helpers;
using Smedix.RecruitmentFunnel.Helpers.Interface;
using Smedix.RecruitmentFunnel.Models;
using Smedix.RecruitmentFunnel.Repository;
using Smedix.RecruitmentFunnel.Services;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<RecruitmentContext>(ServiceLifetime.Transient);
var uiUrl = builder.Configuration["RecruitmentFunnelUI"];
builder.Services.AddDbContext<RecruitmentContext>(ServiceLifetime.Transient);
builder.Services.AddScoped<IGenericRepository<Candidate>, GenericRepository<Candidate>>();
builder.Services.AddScoped<IGenericRepository<CandidateFile>, GenericRepository<CandidateFile>>();
builder.Services.AddScoped<IGenericRepository<CandidateHistory>, GenericRepository<CandidateHistory>>();
// Add services to the container.
builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(

		builder =>
		{
			builder.WithOrigins(uiUrl).AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader();
		});
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<ICandidateHistoryRepository, CandidateHistoryRepository>();
builder.Services.AddScoped<ICandidateService, CandidateService>();
builder.Services.AddScoped<IFileRepository, FileRepository>();
builder.Services.AddScoped<ISortHelper<Candidate>, SortHelper<Candidate>>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICandidateHistoryService, CandidateHistoryService>();
var mapperConfig = new MapperConfiguration(mc =>
{
	mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
