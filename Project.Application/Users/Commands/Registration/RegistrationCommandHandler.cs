using MediatR;
using Project.Application.Interfaces;
using Project.Application.Tasks.Commands.AddTask;
using Projects.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Users.Commands.Registration
{
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, Guid>
    {
        private readonly IProjectDbContext _projectDbContext;
        public RegistrationCommandHandler(IProjectDbContext dbContext) =>
            _projectDbContext = dbContext;
        public async Task<Guid> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            var user = new User_
            {
                Id = Guid.NewGuid(),
                UserName = request.UserName,
                Login = request.Login,
                Password = request.Password,
                UserRole = request.UserRole

            };
            await _projectDbContext.Users_.AddAsync(user, cancellationToken);
            await _projectDbContext.SaveChangesAsync(cancellationToken);
            return user.Id;
        }
    }
}
