using AutoMapper;
using HotChocolate.AspNetCore.Authorization;
using SwimStoreApi.Models;
using SwimStoreData.Data;
using System.Runtime.CompilerServices;

namespace SwimStoreApi.GraphQL.Mutations;

[ExtendObjectType(typeof(Mutation))]
public class BrandMutation
{
	private readonly IMapper _mapper;
	private readonly IBrandData _brandData;

	public BrandMutation(IMapper mapper, IBrandData brandData)
	{
		_mapper = mapper;
		_brandData = brandData;
	}

    public async Task<Brand?> AddBrandAsync(string name)
    {
        var createBrandDto = await _brandData.CreateBrand(name);
        return _mapper.Map<Brand>(createBrandDto);
    }
    public async Task<Brand?> UpdateBrandAsync(int id, string name)
    {
        var createBrandDto = await _brandData.UpdateBrand(id, name);
        return _mapper.Map<Brand>(createBrandDto);
    }
}
