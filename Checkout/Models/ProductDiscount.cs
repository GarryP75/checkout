namespace Checkout.Models
{
    using System.ComponentModel.DataAnnotations;

    public enum DiscountType
    {
        Quantity=1,
    }

    public class ProductDiscount
    {
        public int Id { get; set; } // possible PK
        public int ProductId { get; set; } // possible FK
        [Required]
        public int Quantity { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [Required]
        public DiscountType Type { get; set; }
        [Required]
        public decimal DiscountAmount { get; set; }
    }
}