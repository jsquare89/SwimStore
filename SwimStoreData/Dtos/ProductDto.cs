using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SwimStoreData.Dtos;
public class ProductDto
{
    public Int32 Id { get; set; }
    public string? Name { get; set; }
    [Column("retail_price")]
    public Int32 RetailPrice { get; set; }
    [Column("current_price")]
    public Int32 CurrentPrice { get; set; }
    [MaxLength(2000)]
    public string? Description { get; set; }
    [MaxLength(2000)]
    public string? Features { get; set; }
    [MaxLength(20)]
    public string? Sku { get; set; }
    [Column("brand_id")]
    public Int32 BrandId { get; set; }
    [Column("category_id")]
    public Int32 CategoryId { get; set; }
    [MaxLength(1)]
    public string? Gender { get; set; }

    public BrandDto? Brand { get; set; }
}
