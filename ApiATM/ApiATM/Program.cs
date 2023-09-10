using ApiATM.Data;
using ApiATM.Mapper;
using ApiATM.Repository;
using ApiATM.Repository.IRepository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add repository
builder.Services.AddScoped<IUserCardRepository, UserCardRepository>();
builder.Services.AddScoped<IUserOperationRepository, UserOperationRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConectionSql"));
});

//Add AutoMapper
builder.Services.AddAutoMapper(typeof(ATMMapper));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
