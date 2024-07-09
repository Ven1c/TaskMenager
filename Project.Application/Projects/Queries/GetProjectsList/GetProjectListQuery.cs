using MediatR;
using System;


namespace Project.Application.Projects.Queries.GetProjectsList
{
    public class GetProjectListQuery : IRequest<ProjectListVm>
    {
        public Guid AuthorId { get; set; }
    }
}
