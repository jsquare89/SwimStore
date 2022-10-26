using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimStoreData.Dtos;
public class ProductStockDto
{
    [Column("product_id")]
    public int ProductId { get; set; }
    [Column("size_id")]
    public int SizeId { get; set; }
    [Column("color_id")]
    public int ColorId { get; set; }
    public int Quantity { get; set; }
}
