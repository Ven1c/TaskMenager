using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.Domain
{
    public class Project_
    {
        public Guid AuthorId { get; set; }
        public Guid Id { get; set; }  
        public string Name { get; set; }
        public string Details { get; set; }
        public enum StatusCombination {New, Closed}
        //TO DO, разобраться с переопределением enum в дальнейшем
        //  public enum StatusCombination { New,InWork, InAcceptance, InTest, Closed}
    }
}
