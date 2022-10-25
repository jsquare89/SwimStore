using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimStoreData.Dtos;
public class CategoryDto
{
    public int id { get; set; }
    public string? Name { get; set; }
    public bool Accessory { get; set; }
}
