using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace cw2_cs
{
    class Extra
    {
        
        private Booking book;
        private string driver_name;
        private DateTime start_date;
        private DateTime end_date;
        private string dietry_requirements;
        private int breakfast_no_days;
        private int dinner_no_days;
        private int car_hire_no_days;
        ConnectionFacade ADDExtraFacade = new ConnectionFacade();

        public Booking Book
        {
            get
            {
                return book;
            }
            set
            {
                book = value;
            }
        }

        public string Driver_Name
        {
            get
            {
                return driver_name;
            }
            set
            {
                driver_name = value;
            }
        }

        public DateTime Start_Date
        {
            get
            {
                return start_date;
            }
            set
            {
                start_date = value;
            }
        }

        public DateTime End_Date
        {
            get
            {
                return end_date;
            }
            set
            {
                end_date = value;
            }
        }

        public string Dietry_Requirements
        {
            get
            {
                return dietry_requirements;
            }
            set
            {
                dietry_requirements = value;
            }
        }

        public int Breakfast_No_Days
        {
            get
            {
                return breakfast_no_days;
            }
            set
            {
                breakfast_no_days = value;
            }
        }

        public int Dinner_No_Days
        {
            get
            {
                return dinner_no_days;
            }
            set
            {
                dinner_no_days = value;
            }
        }

        public int Car_Hire_No_Days
        {
            get
            {
                return car_hire_no_days;
            }
            set
            {
                car_hire_no_days = value;
            }
        }

        public void InsertExtra()
        {
            SqlConnection con = ADDExtraFacade.Connect();

            try
            {
                SqlCommand com = new SqlCommand("INSERT INTO Extra VALUES (@Booking_id, @Breakfast_No_Days, @Dinner_No_Days,@Car_Hire_No_Days, @Start_Date, @End_Date,@Driver_Name, @Dietry_Requirements)");
                com.Parameters.AddWithValue("@Booking_id", Book.Booking_Ref);
                com.Parameters.AddWithValue("@Driver_Name", Driver_Name);
                com.Parameters.AddWithValue("@Start_Date", Start_Date);
                com.Parameters.AddWithValue("@End_Date", End_Date);
                com.Parameters.AddWithValue("@Dietry_Requirements", Dietry_Requirements);
                com.Parameters.AddWithValue("@Breakfast_No_Days", Breakfast_No_Days);
                com.Parameters.AddWithValue("@Dinner_No_Days", Dinner_No_Days);
                com.Parameters.AddWithValue("@Car_Hire_No_Days", Car_Hire_No_Days);

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
        public void SelectBooking()
        {
            SqlConnection con = ADDExtraFacade.Connect();
            try
            {
                //Cust.SelectCus();
                SqlCommand com = new SqlCommand("SELECT Booking_Ref FROM Booking WHERE Booking_Date=@Booking_Date AND Date_Leaving=@Date_Leaving AND Customer_id=@Customer_id");
                com.Parameters.AddWithValue("@Booking_Date", Book.Booking_Date);
                com.Parameters.AddWithValue("@Date_Leaving", Book.Date_Leaving);
                com.Parameters.AddWithValue("@Customer_id", Book.Cust.Cus_Ref);
                com.CommandType = System.Data.CommandType.Text;
                com.Connection = con;
                con.Open();
                //read the book ref
                SqlDataReader Book_Ref_rdr = com.ExecuteReader();
                while (Book_Ref_rdr.Read())
                {
                    this.Book.Booking_Ref = Convert.ToInt32(Book_Ref_rdr["Booking_Ref"]);
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
    }
}
