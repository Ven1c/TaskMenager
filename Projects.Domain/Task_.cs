using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.Domain
{
    public class Task_
    {
       
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public User_ Worker { get; set; }
        public string TaskName { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }

    }
}
