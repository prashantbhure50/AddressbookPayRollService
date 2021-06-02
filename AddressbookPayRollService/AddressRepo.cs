using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookPayRollService
{
    public class AddressRepo
    {
        public static string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=AddresssbookDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public void GetAllEmployee()
        {
            try
            {
                AddressModle addressModel = new AddressModle();
                using (this.connection)
                {
                    string query = @"Select * from Erdigram;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            addressModel.FirstName = dr.GetString(0);
                            addressModel.LastName = dr.GetString(1);
                            addressModel.AddressDetail= dr.GetString(2);
                            addressModel.State= dr.GetString(3);
                            addressModel.City= dr.GetString(4);
                            addressModel.PhoneNumber= dr.GetString(5);
                            addressModel.Zip= dr.GetString(6);
                            addressModel.Type= dr.GetString(7);                     
                            System.Console.WriteLine(addressModel.FirstName + " " + addressModel.LastName  + " " + addressModel.AddressDetail + " " + addressModel.State + " " + addressModel.City + " " + addressModel.PhoneNumber + " " + addressModel.Zip + " " + addressModel.Email + " " + addressModel.Type);
                            System.Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
        public bool AddContact(AddressModle model)
        {
            try
            {
                using (this.connection)
                {
                   
                    SqlCommand command = new SqlCommand("SpAddContactDetail", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Addressdetail", model.AddressDetail);
                    command.Parameters.AddWithValue("@State", model.State);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@PhoneNo", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Zip", model.Zip);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@Type", model.Type);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {

                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }
        public bool DeleteContactByFirstName(AddressModle model)
        {
            try
            {
                using (this.connection)
                {
                    //var qury=values()
                    SqlCommand command = new SqlCommand("DeleteContact", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {

                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }
    }
}
