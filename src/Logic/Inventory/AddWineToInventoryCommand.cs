using System;
using Wineventory.Domain.Decorators;
using Wineventory.Domain.Utils;

namespace Wineventory.Logic.Inventory
{
    public class AddWineToInventoryCommand : ICommand
    {
        public InventoryWineDto Wine;

        public AddWineToInventoryCommand(InventoryWineDto wine)
        {
            Wine = wine;
        }
    }

    [Logging]
    public class AddWineToInventoryCommandHandler : ICommandHandler<AddWineToInventoryCommand>
    {
        public AddWineToInventoryCommandHandler()
        {

        }

        public Result Handle(AddWineToInventoryCommand command)
        {
            return Result.Success;
        }
    }
}