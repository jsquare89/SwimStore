using AutoMapper;
using SwimStoreApi.GraphQL.Brands;
using SwimStoreApi.GraphQL.Categories;
using SwimStoreApi.GraphQL.Colors;
using SwimStoreApi.GraphQL.Products;
using SwimStoreApi.GraphQL.ProductStocks;
using SwimStoreApi.GraphQL.Sizes;
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
        var createdProductDto = await productData.CreateProduct(input.Name, input.RetailPrice,
            input.CurrentPrice,input.Description,input.Features,input.Sku,
            input.BrandId,input.CategoryId,input.Gender);

        return new AddProductPayload(_mapper.Map<Product>(createdProductDto));
    }

    public async Task<AddProductStockPayload> AddProductStock(AddProductStockInput input,
        [Service] IProductStockData productStockData)
    {
        var productStockDto = await productStockData.UpdateProductStock(input.ProductId,
            input.SizeId, input.ColorId, input.Quantity);

        return new AddProductStockPayload(_mapper.Map<ProductStock>(productStockDto));
    }

    public async Task<UpdateProductStockPayload> UpdateProductStockQuantity(UpdateProductStockInput input,
        [Service] IProductStockData productStockData)
    {
        var productStockDto = await productStockData.UpdateProductStockQuantity(input.ProductId,
            input.SizeId, input.ColorId, input.Quantity);

        return new UpdateProductStockPayload(_mapper.Map<ProductStock>(productStockDto));
    }

    public async Task<UpdateProductPayload> UpdateProduct(UpdateProductInput input,
        [Service] IProductData productData)
    {
        var updatedProductDto = await productData.UpdateProduct(input.Id,input.Name, input.RetailPrice,
            input.CurrentPrice, input.Description, input.Features, input.Sku,
            input.BrandId, input.CategoryId, input.Gender);

        return new UpdateProductPayload(_mapper.Map<Product>(updatedProductDto));
    }

    public async Task<AddBrandPayload> AddBrand([Service] IBrandData brandData ,AddBrandInput input)
    {
        var createBrandDto = await brandData.CreateBrand(input.Name);
        return new AddBrandPayload(_mapper.Map<Brand>(createBrandDto));
    }
    public async Task<UpdateBrandPayload> UpdateBrand([Service] IBrandData brandData, UpdateBrandInput input)
    {
        var createBrandDto = await brandData.UpdateBrand(input.Id, input.Name);
        return new UpdateBrandPayload(_mapper.Map<Brand>(createBrandDto));
    }

    public async Task<AddCategoryPayload> AddCategory([Service] ICategoryData categoryData, AddCategoryInput input)
    {
        var createCategoryDto = await categoryData.CreateCategory(input.Name,input.Accessory);
        return new AddCategoryPayload(_mapper.Map<Category>(createCategoryDto));
    }

    public async Task<UpdateCategoryPayload> UpdateCategory([Service] ICategoryData categoryData, UpdateCategoryInput input)
    {
        var updateCategoryDto = await categoryData.UpdateCategory(input.Id, input.Name, input.Accessory);
        return new UpdateCategoryPayload(_mapper.Map<Category>(updateCategoryDto));
    }

    public async Task<AddColorPayload> AddColor([Service] IColorData colorData, AddColorInput input)
    {
        var createColorDto = await colorData.CreateColor(input.Name);
        return new AddColorPayload(_mapper.Map<Color>(createColorDto));
    }

    public async Task<UpdateColorPayload> UpdateColor([Service] IColorData colorData, UpdateColorInput input)
    {
        var updateColorDto = await colorData.UpdateColor(input.Id, input.Name);
        return new UpdateColorPayload(_mapper.Map<Color>(updateColorDto));
    }

    public async Task<AddSizePayload> AddSize([Service] ISizeData sizeData, AddSizeInput input)
    {
        var createSizeDto = await sizeData.CreateSize(input.Name,input.Gender);
        return new AddSizePayload(_mapper.Map<Size>(createSizeDto));
    }

    public async Task<UpdateSizePayload> UpdateSize([Service] ISizeData sizeData, UpdateSizeInput input)
    {
        var createSizeDtos = await sizeData.UpdateSize(input.Id, input.Name, input.Gender);
        return new UpdateSizePayload(_mapper.Map<Size>(createSizeDtos));
    }
}
