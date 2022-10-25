using AutoMapper;
using SwimStoreApi.Models;

namespace SwimStoreApi.MapperProfiles;

public class SwimStoreProfiles : Profile
{
	public SwimStoreProfiles()
	{
		// Source -> 
		CreateMap<SwimStoreData.Dtos.ProductDto, Product>();
		CreateMap<SwimStoreData.Dtos.BrandDto, Brand>();
		CreateMap<SwimStoreData.Dtos.CategoryDto, Category>();
	}
}
