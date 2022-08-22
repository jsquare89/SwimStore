using SwimStoreData.DataAccess;
using SwimStoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimStoreData.Data;

public class ProductData : IProductData
{
	private readonly IPostgresqlDataAccess _db;

	public ProductData(IPostgresqlDataAccess db)
	{
		_db = db;
	}

	public Task<IEnumerable<ProductModel>> GetProducts() =>
		_db.LoadData<ProductModel, dynamic>("sf_product_get_all", new { });
}
