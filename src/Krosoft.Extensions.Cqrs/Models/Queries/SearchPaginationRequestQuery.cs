using Krosoft.Extensions.Core.Models;
using Krosoft.Extensions.Core.Models.Dto;

namespace Krosoft.Extensions.Cqrs.Models.Queries;

public record SearchPaginationRequestQuery<T> : BaseQuery<PaginationResult<T>>
{
    public ISearchPaginationRequest PaginationRequest { get; private set; } = null!;

    public SearchPaginationRequestQuery<T> SetPagination(IPaginationDto paginationDto)
    {
        PaginationRequest = new PaginationRequest();
        PaginationRequest.Text = paginationDto.Text;
        PaginationRequest.PageNumber = paginationDto.PageNumber ?? 1;
        PaginationRequest.PageSize = paginationDto.PageSize ?? 10;
        PaginationRequest.SortBy = paginationDto.SortBy != null ? paginationDto.SortBy.ToHashSet() : new HashSet<string>();

        return this;
    }
}