using Kendo.Mvc;
using Kendo.Mvc.Infrastructure;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Interface.Extensions;

public class DataSourceRequestQuery
{
    [FromQuery(Name = "page")]
    public int Page { get; set; }= 1;
    
    [FromQuery(Name = "pageSize")]
    public int PageSize { get; set; }= 100;
    
    [FromQuery(Name = "skip")]
    public int Skip { get; set; }
    
    [FromQuery(Name = "take")]
    public int Take { get; set; }= 100;
    
    [FromQuery(Name = "sort")]
    public string? Sort { get; set; }
    
    [FromQuery(Name = "filter")]
    public string? Filter { get; set; }
    
    [FromQuery(Name = "group")]
    public string? Group { get; set; }
    
    [FromQuery(Name = "aggregate")]
    public string? Aggregate { get; set; }

    public DataSourceRequest ToKendo()
    {
        return new DataSourceRequest
        {
            Page = Page,
            PageSize = PageSize,
            Skip = Skip,
            Take = Take,
            Groups = string.IsNullOrEmpty(Group)
                ? []
                : DataSourceDescriptorSerializer
                    .Deserialize<GroupDescriptor>(Group)
                    .Where(g => g.Member != "Id")
                    .ToList(),
            Sorts = string.IsNullOrEmpty(Sort)
                ? []
                : DataSourceDescriptorSerializer.Deserialize<SortDescriptor>(Sort),
            Filters = string.IsNullOrEmpty(Filter)
                ? []
                : FilterDescriptorFactory.Create(Filter),
            Aggregates = string.IsNullOrEmpty(Aggregate)
                ? []
                : DataSourceDescriptorSerializer.Deserialize<AggregateDescriptor>(Aggregate)
        };
    }
}
