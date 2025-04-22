using ExCSS;
using Nop.Services.Events;
using Nop.Services.Localization;
using Nop.Services.Security;
using Nop.Web.Framework.Events;
using Nop.Web.Framework.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.PW.MetaDataModel.Events;

public class EventConsumer : IConsumer<AdminMenuCreatedEvent>
{
    private readonly IPermissionService _permissionService;
    private readonly ILocalizationService _localizationService;

    public EventConsumer(IPermissionService permissionService,ILocalizationService localizationService)
    {
        _permissionService = permissionService;
        _localizationService = localizationService;
    }

    public async  Task HandleEventAsync(AdminMenuCreatedEvent eventMessage)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermission.Configuration.MANAGE_PLUGINS))
            return;

        var mRoot = new AdminMenuItem
        {
            SystemName = "MetaDataModeling",
            Title = await _localizationService.GetResourceAsync("Admin.MetaDataMenu"),
            //Url = eventMessage.GetMenuItemUrl("Home", "Index"),
            IconClass = "fas fa-desktop",
            ChildNodes = new List<AdminMenuItem>
            {
                new()
                {
                    SystemName = "MetaDataModeling1",
                    Title = "Source Tables Management", //await _localizationService.GetResourceAsync("Admin.MetaDataMenu"),
                    Url = eventMessage.GetMenuItemUrl("SourceTablesSAPSystemPlugin", "SourceTablesView"),
                    IconClass = "far fa-dot-circle",
                    Visible = true,
                },
                new()
                {
                    SystemName = "MetaDataModeling2",
                    Title = "Schema Management", // await _localizationService.GetResourceAsync("Admin.MetaDataMenu"),
                    Url = eventMessage.GetMenuItemUrl("SourceTablesSAPSystemPlugin", "SchemaView"),
                    IconClass = "far fa-dot-circle",
                    Visible = true,
                },
                 new()
                {
                    SystemName = "MetaDataModeling3",
                    Title = "Reports", // await _localizationService.GetResourceAsync("Admin.MetaDataMenu"),
                    Url = eventMessage.GetMenuItemUrl("SourceTablesSAPSystemPlugin", "ReportView"),
                    IconClass = "far fa-dot-circle",
                    Visible = true,
                }
            }
        };
        eventMessage.RootMenuItem.InsertAfter("Dashboard", mRoot);

        //eventMessage.RootMenuItem.InsertBefore("Local plugins",
        //    new AdminMenuItem
        //    {
        //        SystemName = "MetaDataModeling",
        //        Title = "Source Tables Management",
        //        Url = eventMessage.GetMenuItemUrl("SourceTablesSAPSystemPlugin", "SourceTablesView"),
        //        IconClass = "far fa-dot-circle",
        //        Visible = true,
        //    });

        //return Task.CompletedTask;
    }
}