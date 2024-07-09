using System;
using MediatR;

namespace Project.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
    }
}
