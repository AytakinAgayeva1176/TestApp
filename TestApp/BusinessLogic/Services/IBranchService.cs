using BusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IBranchService
    {
        void Create(BranchCreateModel model, int representativeId);
        void Update(BranchUpdateModel model);
        BranchUpdateModel Get(string id);
        List<BranchUpdateModel> GetAll();
        List<BranchUpdateModel> GetAll(int Id);
    }
}
