using DocumentFormat.OpenXml.Vml.Spreadsheet;
using Nop.Data;
using Nop.Plugin.PW.MetaDataModel.Domains;
using Nop.Plugin.PW.MetaDataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.PW.MetaDataModel.Services;


public interface ISourceTablesSAPSystemService
{
    /// <summary>
    /// Logs the specified record.
    /// </summary>
    /// <param name="record">The record.</param>
    void Log(SourceTablesSAPSystem record);
    Task<IList<SourceTablesSAPSystem>> GetSourceTablesSAPSystemAsync();
}


public class SourceTablesSAPSystemService : ISourceTablesSAPSystemService
{
    private readonly IRepository<SourceTablesSAPSystem> _sourceTablesSAPSystemRepository;
    public SourceTablesSAPSystemService(IRepository<SourceTablesSAPSystem> sourceTablesSAPSystemRepository)
    {
        _sourceTablesSAPSystemRepository = sourceTablesSAPSystemRepository;
    }

    public async Task<IList<SourceTablesSAPSystem>> GetSourceTablesSAPSystemAsync()
    {
        //var query = from p in _sourceTablesSAPSystemRepository.Table
        //            where
        //            !p.Deleted
        //            select p;
        //Func<IQueryable<SourceTablesSAPSystem>, IOrderedQueryable<SourceTablesSAPSystem>> orderingFunc =
        //    query => query.OrderBy(student => student.Name);
        //return await _sourceTablesSAPSystemRepository.GetAllAsync(orderingFunc);

        var src = await _sourceTablesSAPSystemRepository.GetAllAsync(query =>
        {
            query = query.Where(p => !p.Deleted);
            return query;
        });
        return src;

    }


    /// <summary>
    /// Logs the specified record.
    /// </summary>
    /// <param name="record">The record.</param>
    public void Log(SourceTablesSAPSystem record)
    {
        if (record == null)
            throw new ArgumentNullException(nameof(record));
        _sourceTablesSAPSystemRepository.Insert(record);
    }
}

