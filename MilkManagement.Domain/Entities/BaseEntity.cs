using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MilkManagement.Domain.Entities
{
   public class BaseEntity
    {
        public int Id { get; set; }

        [DefaultValue(10023)]
        public int CreatedById { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        [DefaultValue(10023)]
        public int LastUpdatedById { get; set; }
        [DefaultValue(10024)]
        public DateTime LastUpdatedOn { get; set; }
    }
}
