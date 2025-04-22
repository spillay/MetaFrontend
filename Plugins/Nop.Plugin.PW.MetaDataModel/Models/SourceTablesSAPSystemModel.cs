using Nop.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.PW.MetaDataModel.Models;

public record SourceTablesSAPSystemModel : BaseNopModel
{
    public int ID { get; set; }
    public string Name { get; set; }    

}
