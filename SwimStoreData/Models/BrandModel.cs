using System.ComponentModel.DataAnnotations;


namespace SwimStoreData.Models;
internal class BrandModel
{
    [Key]
    public Guid id { get; set; }
    [Required]
    public string? Name { get; set; }
    public string? LogoUrl { get; set; }
}
