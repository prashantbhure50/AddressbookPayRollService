using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookPayRollService
{
    public class AddressbookPayrollOperation
    {
      
            public List<AddressModle> AddressbookList = new List<AddressModle>();
            public void addContact(List<AddressModle> AddressbookList)
            {
            AddressbookList.ForEach(contactData =>
                {
                    Console.WriteLine("Employee being added: " + contactData.FirstName);
                    this.addContact(contactData);
                    Console.WriteLine("Employee added: " + contactData.FirstName);
                });
                Console.WriteLine(this.AddressbookList.ToString());

            }


            public void addContact(AddressModle contact)
            {
            AddressbookList.Add(contact);
            }

            public void addContactWithThread(List<AddressModle> AddressbookList)
            {
            AddressbookList.ForEach(contactData =>
                {
                    Task thread = new Task(() =>
                    {
                        Console.WriteLine("Employee being added: " + contactData.FirstName);
                        this.addContact(contactData);
                        Console.WriteLine("Employee added: " + contactData.FirstName);
                    });
                    thread.Start();
                });
                Console.WriteLine(this.AddressbookList.Count);
            }

        
    }
}
