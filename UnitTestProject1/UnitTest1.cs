using AddressbookPayRollService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given10Employee_WhenAddedToList_ShouldMatchEmployeeEntries()
        {
            List<AddressModle> contact = new List<AddressModle>();
            contact.Add(new AddressModle("Alok", "Bhure", "Tifra", "Chhattisgarh", "Bilaspur", "7000504500", "18009", "Alok@gmail.com", "Family"));
            contact.Add(new AddressModle("Prashant", "Bhure", "Tifra", "Chhattisgarh", "Bilaspur", "7000504500", "18009", "Prashant@gmail.com", "Family"));
            contact.Add(new AddressModle("Sailesh", "Chauhan", "SECR", "MadhyaPradesh", "Bilaspur", "7003453433", "38009", "Sailesh@gmail.com", "Friend"));
            contact.Add(new AddressModle("Victor", "Singha", "ASER", "Assam", "Bilaspur", "70043504500", "48009", "Victor@gmail.com", "Friend"));
            contact.Add(new AddressModle("Soham", "Dhamanskar", "SCR", "Maharastra", "Mumbai", "5000504500", "58009", "Soham@gmail.com", "Friend"));
            contact.Add(new AddressModle("Shivam", "Mathur", "SECR", "MadhyaPradesh", "Ujjain", "67000504500", "68009", "Shivam@gmail.com", "Friend"));
            contact.Add(new AddressModle("Shantnu", "mahapatra", "WECR", "Odrisa", "Buneshwer", "7000504500", "78009", "Shantnu@gmail.com", "Friend"));
            contact.Add(new AddressModle("Pratik", "Karche", "SER", "Maharastra", "Mumbai", "8000504500", "88009", "Pratik@gmail.com", "Friend"));
            contact.Add(new AddressModle("Shubham", "Bodake", "SER", "Maharastra", "Munbai", "9000504500", "98009", "Shubham@gmail.com", "Friend"));

            AddressbookPayrollOperation AddressbookList = new AddressbookPayrollOperation();
            DateTime startDateTime = DateTime.Now;
            AddressbookList.addContact(contact);
            DateTime stopDateTime = DateTime.Now;
            Console.WriteLine("Duration without thread: " + (stopDateTime - startDateTime));

            DateTime startDateTimeThread = DateTime.Now;
            AddressbookList.addContactWithThread(contact);
            DateTime stopDateTimeThread = DateTime.Now;
            Console.WriteLine("Duration with thread: " + (stopDateTimeThread - startDateTimeThread));
            //Assert.AreNotEqual(v1,v2);



        }
    }
}
