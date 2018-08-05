using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace Wineventory.Functions
{
    public class InventoryWine : TableEntity
    {
        public InventoryWine()
        {
        }

        public InventoryWine(string vinmonopoletId, string name)
        {
            RowKey = Guid.NewGuid().ToString();
            PartitionKey = "wine";

            Name = name;
            VinmonopoletId = vinmonopoletId;
            AddedAt = DateTime.Now;
        }

        public string VinmonopoletId { get; set; }
        public string Name { get; set; }
        public DateTime AddedAt { get; set; }
    }
}