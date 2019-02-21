using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MilkManagement.Core.Validator
{
    public interface ISoftDeletable
    {
        [DefaultValue(false)]
        bool IsDeleted { get; set; }
    }
}
