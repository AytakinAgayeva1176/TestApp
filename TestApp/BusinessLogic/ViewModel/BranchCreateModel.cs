using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Common.Enums;

namespace BusinessLogic.ViewModel
{
    public class BranchCreateModel
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string FileName{ get; set; }
        public Scope Scope { get; set; }
        public int UserId { get; set; }
        public virtual RepresentativeViewModel Representative { get; set; }
    }
}
