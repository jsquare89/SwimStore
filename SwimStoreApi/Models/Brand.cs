using System.ComponentModel.DataAnnotations.Schema;

namespace SwimStoreApi.Models;

public class Brand
{
    public Int32 Id { get; set; }
    public string? Name { get; set; }
    //public string? LogoUrl { get; set; }
}
