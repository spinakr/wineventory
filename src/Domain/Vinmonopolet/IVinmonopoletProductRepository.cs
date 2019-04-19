using System.Collections.Generic;
using System.Threading.Tasks;
using Wineventory.Domain;

namespace Wineventory.Domain.Vinmonopolet
{
    public interface IVinmonopoletProductRepository
    {
        Task<SearchableProduct> Find(string vinmonopoletId);
        Task Store(SearchableProduct product);
        Task Store(IEnumerable<SearchableProduct> products);
    }
}