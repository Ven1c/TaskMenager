using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Tasks.Queries.GetTaskList
{
    public class TaskListVm
    {
        public IList<TaskLookUpDto> tasks { get; set; }    
    }
}
