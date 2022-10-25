using FluentMigrator;
using SwimStoreData.Dtos;

namespace SwimStoreData.Migrations;
[Migration(20221024001)]
public class InitialSeed_20221024001 : Migration
{
    public override void Down()
    {
        
    }

    public override void Up()
    {
        InsertIntoBrandTable();
        InsertIntoTypeTable();
        InsertIntoProductTable();
    }

    private void InsertIntoTypeTable()
    {
        Insert.IntoTable("type")
            .Row(new
            {
                name = "briefs"
            });
        Insert.IntoTable("type" +
            "")
            .Row(new
            {
                name = "jammer"

            });
        Insert.IntoTable("type" +
            "")
            .Row(new
            {
                name = "wetsuits"
            });
        Insert.IntoTable("type" +
            "")
            .Row(new
            {
                name = "racing suits"
            });
        Insert.IntoTable("type" +
            "")
            .Row(new
            {
                name = "training suits"
            });
        Insert.IntoTable("type" +
            "")
            .Row(new
            {
                name = "lesuire"
            });
        Insert.IntoTable("type" +
            "")
            .Row(new
            {
                name = "goggles",
                accessory = true
            });
    }
    private void InsertIntoBrandTable()
    {
        Insert.IntoTable("brand")
            .Row(new
            {
                name = "speedo"
            });
        Insert.IntoTable("brand")
            .Row(new
            {
                name = "arena"

            });
        Insert.IntoTable("brand")
            .Row(new
            {
                name = "tyr"
            });
        Insert.IntoTable("brand")
            .Row(new
            {
                name = "nike"
            });
        Insert.IntoTable("brand")
            .Row(new
            {
                name = "phelps"
            });
    }
    private void InsertIntoProductTable()
    {
        Insert.IntoTable("product")
            .Row(new
            {
                name = "Solid Jammer",
                retail_price = 4999,
                current_price = 3999,
                description = "description",
                features = "features",
                sku = "sku here",
                brand_id = 1,
                type_id = 2,
                gender = "m"
            });
        Insert.IntoTable("product")
            .Row(new 
            {
                name = "Pro LT",
                retail_price = 4999,
                current_price = 3999,
                description = "description",
                features = "features",
                sku = "sku here",
                brand_id = 1,
                type_id = 1,
                gender = "m"
            });
        Insert.IntoTable("product")
            .Row(new
            {
                name = "Crossback Racer",
                retail_price = 4999,
                current_price = 3999,
                description = "description",
                features = "features",
                sku = "sku here",
                brand_id = 1,
                type_id = 4,
                gender = "f"
            });
    }
}
