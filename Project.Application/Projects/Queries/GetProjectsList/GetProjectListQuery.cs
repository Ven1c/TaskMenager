using MediatR;
using System;


namespace Project.Application.Tasks.Queries.GetProjectsList
{
    public class GetProjectListQuery : IRequest<ProjectListVm>
    {
        public Guid AuthorId { get; set; }
    }
}
