namespace CustomerPurchaseRecord.Entities.Dtos.Requests
{
    public class CreateCustomerDto
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
