﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.Application.Interfaces;
using Projects.Domain;
using Project.Application.Tasks.Commands.CreateProject;


namespace Project.Application.Tasks.Commands.CreateProject
{
    public class CreateProjectCommandHandler
        : IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IProjectDbContext _projectDbContext;
        public CreateProjectCommandHandler(IProjectDbContext dbContext) =>
            _projectDbContext = dbContext;
        public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var temp = request.StatusCombination;
            if (temp == null)
            {
                temp = new string[] { "New", "In Work", "Something", "TO DO", "Ending", "Closed" };
            }
            var project = new Project_
            {
                Name = request.Name,
                Details = request.Details,
                AuthorId = request.AuthorId,
                Id = Guid.NewGuid(),
                TasksId = new List<Task_> { },
                StatusCombination = temp
            };

            await _projectDbContext.Projects_.AddAsync(project, cancellationToken);

            await _projectDbContext.SaveChangesAsync(cancellationToken);

            return project.Id;
        }
    }
   
}
