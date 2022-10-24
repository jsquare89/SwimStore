﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwimStoreData.Models;
public class ProductModel
{
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
    public Int32 BrandId { get; set; }
    public Int32 TypeId { get; set; }
    [MaxLength(1)]
    public string? Gender { get; set; }
}
