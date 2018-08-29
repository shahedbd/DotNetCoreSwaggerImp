using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Repository.Models
{
    public class PersonalInfo
    {
        public long PersonalInfoID { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Date Of Birth")]
        public Nullable<DateTime> DateOfBirth { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [DisplayName("Mobile No")]
        public string MobileNo { get; set; }
        public string NID { get; set; }
        public string Email { get; set; }
        public byte Status { get; set; }
    }
}
