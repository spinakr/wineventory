using System;
using Wineventory.Domain.Utils;

namespace Wineventory.Domain.Inventory.Messages
{
    public class AddWineToInventoryCommand : ICommand
    {

    }

    public class AddWineToInventoryCommandHandler : ICommandHandler<AddWineToInventoryCommand>
    {
        public AddWineToInventoryCommandHandler()
        {

        }
        public Result Handle(AddWineToInventoryCommand command)
        {
            Console.WriteLine("Command handled!");
            return Result.Success;
        }
    }
}