﻿using MyFramework.Domain;
using ShopManagement.Contracts.ProductPicture;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository : IRepository<long, ProductPictureModel>
    {
        EditProductPicture GetDetails(long id);
        List<ProductPictureViewModel> Search(ProducPictureSearchModel searchModel);

    }
}