using AutoMapper;
using BusinessLogic.AutoMapper;
using BusinessLogic.Services;
using BusinessLogic.ViewModel;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Manage
{
    public class RepresentativeManager : IRepresentativeService
    {
        private IRepresentativeRepository representativeRepo;

        private readonly IMapper mapper;

        public RepresentativeManager(IRepresentativeRepository representativeRepo)
        {
            this.representativeRepo = representativeRepo;
            mapper = AutoMapperConfig.Mapper;
        }

        public int Create(RepresentativeViewModel model)
        {
            Representative representative = mapper.Map<Representative>(model);
            //Representative representative = new Representative()
            //{
            //    Name=model.Name,
            //    Surname=model.Surname,
            //    Adress=model.Adress
            //};
            var representativeId= representativeRepo.Create(representative);
            return representativeId;
        }

        public RepresentativeViewModel Get(int id)
        {
            var representative = representativeRepo.Get(id);
            return mapper.Map<RepresentativeViewModel>(representative);
        }
    }
}
