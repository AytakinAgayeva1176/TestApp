using AutoMapper;
using BusinessLogic.ViewModel;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLogic.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }

        public static void Init()
        {
            var config = new MapperConfiguration(cfg=>
            {
                cfg.CreateMap<Representative, RepresentativeViewModel>();
                cfg.CreateMap<RepresentativeViewModel, Representative>();
            });

            Mapper = config.CreateMapper();
        }

        
    }
}