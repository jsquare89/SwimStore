using AutoMapper;
using SwimStoreApi.GraphQL.Brands;
using SwimStoreApi.GraphQL.Categories;
using SwimStoreApi.GraphQL.Colors;
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

    public async Task<AddCategoryPayload> AddCategory([Service] ICategoryData categoryData, AddCategoryInput input)
    {
        var parameters = new
        {
            name = input.Name,
            accessory = input.Accessory
        };
        var createCategoryDto = await categoryData.CreateCategory<dynamic>(parameters);
        return new AddCategoryPayload(_mapper.Map<Category>(createCategoryDto));
    }

    public async Task<UpdateCategoryPayload> UpdateCategory([Service] ICategoryData categoryData, UpdateCategoryInput input)
    {
        var parameters = new
        {
            id = input.Id,
            name = input.Name,
            accessory = input.Accessory
        };
        var updateCategoryDto = await categoryData.UpdateCategory<dynamic>(parameters);
        return new UpdateCategoryPayload(_mapper.Map<Category>(updateCategoryDto));
    }

    public async Task<AddColorPayload> AddColor([Service] IColorData colorData, AddColorInput input)
    {
        var parameters = new
        {
            name = input.Name
        };
        var createColorDto = await colorData.CreateColor<dynamic>(parameters);
        return new AddColorPayload(_mapper.Map<Color>(createColorDto));
    }

    public async Task<UpdateColorPayload> UpdateColor([Service] IColorData colorData, UpdateColorInput input)
    {
        var parameters = new
        {
            id = input.Id,
            name = input.Name
        };
        var createColorDto = await colorData.UpdateColor<dynamic>(parameters);
        return new UpdateColorPayload(_mapper.Map<Color>(createColorDto));
    }
}
