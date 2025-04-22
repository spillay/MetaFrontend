using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.PW.MetaDataModel.Domains;

namespace Nop.Plugin.PW.MetaDataModel.Migrations
{
    [NopMigration("2025-04-02 15:44:05", "Nop.Plugin.PW.MetaDataModel schema", MigrationProcessType.Installation)]
    public class SchemaMigration : AutoReversingMigration
    {
        /// <summary>
        /// Collect the UP migration expressions
        /// </summary>
        /// </summary>
        public override void Up()
        {
            Create.TableFor<SourceTablesSAPSystem>();
        }
    }
}