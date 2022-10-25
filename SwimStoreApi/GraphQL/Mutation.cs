using AutoMapper;
using SwimStoreApi.GraphQL.Brands;
using SwimStoreApi.GraphQL.Products;
using SwimStoreApi.Models;
using SwimStoreData.Data;
using SwimStoreData.Dtos;

namespace SwimStoreApi.GraphQL;

public class Mutation
{
    private readonly IMapper _mapper;

    public Mutation(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<AddProductPayload> AddProduct(AddProductInput input,
        [Service] IProductData productData)
    {
        var parameters = new
        {
            name = input.Name,
            retail_price = input.RetailPrice,
            current_price = input.CurrentPrice,
            description = input.Description,
            features = input.Features,
            sku = input.Sku,
            brand_Id = input.BrandId,
            category_Id = input.CategoryId,
            gender = input.Gender
        };

        var createdProductDto = await productData.CreateProduct<dynamic>(parameters);
        return new AddProductPayload(_mapper.Map<Product>(createdProductDto));
    }

    public async Task<UpdateProductPayload> UpdateProduct(UpdateProductInput input,
        [Service] IProductData productData)
    {
        var parameters = new
        {
            id = input.Id,
            name = input.Name,
            retail_price = input.RetailPrice,
            current_price = input.CurrentPrice,
            description = input.Description,
            features = input.Features,
            sku = input.Sku,
            brand_Id = input.BrandId,
            category_Id = input.CategoryId,
            gender = input.Gender
        };

        var updatedProductDto = await productData.UpdateProduct<dynamic>(parameters);
        return new UpdateProductPayload(_mapper.Map<Product>(updatedProductDto));
    }

    public async Task<AddBrandPayload> AddBrand([Service] IBrandData brandData ,AddBrandInput input)
    {
        var parameters = new
        {
            name = input.Name
        };
        var createBrandDto = await brandData.CreateBrand<dynamic>(parameters);
        return new AddBrandPayload(_mapper.Map<Brand>(createBrandDto));
    }
    public async Task<UpdateBrandPayload> UpdateBrand([Service] IBrandData brandData, UpdateBrandInput input)
    {
        var parameters = new
        {
            id = input.Id,
            name = input.Name
        };
        var createBrandDto = await brandData.UpdateBrand<dynamic>(parameters);
        return new UpdateBrandPayload(_mapper.Map<Brand>(createBrandDto));
    }
}
