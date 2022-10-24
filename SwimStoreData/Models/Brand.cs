using System.ComponentModel.DataAnnotations;


namespace SwimStoreData.Models;
internal class Brand
{
    [Key]
    public Int32 id { get; set; }
    [Required]
    public string? Name { get; set; }
    //public string? LogoUrl { get; set; }
}
