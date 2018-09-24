using System;
using System.Collections.Generic;
using System.Text;

namespace MilkManagement.Core.Validator
{
   public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }
}
