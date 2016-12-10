using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace cw2_cs
{
    class Guest
    {
        private string guest_name;
        private int guest_pass_num;
        private int gus_age;
        ConnectionFacade ADDGuestFacade = new ConnectionFacade();
        private Customer cust;
        private Booking book;


        public string Guest_Name
        {
            get
            {
                return guest_name;
            }

            set
            {
                //show error
                guest_name = value;
            }
        }

        public int Guest_Pass_Num
        {
            get
            {
                return guest_pass_num;
            }
            set
            {
                //error
                guest_pass_num = value;
            }
        }

        public int Gus_Age
        {
            get
            {
                return gus_age;
            }
            set
            {
                gus_age = value;
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

        public void InsertGuest()
        {
            SqlConnection con = ADDGuestFacade.Connect();

            try
            {
                SqlCommand com = new SqlCommand("INSERT INTO Guest_Table VALUES (@Guest_Pass_Num, @Guest_Name, @Gus_Age, @Booking_id)");
                com.Parameters.AddWithValue("@Guest_Name", Guest_Name);
                com.Parameters.AddWithValue("@Gus_Age", Gus_Age);
                com.Parameters.AddWithValue("@Guest_Pass_Num", Guest_Pass_Num);
                com.Parameters.AddWithValue("@Booking_id", Book.Booking_Ref);
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
