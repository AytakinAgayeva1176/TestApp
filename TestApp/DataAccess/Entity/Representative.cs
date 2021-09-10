using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Representative
    {
        public Representative()
        {
            Branches = new HashSet<Branch>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public IEnumerable<Branch> Branches { get; set; }
    }
}
