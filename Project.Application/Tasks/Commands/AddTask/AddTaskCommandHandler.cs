using MediatR;
using Project.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects.Domain;

namespace Project.Application.Tasks.Commands.AddTask
{
    public class AddTaskCommandHandler:IRequestHandler<AddTaskCommand,Guid>
    {

        private readonly IProjectDbContext _projectDbContext;
        public AddTaskCommandHandler(IProjectDbContext dbContext) =>
            _projectDbContext = dbContext;
        public async Task<Guid> Handle(AddTaskCommand request,CancellationToken cancellationToken)
        {
            var task = new Task_
            {
                Id = Guid.NewGuid(),
                Details = request.Details,
                TaskName = request.TaskName,
                UserId = request.UserId,
                ProjectId = request.ProjectId,
                Status = "New"
            };
            var entity = await _projectDbContext.Projects_
                .FindAsync(new object[] { request.ProjectId }, cancellationToken);
            entity.TasksId.Add(task.Id);
            await _projectDbContext.Tasks_.AddAsync(task, cancellationToken);
            await _projectDbContext.SaveChangesAsync(cancellationToken);
            return task.Id;

        }
    }
}
