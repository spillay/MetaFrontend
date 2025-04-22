using Nop.Plugin.PW.MetaDataModel.Models;
using Nop.Plugin.PW.MetaDataModel.Services;
using Nop.Services.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.PW.MetaDataModel.Factories;

public  class SourceTablesSAPSystemModelFactory : ISourceTablesSAPSystemModelFactory
{
    protected readonly ISourceTablesSAPSystemService _sourceTablesService;

    public SourceTablesSAPSystemModelFactory(ISourceTablesSAPSystemService sourceTablesService) {
        _sourceTablesService = sourceTablesService;
    }

    /// <summary>
    /// Prepare source tables SAP system model
    /// </summary>
    /// <param name="sourceTablesSAPSystemModel">Source tables SAP system model</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the source tables SAP system model
    /// </returns>
    public virtual async Task<List<SourceTablesSAPSystemModel>> PrepareSourceTablesSAPSystemModelAsync()
    {
        var sourceTablesSAPSystemList = await _sourceTablesService.GetSourceTablesSAPSystemAsync();
        var sourceTablesSAPSystemModelList = sourceTablesSAPSystemList.Select(x => new SourceTablesSAPSystemModel
        {
            ID = x.Id,
            Name = x.Name
        }).ToList();

        return sourceTablesSAPSystemModelList;
    }
}
