using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;
using DrivingInstructorApi.Application;
using DrivingInstructorApi.Infrastructure;
using NSubstitute;

namespace DrivingInstructor.Tests;

public class UnitTest1
{
    [Fact]
    public async Task IntroductoryTest_WithoutAutoFixture()
    {
        // Arrange
        var someDto = new DrivingInstructorApi.Domain.DrivingInstructor
        {
            EmailAddress = "Test@Test.com",
            Name = "John Doe",
            NumberOfStudents = 10
        };
        
        var request = new CreateDrivingInstructorCommand
        {
            DrivingInstructorToAdd = someDto
        };
        var repoMock = Substitute.For<IDrivingInstructorRepository>();
        
        var sut = new CreateDrivingInstructorCommandHandler(
            repoMock
        );

        // Act
        var result = await sut.Handle(request, CancellationToken.None);

        // Assert
        Assert.Equal(10, result);
    }
    
    [Theory]
    [AutoDomainData]
    public async Task IntroductoryTest_WithAutoFixture(
        CreateDrivingInstructorCommandHandler sut, 
        DrivingInstructorApi.Domain.DrivingInstructor someDto)
    {
        // Arrange
        var request = new CreateDrivingInstructorCommand
        {
            DrivingInstructorToAdd = someDto
        };

        var fixture = new Fixture();

        //Creating a comomand with a custom email adress,that can then be 
        //asserted if required
        var mc = fixture.Build<CreateDrivingInstructorCommand>()
                .With(x => x.DrivingInstructorToAdd.EmailAddress, "CustomEmailAddress")
                .Create();

        // Act
        var result = await sut.Handle(request, CancellationToken.None);

        // Assert
        Assert.Equal(someDto.NumberOfStudents, result);
    }
}

public class AutoDomainDataAttribute : AutoDataAttribute
{
    public AutoDomainDataAttribute()
        :base(() => new Fixture().Customize(new AutoNSubstituteCustomization()))
    {
    }
}