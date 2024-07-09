using System.Collections.Generic;

namespace Project.Application.Tasks.Queries.GetProjectsList
{
    public class ProjectListVm
    {
        public IList<ProjectLookUpDto> Projects { get; set; }
    }
}
