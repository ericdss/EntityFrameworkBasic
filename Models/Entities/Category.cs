using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkBasic.Models.Entities
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Category()
        { }
        public Category(string name)
        {
            Name = name;
            Products = new List<Product>();
        }
    }
}