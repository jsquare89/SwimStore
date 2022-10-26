using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimStoreData.Migrations;
[Migration(20221025001)]
public class ProductStockTables_20221025001 : Migration
{
    public override void Down()
    {
        Delete.Table("product_stock");
        Delete.Table("size");
        Delete.Table("color");
    }

    public override void Up()
    {
        Create.Table("size")
            .WithColumn("id").AsInt32().NotNullable().Identity().PrimaryKey()
            .WithColumn("name").AsString(20).NotNullable()
            .WithColumn("gender").AsString(1).NotNullable();

        Create.Table("color")
            .WithColumn("id").AsInt32().NotNullable().Identity().PrimaryKey()
            .WithColumn("name").AsString(20).NotNullable();

        Create.Table("product_stock")
            .WithColumn("product_id").AsInt32().NotNullable().PrimaryKey().ForeignKey("product", "id")
            .WithColumn("size_id").AsInt32().NotNullable().PrimaryKey().ForeignKey("size", "id")
            .WithColumn("color_id").AsInt32().NotNullable().PrimaryKey().ForeignKey("color", "id")
            .WithColumn("quantity").AsInt32().NotNullable();

    }
}
