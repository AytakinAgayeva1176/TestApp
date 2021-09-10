﻿using BusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IRepresentativeService 
    {
        RepresentativeViewModel Get(int id);
        int Create(RepresentativeViewModel model);
    }
}
