using System.ComponentModel.DataAnnotations;
using E_Commerce.CustomValidator;

namespace E_Commerce.Model
{
    public class Order
    { 
        public int? orderNo { get; set; }
        [Required(ErrorMessage = "{0} can't be null")]
        public DateTime? orderDate { get; set; }

        [Required(ErrorMessage = "{0} can't be null")]
        [InvoiceValidators]
        public decimal? invoicePrice { get; set; }

        [Required(ErrorMessage = "{0} can't be null")]
        public List<Product> products { get; set; }
    }
}
