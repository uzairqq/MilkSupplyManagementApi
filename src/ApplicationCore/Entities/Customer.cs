using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class Customer : BaseEntity
    {
        [Required]
        public string Name { get; set; }

    }
}
