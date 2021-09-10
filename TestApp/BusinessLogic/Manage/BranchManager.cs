
using AutoMapper;
using BusinessLogic.AutoMapper;
using BusinessLogic.Services;
using BusinessLogic.ViewModel;
using Common.Enums;
using DataAccess.Abstracts;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Manage
{
    public class BranchManager : IBranchService
    {
        private IBranchRepository branchRepo;
        private IRepresentativeRepository representativeRepo;
        private readonly IMapper mapper;
        public BranchManager(IBranchRepository branchRepo, IRepresentativeRepository representativeRepo)
        {
            this.branchRepo = branchRepo;
            this.representativeRepo = representativeRepo;
            mapper = AutoMapperConfig.Mapper;
        }


        public void Create(BranchCreateModel model, int representativeId)
        {

            string count = String.Format("{0:D4}", representativeId);
            Branch branch = new Branch
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Adress = model.Adress,
                Scope = model.Scope,
                CreationDate = DateTime.Now.ToString("dd.MM.yyyy"),
                RepresentativeId = representativeId,
                Status = Status.Added.ToString(),
                File = model.FileName,
                UserId=model.UserId,
                ApplyNo = "Q-" + DateTime.Now.ToString("yy") + "-" + DateTime.Now.ToString("MM") + "-" + count
            };
            branchRepo.Create(branch);
        }

        public List<BranchUpdateModel> GetAll()
        {
            var branches = branchRepo.GetAll();
            return GetListOfBranch(branches);
        }

        public List<BranchUpdateModel> GetAll(int Id)
        {
            var branches = branchRepo.GetAll(Id);
            return GetListOfBranch(branches);
        }



        private List<BranchUpdateModel> GetListOfBranch(List<Branch> branches)
        {
            var branchList = branches.Select(t => new BranchUpdateModel()
            {
                Id = t.Id,
                ApplyNo = t.ApplyNo,
                Name = t.Name,
                Adress = t.Adress,
                CreationDate = t.CreationDate,
                File = t.File,
                Status = t.Status,
                Representative = mapper.Map<RepresentativeViewModel>(t.Representative)
            }).ToList();

            return branchList;
        }

        public BranchUpdateModel Get(string id)
        {
            var branch = branchRepo.Get(id);
            var representative = representativeRepo.Get(branch.RepresentativeId);
            BranchUpdateModel updateModel = new BranchUpdateModel()
            {
                Id = branch.Id,
                ApplyNo = branch.ApplyNo,
                Name = branch.Name,
                Adress = branch.Adress,
                CreationDate = branch.CreationDate,
                File = branch.File,
                Status = branch.Status,
                Scope=branch.Scope,
                Representative = mapper.Map<RepresentativeViewModel>(representative)
            };
            return updateModel;
        }


        public void Update(BranchUpdateModel model)
        {
            var branch = branchRepo.Get(model.Id.ToString());
            branch.UserId = model.UserId;
            branch.Status = model.Status;
            branchRepo.Update(branch);
        }


    }
}
