using Database;
using Wineventory.Domain;
using Wineventory.Domain.Decorators;
using Wineventory.Domain.Utils;
using Wineventory.Logic.Vinmonopolet.Dtos;

namespace Wineventory.Logic.Vinmonopolet
{
    public class ProductSearchQuery : IQuery<ProductsSearchResultDto>
    {
        public ProductSearchQuery(string vinmonopoletId)
        {
            VinmonopoletId = vinmonopoletId;
        }

        public string VinmonopoletId { get; set; }
    }

    public class ProductSearchQueryHandler : IQueryHandler<ProductSearchQuery, ProductsSearchResultDto>
    {
        private WineContext _db;

        public ProductSearchQueryHandler(WineContext context)
        {
            _db = context;
        }
        public ProductsSearchResultDto Handle(ProductSearchQuery query)
        {
            var result = _db.Find<SearchableProduct>(query.VinmonopoletId);
            if (result != null)
            {
                return new ProductsSearchResultDto
                {
                    VinmonopoletId = result.Id,
                    Name = result.Name,
                    Vintage = result.Vintage,
                    Producer = result.Producer,
                    Fruit = result.Fruit,
                    Price = result.Price,
                    Country = result.Country,
                    ProductType = result.ProductType
                };
            }
            return null;
        }
    }
}