using NetArchTest.Rules;
// https://youtu.be/_D6Kai4RdGY

namespace ArchitectureTests;

public class ArchitectureTests
{
    private const string DomainNameSpace = "BuberDinner.Domain";
    private const string ApplicationNameSpace = "BuberDinner.Application";
    private const string PresentationNameSpace = "BuberDinner.Api";
    private const string InfrastructureNameSpace = "BuberDinner.Infrastructure";
    private const string ContractsNameSpace = "BuberDinner.Contracts";

    [Fact]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(BuberDinner.Domain.Common.Models.ValueObject).Assembly;

        var otherProjects = new[]
        {
            ApplicationNameSpace,
            PresentationNameSpace,
            InfrastructureNameSpace,
            ContractsNameSpace
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        // testResult.IsSuccessful.Should().Betrue();
        Assert.True(testResult.IsSuccessful);
    }

    [Fact]
    public void Application_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(BuberDinner.Application.DependencyInjection).Assembly;

        var otherProjects = new[]
        {
            PresentationNameSpace,
            InfrastructureNameSpace,
            ContractsNameSpace
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        // testResult.IsSuccessful.Should().Betrue();
        Assert.True(testResult.IsSuccessful);
    }

    [Fact]
    public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(BuberDinner.Infrastructure.DependencyInjection).Assembly;

        var otherProjects = new[]
        {
            PresentationNameSpace,
            ContractsNameSpace
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        // testResult.IsSuccessful.Should().Betrue();
        Assert.True(testResult.IsSuccessful);
    }

   /* [Fact]  //dépendance dans program.cs (AddInfrastructure)
    public void Presentation_Should_Not_HaveDependencyOnOtherProjects()
     {
         // Arrange
         var assembly = typeof(BuberDinner.Api.DependencyInjection).Assembly;

         var otherProjects = new[]
         {
             InfrastructureNameSpace
         };

         // Act
         var testResult = Types
             .InAssembly(assembly)
             .ShouldNot()
             .HaveDependencyOnAny(otherProjects)
             .GetResult();

         // Assert
         Assert.True(testResult.IsSuccessful);
     }
*/
    [Fact] 
    public void Handlers_Sould_Have_DependencyOnDomain()
     {
         // Arrange
         var assembly = typeof(BuberDinner.Application.DependencyInjection).Assembly;

         // Act
         var testResult = Types
             .InAssembly(assembly)
             .That()
             .HaveNameEndingWith("Handler") 
             .Should()
             .HaveDependencyOn(DomainNameSpace)
             .GetResult();

         // Assert
         // testResult.IsSuccessful.Should().Betrue();
         Assert.True(testResult.IsSuccessful);
     }

    [Fact]
    public void Controllers_Should_HaveDependencyOnMediatR()
    {
        // Arrange
        var assembly = typeof(BuberDinner.Api.DependencyInjection).Assembly;

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .That()
            .HaveNameEndingWith("Controller") // marche pas....
            .And()
            .DoNotHaveNameMatching("ApiController")
            .And()
            .DoNotHaveNameMatching("ErrorsController")
            .Should()
            .HaveDependencyOn("MediatR")
            .GetResult();

        // Assert
        Assert.True(testResult.IsSuccessful);
    }
}