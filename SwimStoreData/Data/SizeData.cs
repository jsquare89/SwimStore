using SwimStoreData.DataAccess;
using SwimStoreData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimStoreData.Data;
public class SizeData : ISizeData
{
    private readonly IPostgresqlDataAccess _db;

    public SizeData(IPostgresqlDataAccess db)
    {
        _db = db;
    }

    public async Task<SizeDto> CreateSize(string name, string gender)
    {
        var insertSizeQuery = "INSERT INTO size(name, gender) VALUES (@name, @gender)\n" +
                               "RETURNING *";

        var parameters = new
        {
            name = name,
            gender = gender,
        };

        var size = await _db.SaveDataWithSqlAsync<SizeDto, dynamic>(insertSizeQuery, parameters);
        return size;
    }

    public async Task<SizeDto> UpdateSize(int id, string name, string gender)
    {
        var updateSizeQuery = "UPDATE size SET name=@name, gender=@gender WHERE id = @id \n" +
                               "RETURNING *";

        var parameters = new
        {
            id = id,
            name = name,
            gender = gender,
        };

        var size = await _db.SaveDataWithSqlAsync<SizeDto, dynamic>(updateSizeQuery, parameters);
        return size;
    }


    public async Task<SizeDto?> GetSizeById(int id)
    {
        string getSizeByIdQuery = "SELECT * FROM public.size WHERE size.id = @id";
        var size = await _db.LoadDataWithSqlAsync<SizeDto, dynamic>(getSizeByIdQuery, new { id = id });
        return size.FirstOrDefault();
    }

    public async Task<IEnumerable<SizeDto>> GetSizes()
    {
        string getAllSizesQuery = "SELECT * FROM public.size ORDER BY id ASC ";
        return await _db.LoadDataWithSqlAsync<SizeDto, dynamic>(getAllSizesQuery, new { });
    }

    public async Task<IEnumerable<SizeDto>> GetSizesByIds(IReadOnlyList<int> ids)
    {
        string commaSeperatedIds = string.Join(",", ids);
        string getSizesByIds = $"SELECT id, name, gender FROM public.size where id in ({commaSeperatedIds})";
        return await _db.LoadDataWithSqlAsync<SizeDto, dynamic>(getSizesByIds, new { });
    }
}
