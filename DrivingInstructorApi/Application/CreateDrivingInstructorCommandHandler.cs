using DrivingInstructorApi.Infrastructure;
using MediatR;

namespace DrivingInstructorApi.Application;

public class CreateDrivingInstructorCommandHandler : IRequestHandler<CreateDrivingInstructorCommand, int>
{
    private readonly IDrivingInstructorRepository _drivingInstructorRepository;

    public CreateDrivingInstructorCommandHandler(IDrivingInstructorRepository drivingInstructorRepository)
    {
        _drivingInstructorRepository = drivingInstructorRepository;
    }

    public async Task<int> Handle(CreateDrivingInstructorCommand request, CancellationToken cancellationToken)
    {
        await _drivingInstructorRepository.AddDrivingInstructor(request.DrivingInstructorToAdd);
        return request.DrivingInstructorToAdd.NumberOfStudents;
    }
}