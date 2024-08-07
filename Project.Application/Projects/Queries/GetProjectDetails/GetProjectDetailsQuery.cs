﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Projects.Domain;

namespace Project.Application.Tasks.Queries.GetProjectDetails
{
    public class GetProjectDetailsQuery : IRequest<ProjectDetailsVm>
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public List<Guid> TasksId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        public string[] statusCombination { get; set; }
    }
}

