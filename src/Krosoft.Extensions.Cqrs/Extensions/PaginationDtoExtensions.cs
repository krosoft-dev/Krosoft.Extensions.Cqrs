using Krosoft.Extensions.Core.Models;
using Krosoft.Extensions.Core.Models.Dto;

namespace Krosoft.Extensions.Cqrs.Extensions;

public static class PaginationDtoExtensions
{
    public static PaginationRequest ToPaginationRequest(this IPaginationDto dto) => new()
    {
        Text = dto.Text,
        PageNumber = dto.PageNumber ?? 1,
        PageSize = dto.PageSize ?? 10,
        SortBy = dto.SortBy != null ? dto.SortBy.ToHashSet() : new HashSet<string>()
    };
}
