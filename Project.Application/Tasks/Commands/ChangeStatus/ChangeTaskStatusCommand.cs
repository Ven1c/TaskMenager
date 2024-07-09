﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Tasks.Commands.ChangeStatus
{
    public class ChangeTaskStatusCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
    }
}

