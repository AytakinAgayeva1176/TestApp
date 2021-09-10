
using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ViewModel
{
    public class BranchUpdateModel
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string CreationDate { get; set; }
        public Scope Scope { get; set; }
        public string ApplyNo { get; set; }
        public string File { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public string RegistrationDate { get; set; }
        public int RepresentativeId { get; set; }
        public virtual RepresentativeViewModel Representative { get; set; }
    }
}
