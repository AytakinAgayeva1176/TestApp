using DataAccess.Abstracts;
using DataAccess.Context;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class RepresentativeRepository : IRepresentativeRepository
    {
        public int Create(Representative model)
        {
            using (var context = new ContextDB())
            {
                context.Representatives.Add(model);
                context.SaveChanges();
                return model.Id;
            }
        }

        public Representative Get(int id)
        {
            using (var context = new ContextDB())
            {
                return context.Representatives.Find(id);
            }
        }
    }
}
