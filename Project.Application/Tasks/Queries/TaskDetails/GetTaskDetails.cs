using MediatR;
using Project.Application.Tasks.Queries.GetProjectDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Tasks.Queries.TaskDetails
{
    public class GetTaskDetails : IRequest<TaskDetailsVm>
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public string TaskName { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
    }
}
