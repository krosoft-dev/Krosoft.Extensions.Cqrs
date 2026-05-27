using Krosoft.Extensions.Core.Models;
using Krosoft.Extensions.Core.Models.Dto;

namespace Krosoft.Extensions.Cqrs.Extensions;

public static class PaginationDtoExtensions
{
    private const int DefaultPageNumber = 1;
    private const int DefaultPageSize = 10;

    public static PaginationRequest ToPaginationRequest(this IPaginationDto dto) => new()
    {
        Text = dto.Text,
        PageNumber = dto.PageNumber is > 0 ? dto.PageNumber.Value : DefaultPageNumber,
        PageSize = dto.PageSize is > 0 ? dto.PageSize.Value : DefaultPageSize,
        SortBy = dto.SortBy != null ? dto.SortBy.ToHashSet() : new HashSet<string>()
    };
}
