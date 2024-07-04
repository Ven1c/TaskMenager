using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.Domain
{
    public class User_
    {

        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        //TO DO, как хранить информацию(Id проектов) о том к каким проектом он имеет доступ?
    }
}
