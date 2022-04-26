using _0_Framework.Domain;
using Application.Contracts.Product;
using System.Collections.Generic;

namespace Domain.Product
{
    public interface IProductRepository : IRepository<long,Product>
    {
        EditProduct GetDetails(long id);
        Product GetProductWithCategory(long id);
        List<ProductViewModel> GetProducts();
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
