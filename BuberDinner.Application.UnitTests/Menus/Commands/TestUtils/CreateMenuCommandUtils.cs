using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using System.Linq;

namespace BuberDinner.Application.UnitTests.Menus.Commands.TestUtils;

public static class CreateMenuCommandUtils
{
    public static CreateMenuCommand CreateCommand(List<CreateMenuSectionCommand>? sections = null) => new (Constants.Host.Id.ToString(),
                                                                Constants.Menu.Name,
                                                                Constants.Menu.Description,
                                                                sections ?? CreateSectionsCommand());
    public static List<CreateMenuSectionCommand> CreateSectionsCommand(int sectionCount = 1, List<CreateMenuItemCommand>? items = null)
    {
        return Enumerable.Range(0, sectionCount)
            .Select(index => new CreateMenuSectionCommand(
                Constants.Menu.SectionNameFromIndex(index),
                Constants.Menu.SectionDescriptionFromIndex(index),
                items ?? CreateItemsCommand()))
            .ToList();
    }

    public static List<CreateMenuItemCommand> CreateItemsCommand(int itemCount = 1)
    {
        return Enumerable.Range(0, itemCount)
            .Select(index => new CreateMenuItemCommand(
                Constants.Menu.SectionNameFromIndex(index),
                Constants.Menu.SectionDescriptionFromIndex(index)))
            .ToList();
    }
}
