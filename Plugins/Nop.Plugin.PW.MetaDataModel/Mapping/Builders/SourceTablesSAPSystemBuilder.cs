using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.PW.MetaDataModel.Domains;

namespace Nop.Plugin.PW.MetaDataModel.Mapping.Builders
{
    public class SourceTablesSAPSystemBuilder : NopEntityBuilder<SourceTablesSAPSystem>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(SourceTablesSAPSystem.ID)).AsInt32().PrimaryKey()
                .WithColumn(nameof(SourceTablesSAPSystem.Name)).AsString(100);
            
            ////map the additional properties as foreign keys
            //.WithColumn(nameof(ProductViewTrackerRecord.ProductId)).AsInt32().ForeignKey<Product>(onDelete: Rule.Cascade)
            //.WithColumn(nameof(ProductViewTrackerRecord.CustomerId)).AsInt32().ForeignKey<Customer>(onDelete: Rule.Cascade)
            ////avoiding truncation/failure
            ////so we set the same max length used in the product name
            //.WithColumn(nameof(ProductViewTrackerRecord.ProductName)).AsString(400)
            ////not necessary if we don't specify any rules
            //.WithColumn(nameof(ProductViewTrackerRecord.IpAddress)).AsString()
            //.WithColumn(nameof(ProductViewTrackerRecord.IsRegistered)).AsInt32();
        }

        #endregion
    }
}