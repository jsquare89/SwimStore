using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SwimStoreData.Migrations;
[Migration(20221023001)]
public class InitialTables_20221023001 : Migration
{
    public override void Down()
    {
        Delete.Table("product");
        Delete.Table("brand");
        Delete.Table("category");
    }

    public override void Up()
    {
        Create.Table("brand")
            .WithColumn("id").AsInt32().NotNullable().Identity().PrimaryKey()
            .WithColumn("name").AsString(50).NotNullable();

        Create.Table("category")
            .WithColumn("id").AsInt32().NotNullable().Identity().PrimaryKey()
            .WithColumn("name").AsString(50).NotNullable()
            .WithColumn("accessory").AsBoolean().WithDefaultValue(false).NotNullable();

        Create.Table("product")
            .WithColumn("id").AsInt32().NotNullable().Identity().PrimaryKey()
            .WithColumn("name").AsString(70).NotNullable()
            .WithColumn("retail_price").AsInt32().NotNullable()
            .WithColumn("current_price").AsInt32().NotNullable()
            .WithColumn("description").AsString(2000).NotNullable()
            .WithColumn("features").AsString(2000).NotNullable()
            .WithColumn("sku").AsString(20).NotNullable()
            .WithColumn("brand_id").AsInt32().NotNullable().ForeignKey("brand", "id")
            .WithColumn("category_id").AsInt32().NotNullable().ForeignKey("category", "id")
            .WithColumn("gender").AsString(1).NotNullable();

        //Create.Table("Color")
        //   .WithColumn("id").AsGuid().NotNullable().Identity().PrimaryKey()
        //   .WithColumn("name").AsString(50).NotNullable();

        // TODO: Tables to create
        // Stock -> product_id, size_id, color_id, qty_in_stock (compound primary key)
        // Size -> id, size, gender
        // Color -> id, color
        // ProductImages -> product_id, image_id
        // Image -> image_id, url
    }
}
