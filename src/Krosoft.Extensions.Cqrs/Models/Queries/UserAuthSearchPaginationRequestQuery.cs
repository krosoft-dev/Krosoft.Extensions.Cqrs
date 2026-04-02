using Krosoft.Extensions.Core.Models;
using Krosoft.Extensions.Core.Models.Dto;
using Krosoft.Extensions.Cqrs.Extensions;

namespace Krosoft.Extensions.Cqrs.Models.Queries;

public record UserAuthSearchPaginationRequestQuery<T> : AuthBaseQuery<PaginationResult<T>>
{
    public override bool IsTenantIdRequired => false;

    public ISearchPaginationRequest PaginationRequest { get; private set; } = null!;

    public UserAuthSearchPaginationRequestQuery<T> SetPagination(IPaginationDto paginationDto)
    {
        PaginationRequest = paginationDto.ToPaginationRequest();
        return this;
    }
}
