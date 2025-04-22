using Nop.Plugin.PW.MetaDataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.PW.MetaDataModel.Factories;

public interface ISourceTablesSAPSystemModelFactory
{
    /// <summary>
    /// Prepare source tables SAP system model
    /// </summary>
    /// <param name="sourceTablesSAPSystemModel">Source tables SAP system model</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the source tables SAP system model
    /// </returns>
    Task<List<SourceTablesSAPSystemModel>> PrepareSourceTablesSAPSystemModelAsync();
    //{
    //    ArgumentNullException.ThrowIfNull(sourceTablesSAPSystemModel);
    //    //prepare page parameters
    //    sourceTablesSAPSystemModel.SetGridPageSize();
    //    return Task.FromResult(sourceTablesSAPSystemModel);
    //}
}
