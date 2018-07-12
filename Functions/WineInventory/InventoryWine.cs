using Microsoft.WindowsAzure.Storage.Table;

namespace Wineventory.Functions
{
    public class InventoryWine : TableEntity
    {
        public string VinmonopoletId { get; set; }
        public string Name { get; set; }   
    }
}