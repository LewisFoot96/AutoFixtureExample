using DrivingInstructorApi.Application;
using DrivingInstructorApi.Domain;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(Program).Assembly); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/drivinginstructor", async (IMediator mediator) =>
    {
        var drivingInstructor = new DrivingInstructor
        {
            EmailAddress = "test@hotmail.com",
            Name = "John Doe",
            NumberOfStudents = 10
        };

        var drivingInstructorNum = await mediator.Send(new CreateDrivingInstructorCommand
        {
            DrivingInstructorToAdd = drivingInstructor
        });
        return drivingInstructor;
    })
    .WithName("GetDrivingInstructor");

app.Run();