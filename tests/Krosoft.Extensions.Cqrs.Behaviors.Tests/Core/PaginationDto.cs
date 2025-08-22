using Krosoft.Extensions.Core.Models.Dto;

namespace Krosoft.Extensions.Cqrs.Behaviors.Tests.Core;

public record PaginationDto : IPaginationDto
{ 
    public int? PageNumber { get; set; }

   
    public int? PageSize { get; set; }

 
    public string[]? SortBy { get; set; }

  
    public string? Text { get; set; }
}