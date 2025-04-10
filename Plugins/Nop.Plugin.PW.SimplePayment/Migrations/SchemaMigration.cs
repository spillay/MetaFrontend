using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.PW.SimplePayment.Domains;

namespace Nop.Plugin.PW.SimplePayment.Migrations
{
    [NopMigration("2025-04-02 15:44:05", "Nop.Plugin.PW.SimplePayment schema", MigrationProcessType.Installation)]
    public class SchemaMigration : AutoReversingMigration
    {
        /// <summary>
        /// Collect the UP migration expressions
        /// </summary>
        public override void Up()
        {
            Create.TableFor<CustomTable>();
        }
    }
}