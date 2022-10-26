using SwimStoreData.DataAccess;
using SwimStoreData.Dtos;

namespace SwimStoreData.Data;
public class ColorData : IColorData
{
    private readonly IPostgresqlDataAccess _db;

    public ColorData(IPostgresqlDataAccess db)
    {
        _db = db;
    }

    public async Task<ColorDto?> GetColorById(int id)
    {
        string getColorByIdQuery = "SELECT * FROM public.color WHERE color.id = @id";
        var color = await _db.LoadDataWithSqlAsync<ColorDto, dynamic>(getColorByIdQuery, new { id = id });
        return color.FirstOrDefault();
    }

    public Task<IEnumerable<ColorDto>> GetColors()
    {
        string getAllColorsQuery = "SELECT * FROM public.color ORDER BY id ASC ";
        return _db.LoadDataWithSqlAsync<ColorDto, dynamic>(getAllColorsQuery, new { });
    }

    public Task<IEnumerable<ColorDto>> GetColorsByIds(IReadOnlyList<int> ids)
    {
        string commaSeperatedIds = string.Join(",", ids);
        string getColorsByIds = $"SELECT id, name FROM public.color where id in ({commaSeperatedIds})";
        return _db.LoadDataWithSqlAsync<ColorDto, dynamic>(getColorsByIds, new { });
    }

}
