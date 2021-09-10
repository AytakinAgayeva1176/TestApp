using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB() :base("myDb")
        {

        }

        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Representative> Representatives { get; set; }

    }
}
