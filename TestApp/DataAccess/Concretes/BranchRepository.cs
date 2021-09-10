using DataAccess.Abstracts;
using DataAccess.Context;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class BranchRepository : IBranchRepository
    {

        public void Create(Branch model)
        {
            using (var context = new ContextDB())
            {
                context.Branches.Add(model);
                context.SaveChanges();
            }
        }

  

        public Branch Get(string id)
        {
            Guid gId = new Guid(id);
            using (var context = new ContextDB())
            {
                return context.Branches.Find(gId);
            }
        }

        public List<Branch> GetAll()
        {
            using (var context = new ContextDB())
            {
                var branches = context.Branches.Include(c => c.Representative).OrderByDescending(x => x.ApplyNo).ToList();

                return branches;
            }
        }

        public List<Branch> GetAll(int Id)
        {
            using (var context = new ContextDB())
            {
                var branches = context.Branches.Where(x => x.UserId == Id).Include(c => c.Representative).OrderByDescending(x => x.ApplyNo).ToList();

                return branches;
            }
        }

        public void Update(Branch model)
        {
            using (var context = new ContextDB())
            {
                
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
