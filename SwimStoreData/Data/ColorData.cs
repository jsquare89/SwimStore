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

    public async Task<ColorDto> CreateColor(string name)
    {
        var insertColorQuery = "INSERT INTO color(name) VALUES (@name)\n" +
                               "RETURNING *";

        var parameters = new
        {
            name = name,
        };

        var color = await _db.SaveDataWithSqlAsync<ColorDto, dynamic>(insertColorQuery, parameters);
        return color;
    }

    public async Task<ColorDto> UpdateColor(int id, string name)
    {
        var updateColorQuery = "UPDATE color SET name=@name WHERE id = @id \n" +
                               "RETURNING *";

        var parameters = new
        {
            id = id,
            name = name
        };

        var color = await _db.SaveDataWithSqlAsync<ColorDto, dynamic>(updateColorQuery, parameters);
        return color;
    }

    public async Task<ColorDto?> GetColorById(int id)
    {
        string getColorByIdQuery = "SELECT * FROM public.color WHERE color.id = @id";
        var color = await _db.LoadDataWithSqlAsync<ColorDto, dynamic>(getColorByIdQuery, new { id = id });
        return color.FirstOrDefault();
    }

    public async Task<IEnumerable<ColorDto>> GetColors()
    {
        string getAllColorsQuery = "SELECT * FROM public.color ORDER BY id ASC ";
        return await _db.LoadDataWithSqlAsync<ColorDto, dynamic>(getAllColorsQuery, new { });
    }

    public async Task<IEnumerable<ColorDto>> GetColorsByIds(IReadOnlyList<int> ids)
    {
        string commaSeperatedIds = string.Join(",", ids);
        string getColorsByIds = $"SELECT id, name FROM public.color where id in ({commaSeperatedIds})";
        return await _db.LoadDataWithSqlAsync<ColorDto, dynamic>(getColorsByIds, new { });
    }

}
