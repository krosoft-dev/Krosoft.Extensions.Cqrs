using JetBrains.Annotations;
using Krosoft.Extensions.Cqrs.Behaviors.Tests.Core;
using Krosoft.Extensions.Cqrs.Models.Queries;

namespace Krosoft.Extensions.Cqrs.Behaviors.Tests.Models.Queries;

[TestClass]
[TestSubject(typeof(SearchPaginationRequestQuery<>))]
public class SearchPaginationRequestQueryTest
{
    [TestMethod]
    public void SetPagination_Default()
    {
        var pagination = new PaginationDto();
        var query = new HelloSearchQuery
        {
            Name = "World"
        };
        query.SetPagination(pagination);

        Check.That(query.Name).IsEqualTo("World");
        Check.That(query.PaginationRequest).IsNotNull();
        Check.That(query.PaginationRequest.PageNumber).IsEqualTo(1);
        Check.That(query.PaginationRequest.PageSize).IsEqualTo(10);
        Check.That(query.PaginationRequest.SortBy).IsNotNull();
        Check.That(query.PaginationRequest.SortBy).IsEmpty();
        Check.That(query.PaginationRequest.Text).IsNull();
    }
}