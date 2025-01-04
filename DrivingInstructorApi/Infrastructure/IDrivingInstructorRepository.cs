using DrivingInstructorApi.Domain;

namespace DrivingInstructorApi.Infrastructure;

public interface IDrivingInstructorRepository
{
    public Task AddDrivingInstructor(DrivingInstructor drivingInstructor);
}