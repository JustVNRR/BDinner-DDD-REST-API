using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.UnitTests.Menus.Commands.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Menus.Extensions;
using FluentAssertions;
using Moq;
using System.Runtime.InteropServices.ObjectiveC;

namespace BuberDinner.Application.UnitTests.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandlerTests
{
    private readonly CreateMenuCommandHandler _handler;
    private readonly Mock<IMenuRepository> _mockMenuRepository;

    public CreateMenuCommandHandlerTests()
    {
        _mockMenuRepository = new Mock<IMenuRepository>();
        _handler = new CreateMenuCommandHandler((IMenuRepository)_mockMenuRepository);
    }

    [Theory]
    [MemberData(nameof(ValidCreateMenuCommands))]
    public async Task HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateAndReturnMenu(CreateMenuCommand createMenuCommand)
    {
        // Arrange
        // Get hold of a valid Menu
        // var createMenuCommand = CreateMenuCommandUtils.CreateCommand();
        // Act
        // Invoke the handler

        var result = await _handler.Handle(createMenuCommand, default);

        // Assert
        // 1. Validate correct menu created
        result.IsError.Should().BeFalse();

        // 2. Menu added to repository
        result.Value.ValidateCreatedFrom(createMenuCommand);
        _mockMenuRepository.Verify(m => m.AddAsync(result.Value), Times.Once);
    }

    public static IEnumerable<object[]> ValidCreateMenuCommands()
    {
        yield return new[] { CreateMenuCommandUtils.CreateCommand() };
        yield return new[] {
            CreateMenuCommandUtils.CreateCommand(
            sections:CreateMenuCommandUtils.CreateSectionsCommand(sectionCount:3, items:CreateMenuCommandUtils.CreateItemsCommand(itemCount:1))),
        };
    }
}
