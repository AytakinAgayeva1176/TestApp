using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IRepresentativeRepository 
    {
        Representative Get(int id);
        int Create(Representative model);
    }
}
