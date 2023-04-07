using System;

namespace MagnumStore.Models
{
    public class UpdateCustomerViewModel    
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public long PhoneNumber { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBrith { get; set; }
    }
}
