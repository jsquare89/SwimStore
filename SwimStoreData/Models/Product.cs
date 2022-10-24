using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SwimStoreData.Models;
public class Product
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }

    [Column("original_price")]
    public int OriginalPrice { get; set; }
    [Column("current_price")]
    public int CurrentPrice { get; set; }
    [Column("quantity_in_stock")]
    [Required]
    public int QuantityInStock { get; set; }
    public Guid BrandId { get; set; }
    public string? Gender { get; set; }

}
