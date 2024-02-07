using CustomerPurchaseRecord.Entities.Dtos.Responses;

namespace CustomerPurchaseRecord.UnitTests.Fixtures;

public class CustomerFixtures
{
    public static List<GetCustomerDto> GetAll() => new()
    {
        new GetCustomerDto()
        {
            CustomerId = 1,
            Firstname = "Saber",
            Lastname = "Boy",
            Address = "Mindanilla"
        },
         new GetCustomerDto()
        {
            CustomerId = 2,
            Firstname = "Sammy",
            Lastname = "Girl",
            Address = "Mindanilla"
        }
    };
}

//private static List<Employee> GetFakeEmployeeList()
//{
//    return new List<Employee>()
//    {
//        new Employee
//        {
//            Id = 1,
//            Name = "John Doe",
//            Email = "J.D@gmail.com",
//            Phone = "123-456-7890"
//        },
//        new Employee
//        {
//            Id = 2,
//            Name = "Mark Luther",
//            Email = "M.L@gmail.com",
//            Phone = "123-456-7890"
//        }
//    };
//}
