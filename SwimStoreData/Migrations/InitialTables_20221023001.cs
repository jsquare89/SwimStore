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
        Delete.Table("type");
    }

    public override void Up()
    {
        Create.Table("brand")
            .WithColumn("id").AsInt32().NotNullable().Identity().PrimaryKey()
            .WithColumn("name").AsString(50).NotNullable();

        Create.Table("type")
            .WithColumn("id").AsInt32().NotNullable().Identity().PrimaryKey()
            .WithColumn("name").AsString(50).NotNullable();

        Create.Table("product")
            .WithColumn("id").AsInt32().NotNullable().Identity().PrimaryKey()
            .WithColumn("name").AsString(70).NotNullable()
            .WithColumn("retail_price").AsInt32().NotNullable()
            .WithColumn("current_price").AsInt32().NotNullable()
            .WithColumn("description").AsString(2000).NotNullable()
            .WithColumn("features").AsString(2000).NotNullable()
            .WithColumn("sku").AsString(20).NotNullable()
            .WithColumn("brandId").AsInt32().NotNullable().ForeignKey("brand", "id")
            .WithColumn("typeId").AsInt32().NotNullable().ForeignKey("type", "id")
            .WithColumn("gender").AsString(1).NotNullable();

        
        
        //Create.Table("Color")
        //   .WithColumn("id").AsGuid().NotNullable().Identity().PrimaryKey()
        //   .WithColumn("name").AsString(50).NotNullable();
    }
}
