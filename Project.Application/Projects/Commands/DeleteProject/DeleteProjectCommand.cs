using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
    }
}
