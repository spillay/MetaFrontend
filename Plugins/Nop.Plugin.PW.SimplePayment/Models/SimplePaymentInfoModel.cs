using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Nop.Plugin.PW.SimplePayment.Models;

public record SimplePaymentInfoModel : BaseNopModel
{
    [Required]   
    [NopResourceDisplayName("Payment.SmartCardNumber")]
    public string SmartCardNumber { get; set; }
}