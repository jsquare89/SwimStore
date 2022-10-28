using AutoMapper;
using SwimStoreApi.Models;
using SwimStoreData.Data;

namespace SwimStoreApi.GraphQL.Mutations;
[ExtendObjectType(typeof(Mutation))]
public class CategoryMutation
{
	private readonly IMapper _mapper;
	private readonly ICategoryData _categoryData;

	public CategoryMutation(IMapper mapper, ICategoryData categoryData)
	{
		_mapper = mapper;
		_categoryData = categoryData;
	}
    public async Task<Category?> AddCategory(string name, bool accessory)
    {
        var createCategoryDto = await _categoryData.CreateCategory(name, accessory);
        return _mapper.Map<Category>(createCategoryDto);
    }

    public async Task<Category?> UpdateCategory(int id, string name, bool accessory)
    {
        var updateCategoryDto = await _categoryData.UpdateCategory(id, name, accessory);
        return _mapper.Map<Category>(updateCategoryDto);
    }

}
