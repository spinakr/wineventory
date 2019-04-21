using System;
using Marten;
using Marten.Events;
using Wineventory.Domain.Decorators;
using Wineventory.Domain.Inventory;
using Wineventory.Domain.Utils;
using Wineventory.Domain.ValueObjects;

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
        private IEventStore _store => _session.Events;
        private readonly IDocumentSession _session;

        public AddWineToInventoryCommandHandler(IDocumentSession session)
        {
            _session = session;
        }

        public Result Handle(AddWineToInventoryCommand command)
        {
            var wine = _store.AggregateStream<InventoryWine>(command.Wine.VinmonopoletId);
            if (wine.Name == null)
            {
                // Enum.TryParse(command.Wine.Country, out Country country);
                // wine = new InventoryWine(command.Wine.VinmonopoletId, command.Wine.Producer, command.Wine.Name, Fruit.Parse(command.Wine.Fruit), country);
                wine = new InventoryWine(command.Wine.VinmonopoletId, command.Wine.Producer, command.Wine.Name, command.Wine.ProductType, command.Wine.Fruit, command.Wine.Country);
            }
            else
            {

            }

            _store.Append(wine.Id, wine.PendingEvents.ToArray());
            _session.SaveChanges();
            return Result.Success;
        }
    }
}