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


namespace Project.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly IProjectDbContext _projectDbContext;
        public DeleteProjectCommandHandler(IProjectDbContext dbContext) =>
            _projectDbContext = dbContext;
        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _projectDbContext.Projects_
                .FindAsync(new object[] { request.Id }, cancellationToken);
            _projectDbContext.Projects_.Remove(entity);
            await _projectDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
        }
}
