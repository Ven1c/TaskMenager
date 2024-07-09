using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Tasks.Commands.AddTask
{
    public class AddTaskCommand:IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public string TaskName { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
    }
}
