using AutoMapper;
using SwimStoreApi.Models;
using SwimStoreData.Data;

namespace SwimStoreApi.GraphQL.Queries;

[ExtendObjectType(typeof(Query))]
public class CategoryQuery
{
    private readonly IMapper _mapper;

    public CategoryQuery(IMapper mapper)
	{
        _mapper = mapper;
    }

    [UseFiltering]
    public async Task<IEnumerable<Category>> GetCategories([Service] ICategoryData categoryData)
    {
        var categories = await categoryData.GetCategories();
        return _mapper.Map<IEnumerable<Category>>(categories);
    }

    [UseFiltering]
    public async Task<Category?> GetCategoryById(int id, [Service] ICategoryData categoryData)
    {
        var category = await categoryData.GetCategoryById(id);
        return _mapper.Map<Category>(category);
    }
}
