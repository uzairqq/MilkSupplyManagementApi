using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MilkManagement.Core.Validator;

namespace MilkManagement.Domain.Entities
{
   public class BaseEntity : ISoftDeletable
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

        public bool IsDeleted { get; set; }
    }
}
