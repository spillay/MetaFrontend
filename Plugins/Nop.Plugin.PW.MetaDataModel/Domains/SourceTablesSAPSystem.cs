using Nop.Core;
using Nop.Core.Domain.Common;

namespace Nop.Plugin.PW.MetaDataModel.Domains;

public partial class SourceTablesSAPSystem : BaseEntity, ISoftDeletedEntity
{
    //public bool Deleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool Deleted { get; set; }

    public int ID { get; set; }
    public string Name { get; set; }
    //public string ServerName { get; set; }
    //public string TableSchema { get; set; }
    //public string TableName { get; set; }

}