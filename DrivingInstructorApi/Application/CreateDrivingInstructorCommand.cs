using DrivingInstructorApi.Domain;
using MediatR;

namespace DrivingInstructorApi.Application;

public class CreateDrivingInstructorCommand : IRequest<int>
{
    public DrivingInstructor DrivingInstructorToAdd { get; set; }
}