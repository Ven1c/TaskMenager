using MediatR;
using Microsoft.EntityFrameworkCore;
using Project.Application.Interfaces;
using Project.Application.Tasks.Commands.AddTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Tasks.Commands.ChangeStatus
{
    public class ChangeTaskStatusCommandHandler : IRequestHandler<ChangeTaskStatusCommand, Unit>
    {
        private readonly IProjectDbContext _projectDbContext;
        public ChangeTaskStatusCommandHandler(IProjectDbContext dbContext) =>
            _projectDbContext = dbContext;
        public async Task<Unit> Handle(ChangeTaskStatusCommand request, CancellationToken cancellationToken)
        {
            
            var entity =
            await _projectDbContext.Tasks_.FirstOrDefaultAsync(Task =>
            Task.Id == request.Id, cancellationToken);
            var entity1 =
            await _projectDbContext.Projects_.FirstOrDefaultAsync(Project =>
            Project.Id == entity.ProjectId, cancellationToken);
            if (Array.IndexOf(entity1.StatusCombination, entity.Status) != (entity1.StatusCombination.Length-1))
            {
                entity.Status = entity1.StatusCombination[Array.IndexOf(entity1.StatusCombination, entity.Status) + 1];
            }
            await _projectDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
