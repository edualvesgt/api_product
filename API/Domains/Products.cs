using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_Product.Domains
{
    [Table("Products")]
    public class Products
    {

        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(255)")]
        [Required(ErrorMessage = "Nome Obrigatorio")]
        public string? Name { get; set; }

        [Column(TypeName = "DECIMAL")]
        [Required(ErrorMessage = "Preco Obrigatorio")]
        public Decimal Price { get; set; }

    }    
}
