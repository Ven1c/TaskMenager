using MediatR;
using Project.Application.Interfaces;
using Project.Application.Tasks.Commands.DeleteProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler:IRequestHandler<DeleteTaskCommand,Unit>
    {
        private readonly IProjectDbContext _projectDbContext;
        public DeleteTaskCommandHandler(IProjectDbContext dbContext) =>
            _projectDbContext = dbContext;
        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var entity1 = await _projectDbContext.Tasks_
                .FindAsync(new object[] { request.Id }, cancellationToken);
            var entity2 = await _projectDbContext.Projects_
                .FindAsync(new object[] { entity1.ProjectId }, cancellationToken);
            entity2.TasksId.Remove(entity1);
            _projectDbContext.Tasks_.Remove(entity1);
            await _projectDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
