using System.Data.Entity;
using System.Linq;
using FluentMigrator;
using Magentix.Domain.Models.Settings;
using Magentix.Localization.Properties;
using Magentix.Presentation.Services.Common;

namespace Magentix.Persistance.DBMigration
{
    [Migration(9)]
    public class Migration_009 : Migration
    {
        public override void Up()
        {
            Create.Column("PrimaryFieldName").OnTable("EntityTypes").AsString(128).Nullable();
            Create.Column("PrimaryFieldFormat").OnTable("EntityTypes").AsString(128).Nullable();
        }

        public override void Down()
        {

        }
    }
}