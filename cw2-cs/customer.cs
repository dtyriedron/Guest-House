using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace cw2_cs
{
    class Customer
    {
        private string cus_name;
        private string cus_address;
        private int cus_ref;
        ConnectionFacade ADDCusFacade = new ConnectionFacade();

        public string Cus_Name
        {
            get
            {
                return cus_name;
            }
            set
            {
                //show error
                cus_name = value;
            }
        }

        public string Cus_Address
        {
            get
            {
                return cus_address;
            }
            set
            {
                cus_address = value;
            }
        }

        public int Cus_Ref
        {
            get
            {
                return cus_ref;
            }
            set
            {
                //show error
                cus_ref = value;
            }
        }
        
        public void SelectCus()
        {
            //string query = "SELECT Cus_Address, Cus_Name, Cus_Ref FROM Customer WHERE Cus_Address = " + cus_address + "AND Cus_Name =" + cus_name;
            SqlConnection con = ADDCusFacade.Connect();
            try
            {
                SqlCommand com = new SqlCommand("SELECT Cus_Ref FROM Customer WHERE Cus_Address=@Cus_Address AND Cus_Name=@Cus_Name");
                com.Parameters.AddWithValue("@Cus_Address", Cus_Address);
                com.Parameters.AddWithValue("@Cus_Name", Cus_Name);
                com.CommandType = System.Data.CommandType.Text;
                com.Connection = con; 
                con.Open();
                SqlDataReader Cus_Ref_rdr = com.ExecuteReader();
                //read the cus ref               
                while (Cus_Ref_rdr.Read())
                {
                    Cus_Ref= Convert.ToInt32(Cus_Ref_rdr["Cus_Ref"]);
                }
                Cus_Ref_rdr.Close();
                com.ExecuteNonQuery();
            }
            catch(SqlException except)
            {
                throw except;
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertCus()
        {
            SqlConnection con = ADDCusFacade.Connect();

            try
            {
                SqlCommand com = new SqlCommand("INSERT INTO Customer (Cus_Address, Cus_Name) VALUES (@Cus_Address, @Cus_Name)");
                com.Parameters.AddWithValue("@Cus_Address", Cus_Address);
                com.Parameters.AddWithValue("@Cus_Name", Cus_Name);
                com.CommandType = System.Data.CommandType.Text;
                com.Connection = con;
                con.Open();
                com.ExecuteNonQuery();
            }
            catch (SqlException except)
            {
                throw except;
            }
            finally
            {
                con.Close();
            }
        }

        public void AmendCus()
        {
            SqlConnection con = ADDCusFacade.Connect();
            try
            {
                SqlCommand com = new SqlCommand("UPDATE Customer SET Cus_Name=@Cus_Name, Cus_Address=@Cus_Address WHERE Cus_Ref=@Cus_Ref");
                com.Parameters.AddWithValue("@Cus_Ref", Cus_Ref);
                com.Parameters.AddWithValue("@Cus_Name",Cus_Name);
                com.Parameters.AddWithValue("@Cus_Address", Cus_Address);
                com.CommandType = System.Data.CommandType.Text;
                com.Connection = con;
                con.Open();
                com.ExecuteNonQuery();
            }
            catch (SqlException except)
            {
                throw except;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
