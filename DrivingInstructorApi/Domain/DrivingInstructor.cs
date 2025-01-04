namespace DrivingInstructorApi.Domain;

public class DrivingInstructor
{
    public required string Name{get;set;}
    public required string EmailAddress { get; set; }
    public int NumberOfStudents { get; set; }
}