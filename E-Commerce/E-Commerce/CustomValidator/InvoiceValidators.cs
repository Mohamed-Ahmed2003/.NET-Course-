using System.ComponentModel.DataAnnotations;
using System.Reflection;
using E_Commerce.Model;

namespace E_Commerce.CustomValidator
{
    public class InvoiceValidators:ValidationAttribute
    {
        public string errorMassage { get; set; } = "Invoice must be equal total price of all product {0}";

        public InvoiceValidators() { }


        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value!= null)
            {
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(nameof(Order.products));
                if (otherProperty != null)
                {
                    List<Product> products = (List<Product>)otherProperty.GetValue(validationContext.ObjectInstance);
                    double totalPrice = 0;
                    foreach (Product product in products)
                    {
                        totalPrice += (product.price * product.quntity);
                    }
                    double invoice = Convert.ToDouble(value);
                    if (totalPrice > 0)
                    {
                        if (invoice != totalPrice)
                        {
                            return new ValidationResult(string.Format(errorMassage, totalPrice));
                        }

                    }
                    else
                        return new ValidationResult("no product are found");
                    return ValidationResult.Success;

                }
                else 
                    return null;
            }
            else
                return null;
        }
    }
}
