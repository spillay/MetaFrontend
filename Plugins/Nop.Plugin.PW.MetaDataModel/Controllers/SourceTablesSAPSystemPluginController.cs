using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Plugin.PW.MetaDataModel.Models;
using Nop.Plugin.PW.MetaDataModel.Services;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Models.DataTables;
using Nop.Web.Framework.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.PW.MetaDataModel.Controllers;

[AutoValidateAntiforgeryToken]
[AuthorizeAdmin] //confirms access to the admin panel
//[Area(AreaNames.ADMIN)] //specifies the area containing a controller or action
public  class SourceTablesSAPSystemPluginController : BasePluginController
{
    private readonly ISourceTablesSAPSystemService _service;
    private readonly IWorkContext _workContext;
    public SourceTablesSAPSystemPluginController(IWorkContext workContext,ISourceTablesSAPSystemService service)
    {
        _service = service;
        _workContext = workContext;
    }

    //[HttpGet]
    //public IActionResult Configure()
    //{
    //    CustomersByCountrySearchModel customerSearchModel = new CustomersByCountrySearchModel
    //    {
    //        AvailablePageSizes = "10"
    //    };
    //    return View("~/Plugins/Tutorial.DistOfCustByCountry/Views/Configure.cshtml", customerSearchModel);
    //}

    [HttpPost]
    public async Task<IActionResult> GetSourceTablesSAPSystem()
    {
        try
        {
            return Ok(new DataTablesModel { Data = await _service.GetSourceTablesSAPSystemAsync() });
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
        //var model = await _service.GetSourceTablesSAPSystemAsync();
        //var data = new SourceTablesSAPSystemModel
        //{
        //    ID = model.FirstOrDefault().ID,
        //    Name = model.FirstOrDefault().Name
        //};
        //return (IActionResult)data;
    }
    public virtual IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult SourceTablesView ()
    {
        return View("~/Plugins/Nop.Plugin.PW.MetaDataModel/Views/SAPView.cshtml");

    }
    public IActionResult SchemaView() {
        return View("~/Plugins/Nop.Plugin.PW.MetaDataModel/Views/SchemaView.cshtml");
    }
    public IActionResult ReportView()
    {
        return View("~/Plugins/Nop.Plugin.PW.MetaDataModel/Views/ReportView.cshtml");
    }

    public virtual IActionResult GetStatistics(string period)
    {
        var result = new List<object>();

        result.Add(new
        {
            date = "1",
            value = "21"
        });
        result.Add(new
        {
            date = "2",
            value = "15"
        });
        result.Add(new
        {
            date = "3",
            value = "20"
        });
        result.Add(new
        {
            date = "4",
            value = "18"
        });
        result.Add(new
        {
            date = "5",
            value = "10"
        });

        return Json(result);
    }
}
