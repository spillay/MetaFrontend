using Microsoft.AspNetCore.Http;
using Nop.Core;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Payments;
using Nop.Plugin.PW.SimplePayment.Components;
using Nop.Plugin.PW.SimplePayment.Models;
using Nop.Plugin.PW.SimplePayment.Validators;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Orders;
using Nop.Services.Payments;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.PW.SimplePayment
{
    /// <summary>
    /// Rename this file and change to the correct type
    /// </summary>
    public class CustomPlugin : BasePlugin, IWidgetPlugin, IPaymentMethod
    {
        public bool HideInWidgetList => false;

        #region Fields

        protected readonly ILocalizationService _localizationService;
        protected readonly IOrderTotalCalculationService _orderTotalCalculationService;
        protected readonly ISettingService _settingService;
        protected readonly IWebHelper _webHelper;
        protected readonly SimplePaymentSettings _simplePaymentSettings;

        #endregion


        public CustomPlugin(ILocalizationService localizationService,
            IOrderTotalCalculationService orderTotalCalculationService,
            ISettingService settingService,
            IWebHelper webHelper,
            SimplePaymentSettings manualPaymentSettings)
        {
            _localizationService = localizationService;
            _orderTotalCalculationService = orderTotalCalculationService;
            _settingService = settingService;
            _webHelper = webHelper;
            _simplePaymentSettings = manualPaymentSettings;
        }

        #region Payment Properties

        /// <summary>
        /// Gets a value indicating whether capture is supported
        /// </summary>
        public bool SupportCapture => false;

        /// <summary>
        /// Gets a value indicating whether partial refund is supported
        /// </summary>
        public bool SupportPartiallyRefund => false;

        /// <summary>
        /// Gets a value indicating whether refund is supported
        /// </summary>
        public bool SupportRefund => false;

        /// <summary>
        /// Gets a value indicating whether void is supported
        /// </summary>
        public bool SupportVoid => false;

        /// <summary>
        /// Gets a recurring payment type of payment method
        /// </summary>
        public RecurringPaymentType RecurringPaymentType => RecurringPaymentType.Manual;

        /// <summary>
        /// Gets a payment method type
        /// </summary>
        public PaymentMethodType PaymentMethodType => PaymentMethodType.Standard;

        /// <summary>
        /// Gets a value indicating whether we should display a payment information page for this plugin
        /// </summary>
        public bool SkipPaymentInfo => false;

        #endregion

        #region Widgets
        public Type GetWidgetViewComponent(string widgetZone)
        {
            return typeof(PaymentInfoViewComponent);
        }

        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(new List<string>
            {
                PublicWidgetZones.ProductDetailsAddInfo,
                PublicWidgetZones.OrderSummaryContentBefore,
                PublicWidgetZones.HeaderLinksBefore,
                PublicWidgetZones.Footer,
                PublicWidgetZones.OrderSummaryTotals,
                AdminWidgetZones.OrderShipmentDetailsButtons,
                AdminWidgetZones.OrderShipmentAddButtons,
                AdminWidgetZones.PaymentMethodListTop
            });
        }
        #endregion



        public async Task<decimal> GetAdditionalHandlingFeeAsync(IList<ShoppingCartItem> cart)
        {
            return await _orderTotalCalculationService.CalculatePaymentAdditionalFeeAsync(cart,
           _simplePaymentSettings.AdditionalFee, _simplePaymentSettings.AdditionalFeePercentage);
        }

        Task<ProcessPaymentRequest> IPaymentMethod.GetPaymentInfoAsync(IFormCollection form)
        {
            var payReq = new ProcessPaymentRequest();
            payReq.CustomValues.Add("SmartCardNumber", form["SmartCardNumber"]);
            return Task.FromResult(new ProcessPaymentRequest());
        }

        public async Task<string> GetPaymentMethodDescriptionAsync()
        {
            return await _localizationService.GetResourceAsync("Plugins.PW.SimplePayments.PaymentMethodDescription");
        }

      

        Task<ProcessPaymentResult> IPaymentMethod.ProcessPaymentAsync(ProcessPaymentRequest processPaymentRequest)
        {
            var result = new ProcessPaymentResult
            {
                AllowStoringCreditCardNumber = true
            };
            result.AddError("Not supported transaction type -- Simple Payment call Suresh at PurpleWire");
            //switch (_manualPaymentSettings.TransactMode)
            //{
            //    case TransactMode.Pending:
            //        result.NewPaymentStatus = PaymentStatus.Pending;
            //        break;
            //    case TransactMode.Authorize:
            //        result.NewPaymentStatus = PaymentStatus.Authorized;
            //        break;
            //    case TransactMode.AuthorizeAndCapture:
            //        result.NewPaymentStatus = PaymentStatus.Paid;
            //        break;
            //    default:
            //        result.AddError("Not supported transaction type");
            //        break;
            //}

            return Task.FromResult(result);
        }
        #region Payment Methods
        Task<CancelRecurringPaymentResult> IPaymentMethod.CancelRecurringPaymentAsync(CancelRecurringPaymentRequest cancelPaymentRequest)
        {
            return Task.FromResult(new CancelRecurringPaymentResult());
        }

        Task<bool> IPaymentMethod.CanRePostProcessPaymentAsync(Order order)
        {
            ArgumentNullException.ThrowIfNull(order);

            //it's not a redirection payment method. So we always return false
            return Task.FromResult(false);
        }

        Task<CapturePaymentResult> IPaymentMethod.CaptureAsync(CapturePaymentRequest capturePaymentRequest)
        {
            return Task.FromResult(new CapturePaymentResult { Errors = new[] { "Capture method not supported" } });
        }
        Type IPaymentMethod.GetPublicViewComponent()
        {
            return typeof(SimplePaymentViewComponent);
        }

        Task<bool> IPaymentMethod.HidePaymentMethodAsync(IList<ShoppingCartItem> cart)
        {
            return Task.FromResult(false);
        }

        Task IPaymentMethod.PostProcessPaymentAsync(PostProcessPaymentRequest postProcessPaymentRequest)
        {
            return Task.CompletedTask;
        }
        Task<ProcessPaymentResult> IPaymentMethod.ProcessRecurringPaymentAsync(ProcessPaymentRequest processPaymentRequest)
        {
            var result = new ProcessPaymentResult
            {
                AllowStoringCreditCardNumber = true
            };
            result.AddError("Not supported transaction type--SimplePayment");
            //switch (_manualPaymentSettings.TransactMode)
            //{
            //    case TransactMode.Pending:
            //        result.NewPaymentStatus = PaymentStatus.Pending;
            //        break;
            //    case TransactMode.Authorize:
            //        result.NewPaymentStatus = PaymentStatus.Authorized;
            //        break;
            //    case TransactMode.AuthorizeAndCapture:
            //        result.NewPaymentStatus = PaymentStatus.Paid;
            //        break;
            //    default:
            //        result.AddError("Not supported transaction type");
            //        break;
            //}

            return Task.FromResult(result);
        }

        Task<RefundPaymentResult> IPaymentMethod.RefundAsync(RefundPaymentRequest refundPaymentRequest)
        {
            return Task.FromResult(new RefundPaymentResult { Errors = new[] { "Refund method not supported" } });

        }

        Task<IList<string>> IPaymentMethod.ValidatePaymentFormAsync(IFormCollection form)
        {
            var warnings = new List<string>();

            var validator = new SimplePaymentInfoValidator(_localizationService);
            var model = new SimplePaymentInfoModel
            {
                SmartCardNumber = form["SmartCardNumber"]
            };
            var validationResult = validator.Validate(model);
            if (!validationResult.IsValid)
                warnings.AddRange(validationResult.Errors.Select(error => error.ErrorMessage));

            return Task.FromResult<IList<string>>(warnings);
        }

        Task<VoidPaymentResult> IPaymentMethod.VoidAsync(VoidPaymentRequest voidPaymentRequest)
        {
            return Task.FromResult(new VoidPaymentResult { Errors = new[] { "Void method not supported" } });
        }
        #endregion
    }
}