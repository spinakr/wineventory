using System;
using System.Linq;
using Marten;
using Marten.Events;
using Wineventory.Domain.Decorators;
using Wineventory.Domain.Inventory;
using Wineventory.Domain.Utils;
using Wineventory.Domain.ValueObjects;

namespace Wineventory.Logic.Inventory
{
    public class AddBottleToInventoryCommand : ICommand
    {
        public string VinmonopoletId { get; set; }
        public string Producer { get; set; }
        public string Name { get; set; }
        public string Fruit { get; set; }
        public string Country { get; set; }
        public string Vintage { get; set; }
        public double Price { get; set; }
        public string ProductType { get; set; }

        public AddBottleToInventoryCommand(string vinmonopoletId, string producer, string name, string fruit, string country, string vintage, double price, string productType)
        {
            VinmonopoletId = vinmonopoletId;
            Producer = producer;
            Name = name;
            Fruit = fruit;
            Country = country;
            Vintage = vintage;
            Price = price;
            ProductType = productType;
        }
    }

    [Logging]
    public class AddBottleToInventoryCommandHandler : ICommandHandler<AddBottleToInventoryCommand>
    {
        private IEventStore _store => _session.Events;
        private readonly IDocumentSession _session;

        public AddBottleToInventoryCommandHandler(IDocumentSession session)
        {
            _session = session;
        }

        public Result Handle(AddBottleToInventoryCommand command)
        {
            var wine = _store.AggregateStream<InventoryWine>(command.VinmonopoletId);
            if (wine?.Bottles == null || !wine.Bottles.Any())
            {
                wine = new InventoryWine(command.VinmonopoletId, command.Producer, command.Name, command.ProductType, command.Fruit, command.Country, command.Vintage, (int)command.Price);
            }
            else
            {
                wine.AddBottle(command.Vintage, (int)command.Price);
            }
            _store.Append(wine.Id, wine.PendingEvents.ToArray());
            _session.SaveChanges();
            return Result.Success;
        }
    }
}