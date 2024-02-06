using CustomerPurchaseRecord.Entities.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace CustomerPurchaseRecord.Entities.Dtos.Requests
{
    public class CreateCustomerDto
    {
        [Required, MinLength(5)]
        public string Firstname { get; set; } = string.Empty;

        [Required]
        public string Lastname { get; set; } = string.Empty;

        [Required, CustomAddressValidation]
        public string Address { get; set; } = string.Empty;
    }
}
