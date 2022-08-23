using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimStoreData.Models;
public class ProductModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    [Column("original_price")]
    public int OriginalPrice { get; set; }
    [Column("current_price")]
    public int CurrentPrice { get; set; }
    [Column("quantity_in_stock")]
    public int QuantityInStock { get; set; }
    public string Brand { get; set; }
    public string Gender { get; set; }

}
