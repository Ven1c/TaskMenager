using AutoMapper;
using MediatR;
using Project.Application.Interfaces;
using Project.Application.Tasks.Queries.GetTaskList;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;

namespace Project.Application.Tasks.Queries.GetTaskList
{
    public class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, TaskListVm>
    {
        private readonly IProjectDbContext _projectDbContext;
        private readonly IMapper _mapper;
        public GetTaskListQueryHandler(IProjectDbContext dbContext, IMapper mapper)
            => (_projectDbContext, _mapper) = (dbContext, mapper);
        public async Task<TaskListVm> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
        {
            var tasksQuery = await _projectDbContext.Tasks_
                .Where(task => task.UserId == request.UserId)
                .Where(task => task.ProjectId == request.ProjectId)
                .ProjectTo<TaskLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new TaskListVm { tasks = tasksQuery };
        }
    }
}
