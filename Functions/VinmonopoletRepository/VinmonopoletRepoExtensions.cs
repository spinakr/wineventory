
using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace Functions.VinmonopoletRepository
{
    public static class VinmonopoletRepoExtensions
    {
        public static async Task<VinmonopoletWine> SearchWine(this CloudTable vinmonopoletRepo, string vinmonopoletId)
        {
            var result = await vinmonopoletRepo.ExecuteAsync(
                TableOperation.Retrieve<VinmonopoletWine>("Wine", vinmonopoletId));

            if (result == null) return null;

            return (VinmonopoletWine)result.Result;
        }
    }
}


