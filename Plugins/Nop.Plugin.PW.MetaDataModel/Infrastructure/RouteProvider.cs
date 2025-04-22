using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework.Mvc.Routing;

namespace Nop.Plugin.PW.MetaDataModel.Infrastructure
{
    /// <summary>
    /// Represents plugin route provider
    /// </summary>
    public class RouteProvider : IRouteProvider
    {
        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="endpointRouteBuilder">Route builder</param>
        public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
        {
            //add route for the access token callback
            //endpointRouteBuilder.MapControllerRoute("GetSourceTablesSAPSystem", "/GetSourceTablesSAPSystem",
            //    new { controller = "SourceTablesSAPSystemPlugin", action = "GetSourceTablesSAPSystem" });
            endpointRouteBuilder.MapControllerRoute(name: "GetSourceTablesSAPSystem",
                pattern: $"GetSourceTablesSAPSystem/",
                   defaults: new { controller = "SourceTablesSAPSystemPlugin", action = "GetSourceTablesSAPSystem" });

            endpointRouteBuilder.MapControllerRoute(name: "SourceTablesView",
               pattern: $"Admin/SourceTablesSAPSystemPlugin/SourceTablesView",
                  defaults: new { controller = "SourceTablesSAPSystemPlugin", action = "SourceTablesView" });

            endpointRouteBuilder.MapControllerRoute(name: "SchemaView",
               pattern: $"Admin/SourceTablesSAPSystemPlugin/SchemaView",
                  defaults: new { controller = "SourceTablesSAPSystemPlugin", action = "SchemaView" });

            endpointRouteBuilder.MapControllerRoute(name: "ReportView",
              pattern: $"Admin/SourceTablesSAPSystemPlugin/ReportView",
                 defaults: new { controller = "SourceTablesSAPSystemPlugin", action = "ReportView" });


        }


        /// <summary>
        /// Gets a priority of route provider
        /// </summary>
        public int Priority => 0;
    }
}