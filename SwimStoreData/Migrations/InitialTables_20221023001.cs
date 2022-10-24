using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimStoreData.Migrations;
[Migration(20221023001)]
public class InitialTables_20221023001 : Migration
{
    public override void Down()
    {
        Delete.Table("Product");
        Delete.Table("Brand");
    }

    public override void Up()
    {
        Create.Table("Product");
        Create.Table("Brand");
    }
}
