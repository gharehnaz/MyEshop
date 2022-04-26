using _0_Framework.Domain;
using Application.Contracts.ProductPicture;
using System.Collections.Generic;

namespace Domain.ProductPicture
{
    public interface IProductPictureRepository : IRepository<long, ProductPicture>
    {
        EditProductPicture GetDetails(long id);
        ProductPicture GetWithProductAndCategory(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
    }
}
