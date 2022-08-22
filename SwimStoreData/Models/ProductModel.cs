using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimStoreData.Models;
public class ProductModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int OriginalPrice { get; set; }
    public int CurrentPrice { get; set; }
    public int QuantityInStock { get; set; }
    public string Brand { get; set; }
    public string Gender { get; set; }

}
