using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum Scope
    {
        Industrial,
        Warehouse,
        [Display(Name = "Public Catering")]
        PublicCatering,
        Wholesale,
        Retail

    }
}
