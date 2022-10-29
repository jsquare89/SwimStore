using AutoMapper;
using HotChocolate.AspNetCore.Authorization;
using SwimStoreApi.Models;
using SwimStoreData.Data;

namespace SwimStoreApi.GraphQL.Queries;

[ExtendObjectType(typeof(Query))]
public class BrandQuery
{
    private readonly IMapper _mapper;

    public BrandQuery(IMapper mapper)
    {
        _mapper = mapper;
    }

    [UseFiltering]
    public async Task<IEnumerable<Brand>> GetBrands([Service] IBrandData brandData)
    {
        var brands = await brandData.GetBrands();
        return _mapper.Map<IEnumerable<Brand>>(brands);
    }

    [UseFiltering]
    public async Task<Brand?> GetBrandById(int id, [Service] IBrandData brandData)
    {
        var brand = await brandData.GetBrandById(id);
        return _mapper.Map<Brand>(brand);
    }
}
