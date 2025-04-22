using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.PW.MetaDataModel.Domains;
using Nop.Plugin.PW.MetaDataModel.Factories;
using Nop.Plugin.PW.MetaDataModel.Services;
using Nop.Services.Catalog;
using Nop.Services.Customers;
using Nop.Web.Framework.Components;
using Nop.Web.Models.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.PW.MetaDataModel.Components;

public partial class SourceTablesSAPSystemViewComponent : NopViewComponent
{
    private readonly ISourceTablesSAPSystemModelFactory _sourceTablesModelFactory;
  
    public SourceTablesSAPSystemViewComponent(ISourceTablesSAPSystemModelFactory sourceTablesModelFactory)
    {
        _sourceTablesModelFactory = sourceTablesModelFactory;

    }
    public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
    {

        //var data = await _sourceTablesModelFactory.PrepareSourceTablesSAPSystemModelAsync();

        //return View("~/Plugins/Nop.Plugin.PW.MetaDataModel/Views/SAPView.cshtml", data);
        return View("~/Plugins/Nop.Plugin.PW.MetaDataModel/Views/SAPView.cshtml");
    }
}
