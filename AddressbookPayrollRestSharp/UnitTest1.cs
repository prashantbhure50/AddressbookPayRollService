using AddressbookPayRollService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;

namespace AddressbookPayrollRestSharp
{
    [TestClass]
    public class UnitTest1
    {
        RestClient client;

        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("http://localhost:4000");
        }

        private IRestResponse getAddressbookList()
        {
            RestRequest request = new RestRequest("/AddressbookPayroll/", Method.GET);

            //act

            IRestResponse response = client.Execute(request);
            return response;
        }

        [TestMethod]
        public void onCallingGETApi_ReturnAddressbookList()
        {
            IRestResponse response = getAddressbookList();

            //assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            List<AddressModle> dataResponse = JsonConvert.DeserializeObject<List<AddressModle>>(response.Content);
            Assert.AreEqual(9, dataResponse.Count);
            foreach (var item in dataResponse)
            {
                System.Console.WriteLine("id: " + item.ID + "Name: " + item.FirstName + "LastName: " + item.LastName + "Address: " + item.AddressDetail + "State: " + item.State + "City: " + item.City + "PhoneNumber: " + item.PhoneNumber + "Zip: " + item.Zip + "Email: " + item.Email + "Type: " + item.Type);
            }
        }
        [TestMethod]
        public void givenEmployee_OnPost_ShouldReturnAddressbook()
        {
            RestRequest request = new RestRequest("/AddressbookPayroll", Method.POST);
            JObject jObjectbody = new JObject();
            jObjectbody.Add("FirstName", "Alok");
            jObjectbody.Add("LastName", "Bhure");
            jObjectbody.Add("AddressDetail", "CSEB Colony");
            jObjectbody.Add("Sate", "Chhattisgahr");
            jObjectbody.Add("City", "Bilaspur");
            jObjectbody.Add("PhoneNumber", "7000593588");
            jObjectbody.Add("Zip", "560076");
            jObjectbody.Add("Email", "Prasahant@gmail.com");
            jObjectbody.Add("Type", "Family");
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);

            //act
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Created);
            AddressModle dataResponse = JsonConvert.DeserializeObject<AddressModle>(response.Content);
            Assert.AreEqual("Alok", dataResponse.FirstName);
            Assert.AreEqual("Prasahant@gmail.com", dataResponse.Email);
        }
    }
}
