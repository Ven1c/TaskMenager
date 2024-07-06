using MediatR;
using Microsoft.EntityFrameworkCore;
using Project.Application.Interfaces;
using Project.Application.Projects.Commands.CreateProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Projects.Domain;
using System.Reflection.Metadata;

namespace Project.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand,Unit>
    {
        private readonly IProjectDbContext _projectDbContext;
        public UpdateProjectCommandHandler(IProjectDbContext dbContext) =>
            _projectDbContext = dbContext;
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = 
                await _projectDbContext.Projects_.FirstOrDefaultAsync(Project => 
                    Project.Id == request.Id,cancellationToken);
          
            entity.AuthorId = request.AuthorId;
            entity.Name = request.Name; 
            entity.Details = request.Details;

            await _projectDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    
    }
}
