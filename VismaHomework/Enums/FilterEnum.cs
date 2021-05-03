using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaHomework.Enums
{
    public enum FilterEnum
    {
        [Description("Filter By Author")]
        Author,
        [Description("Filter By Category")]
        Category,
        [Description("Filter By Language")]
        Language,
        [Description("Filter By ISBN")]
        ISBN,
        [Description("Filter By Taken")]
        Taken,
        [Description("Filter By Available")]
        Available,
        [Description("Don't Filter")]
        None
    }
}
