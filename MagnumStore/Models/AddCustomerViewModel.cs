using System;
using System.Collections.Generic;

namespace MagnumStore.Models
{
    public class AddCustomerViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public long PhoneNumber { get; set; }

        public string Gender { get; set; }

        /*public class Gender
        {
            public int ID { get; set; }
            public string Name { get; set; }

            List<Gender> genderList = new List<Gender> {
                                             new Gender{ Name="Male",   ID = 1},
                                             new Gender{ Name="Female", ID = 2}
                                             };
        }*/

        public DateTime DateOfBrith { get; set; }

        //public DateTime DateOfBirth { get; internal set; }
    }
}
