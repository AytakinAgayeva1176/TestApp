
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IBranchRepository
    {
        void Create(Branch model);
        void Update(Branch model);
        Branch Get(string id);
        List<Branch> GetAll();
        List<Branch> GetAll(int Id);
    }
}
