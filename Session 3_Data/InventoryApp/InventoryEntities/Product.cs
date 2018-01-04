
namespace InventoryEntities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public bool status { get; set; }
        public virtual Category Category { get; set; }
    }
}
