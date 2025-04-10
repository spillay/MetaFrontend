using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Http.Extensions;
using Nop.Plugin.PW.SimplePayment.Models;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.PW.SimplePayment.Components;

public class SimplePaymentViewComponent : NopViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = new SimplePaymentInfoModel();

        //set postback values (we cannot access "Form" with "GET" requests)
        if (!Request.IsGetRequest())
        {
            var form = await Request.ReadFormAsync();
            model.SmartCardNumber = form["SmartCardNumber"];
        }

        return View("~/Plugins/Nop.Plugin.PW.SimplePayment/Views/PaymentInfoSmart.cshtml", model);
    }
}