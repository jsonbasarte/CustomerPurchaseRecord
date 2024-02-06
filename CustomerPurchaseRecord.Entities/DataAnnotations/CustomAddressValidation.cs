using System.ComponentModel.DataAnnotations;

namespace CustomerPurchaseRecord.Entities.DataAnnotations;

public class CustomAddressValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var valueString = value != null ? value.ToString() : null;

        string city = "cagayan";

        if (valueString.StartsWith(city))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("Address should be with Cagayan de Oro City");
    }
}
