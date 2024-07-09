using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Project.Application.Interfaces;
using Projects.Domain;

namespace Project.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler
        :IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly IProjectDbContext _projectDbContext;
        public CreateProjectCommandHandler(IProjectDbContext dbContext) =>
            _projectDbContext = dbContext;
        public async Task<Guid> Handle(CreateProjectCommand request,CancellationToken cancellationToken)
        {
            var project = new Project_
            {
                Name = request.Name,
                Details = request.Details,
                AuthorId = request.AuthorId,
                Id = Guid.NewGuid(),
                TasksId = new List<Guid> {}
                //status combination
            };
            
            await _projectDbContext.Projects_.AddAsync(project,cancellationToken);
            await _projectDbContext.SaveChangesAsync(cancellationToken);
            
            return project.Id;
        }
    }
}
