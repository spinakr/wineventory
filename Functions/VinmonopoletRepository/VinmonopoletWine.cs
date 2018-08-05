using Microsoft.WindowsAzure.Storage.Table;

namespace Functions.VinmonopoletRepository
{
    public class VinmonopoletWine : TableEntity
    {
        public VinmonopoletWine()
        {
        }

        public VinmonopoletWine(string vinmonopoletId)
        {
            RowKey = vinmonopoletId;
            PartitionKey = "Wine";
        }

        public string Name { get; set; }
        public string Fruit { get; set; }
        public string Vintage { get; set; }
    }
}