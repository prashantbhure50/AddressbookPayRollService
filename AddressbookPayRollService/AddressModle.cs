using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookPayRollService
{
   public  class AddressModle
    {
        public AddressModle()
        {
        }

        public AddressModle(string FirstName, string Lastname, string AddressDetail, string State, string City, string PhoneNumber, string Zip, string Email, string Type)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.AddressDetail = AddressDetail;
            this.State = State;
            this.City = City;
            this.PhoneNumber = PhoneNumber;
            this.Zip = Zip;
            this.Email = Email;
            this.Type = Type;
        }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressDetail { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }   
   }
}