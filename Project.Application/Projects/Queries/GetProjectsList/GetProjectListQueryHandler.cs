using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project.Application.Interfaces;
using Project.Application.Projects.Queries.GetProjectDetails;
using Project.Application.Projects.Queries.GetProjectsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;

namespace Project.Application.Projects.Queries.GetProjectsList
{
    public class GetProjectListQueryHandler : IRequestHandler<GetProjectListQuery,ProjectListVm>
    {
        private readonly IProjectDbContext _projectDbContext;
        private readonly IMapper _mapper;
        public GetProjectListQueryHandler(IProjectDbContext dbContext, IMapper mapper)
           => (_projectDbContext, _mapper) = (dbContext, mapper);
        public async Task<ProjectListVm> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
        {
            var projectsQuery = await _projectDbContext.Projects_
                .Where(project => project.AuthorId == request.AuthorId)
                .ProjectTo<ProjectLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ProjectListVm { Projects = projectsQuery };
        }
    }
}
