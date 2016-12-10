using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace cw2_cs
{
    class Booking
    {
        private string booking_date;
        private string date_leaving;
        private int booking_ref;
        private int no_guests;
        ConnectionFacade ADDBookFacade = new ConnectionFacade();
        private Customer cust;

        
       
        public string Booking_Date
        {
            get
            {
                return booking_date;
            }
            set
            {
                //error message
                booking_date = value;

            }
        }

        public string Date_Leaving
        {
            get
            {
                return date_leaving;
            }
            set
            {
                //show error
                date_leaving = value;
            }
        }

        public int Booking_Ref
        {
            get
            {
                return booking_ref;
            }
            set
            {
                //show error
                booking_ref = value;
            }
        }
        public Customer Cust
        {
            get
            {
                return cust;
            }
            set
            {
                cust = value;
            }
        }
        public int No_Guests
        {
            get
            {
                return no_guests;
            }
            set
            {
                no_guests = value;
            }
        }


        public void SelectBooking()
        {
            SqlConnection con = ADDBookFacade.Connect();
            try
            {
                //Cust.SelectCus();
                SqlCommand com = new SqlCommand("SELECT Booking_Ref FROM Booking WHERE Booking_Date=@Booking_Date AND Date_Leaving=@Date_Leaving AND Customer_id=@Customer_id");
                com.Parameters.AddWithValue("@Booking_Date", Booking_Date);
                com.Parameters.AddWithValue("@Date_Leaving", Date_Leaving);
                com.Parameters.AddWithValue("@Customer_id", Cust.Cus_Ref);
                com.CommandType = System.Data.CommandType.Text;
                com.Connection = con;
                con.Open();
                //read the book ref
                SqlDataReader Book_Ref_rdr = com.ExecuteReader();
                while (Book_Ref_rdr.Read())
                {
                    Booking_Ref = Convert.ToInt32(Book_Ref_rdr["Booking_Ref"]);
                }
                Book_Ref_rdr.Close();
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

        public void InsertBooking()
        {
            SqlConnection con = ADDBookFacade.Connect();

            try
            {
                SqlCommand com = new SqlCommand("INSERT INTO Booking (Booking_Date, Date_Leaving, Customer_id, No_Guests) VALUES (@Booking_Date, @Date_Leaving, @Customer_id, @No_Guests)");
                com.Parameters.AddWithValue("@Booking_Date", Booking_Date);
                com.Parameters.AddWithValue("@Date_Leaving", Date_Leaving);
                com.Parameters.AddWithValue("@Customer_id", Cust.Cus_Ref);
                com.Parameters.AddWithValue("@No_Guests", No_Guests);
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

        public void SelectCus()
        {
            
            SqlConnection con = ADDBookFacade.Connect();
            try
            {
                SqlCommand com = new SqlCommand("SELECT Cus_Ref FROM Customer WHERE Cus_Address=@Cus_Address AND Cus_Name=@Cus_Name");
                com.Parameters.AddWithValue("@Cus_Address", Cust.Cus_Address);
                com.Parameters.AddWithValue("@Cus_Name", Cust.Cus_Name);
                com.CommandType = System.Data.CommandType.Text;
                com.Connection = con;
                con.Open();
                SqlDataReader Cus_Ref_rdr = com.ExecuteReader();
                //read the cus ref               
                while (Cus_Ref_rdr.Read())
                {
                    this.Cust.Cus_Ref = Convert.ToInt32(Cus_Ref_rdr["Cus_Ref"]);
                }
                Cus_Ref_rdr.Close();
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
        public void AmendBook()
        {

            SqlConnection con = ADDBookFacade.Connect();
            try
            {
                SqlCommand com = new SqlCommand("UPDATE Booking SET Booking_Date=@Booking_Date, Date_Leaving=@Booking_Leave_Date, Customer_id=@Cus_Ref WHERE Customer_id=@Cus_Ref");
                com.Parameters.AddWithValue("@Cus_Ref", Cust.Cus_Ref);
                com.Parameters.AddWithValue("@Booking_Date", Booking_Date);
                com.Parameters.AddWithValue("@Booking_Leave_Date", Date_Leaving);
                com.CommandType = System.Data.CommandType.Text;
                com.Connection = con;
                con.Open();
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

        public void DeleteBook()
        {
            SqlConnection con = ADDBookFacade.Connect();
            try
            {

                SqlCommand com = new SqlCommand("DELETE FROM Extra WHERE Booking_id=@DELEXTRA_Booking_Ref");
                com.Parameters.AddWithValue("@DELEXTRA_Booking_Ref", Booking_Ref);
                com.CommandType = System.Data.CommandType.Text;
                com.Connection = con;
                con.Open();
                com.ExecuteNonQuery();

                string DelGuest = "DELETE FROM Guest_Table WHERE Booking_id=@DELGUEST_Booking_Ref";
                com.CommandText = DelGuest;
                com.Parameters.AddWithValue("@DELGUEST_Booking_Ref", Booking_Ref);
                com.ExecuteNonQuery();

                string DelBooking = "DELETE FROM Booking WHERE Customer_id = @Cus_Ref AND Booking_Ref = @Booking_Ref";
                com.CommandText = DelBooking;
                com.Parameters.AddWithValue("@Cus_Ref", Cust.Cus_Ref);
                com.Parameters.AddWithValue("@Booking_Ref", Booking_Ref);
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

    }
}
