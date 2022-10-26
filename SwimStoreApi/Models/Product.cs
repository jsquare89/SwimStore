using SwimStoreData.Dtos;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SwimStoreApi.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [Column("retail_price")]
    public int RetailPrice { get; set; }
    [Column("current_price")]
    public int CurrentPrice { get; set; }
    [MaxLength(2000)]
    public string? Description { get; set; }
    [MaxLength(2000)]
    public string? Features { get; set; }
    [MaxLength(20)]
    public string? Sku { get; set; }
    [MaxLength(1)]
    public string? Gender { get; set; }
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
}
