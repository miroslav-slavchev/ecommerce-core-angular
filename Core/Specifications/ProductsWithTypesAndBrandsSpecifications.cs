using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecifications : BaseSpecification<Product>
    {
      public ProductsWithTypesAndBrandsSpecifications(ProductSpecParams productSpecParams) 
      : base (x => 
            (!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId) && 
            (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId))
      {
          AddInclude(x => x.ProductType);
          AddInclude(x => x.ProductBrand);
          AddOrderBy(x => x.Name);
          ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex -1), productSpecParams.PageSize);
          if(string.IsNullOrEmpty(productSpecParams.Sort) == false)
          {
              switch (productSpecParams.Sort)
              {
                  case "priceAsc": AddOrderBy(p=>p.Price);break;
                  case "priceDesc": AddOrderByDescending(p=>p.Price);break;
                  default: AddOrderBy(p => p.Name);break;
              }
          }
      }

      public ProductsWithTypesAndBrandsSpecifications(int id) : base (x => x.Id == id)
      {
          AddInclude(x => x.ProductType);
          AddInclude(x => x.ProductBrand);
      }
    }
}