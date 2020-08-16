using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameworkBasic.Models.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        [Required]
        [MaxLength(100), MinLength(3)] //StringLength validação do lado do servidor
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo deve ter entre {2} e {1} caracteres")] //StringLength validação do lado do cliente
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [Range(-999999999999.99, 999999999999.99)]
        public decimal Price { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        [ForeignKey("Category")] //Category = nome da propriedade de navegação criada abaixo
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public Product()
        { }
        public Product(Guid id, string name, string description, decimal price, DateTime creationDate, Category category)
        {
            ProductId = id;
            Name = name;
            Description = description;
            Price = price;
            CreationDate = creationDate;
            Category = category;
        }

        override public string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Id: {ProductId}");
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Description: {Description}");
            sb.AppendLine($"Price: {Price}");
            sb.AppendLine($"CreationDateTime: {CreationDate}");
            sb.AppendLine($"Categoria: {Category.Name}");

            return sb.ToString();
        }
    }
}