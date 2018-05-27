namespace Checkout.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Product
    {
        public int Id { get; set; }// possible PK
        [StringLength(8)]
        public string Sku { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}