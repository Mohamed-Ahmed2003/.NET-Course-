using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Model
{
    public class Product
    {
        [Required(ErrorMessage = "{0} can't be null")]
        public int productCode {  get; set; }

        [Required(ErrorMessage = "{0} can't be null")]
        [Range(1,double.MaxValue,ErrorMessage ="this price is out of range")]
        public double price { get; set; }

        [Required(ErrorMessage ="{0} can't be null")]
        [Range(1, int.MaxValue, ErrorMessage = "this quntity is out of range")]

        public int quntity { get; set; }


    }
}
