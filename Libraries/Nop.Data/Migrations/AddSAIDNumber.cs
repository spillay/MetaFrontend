using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;
using Nop.Core.Domain.Customers;

// TODO: Suresh Added this line
namespace Nop.Data.Migrations
{
    [NopSchemaMigration("2025-04-01 00:00:00", "Customer add SAIDNumber")]
    public class AddSAIDNumber : ForwardOnlyMigration
    {
        /// <summary>
        /// Collect the UP migration expressions
        /// </summary>
        public override void Up()
        {
            var customerTableName = nameof(Customer);
            if (!Schema.Table(customerTableName).Column(nameof(Customer.SAIDNumber)).Exists())
                Alter.Table(customerTableName)
                    .AddColumn(nameof(Customer.SAIDNumber)).AsString(255).Nullable();
        }
    }

}
