using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace cw2_cs
{
    /// <summary>
    /// Interaction logic for DELExtra.xaml
    /// </summary>
    public partial class DELExtra : Window
    {
        //connect to the db
        ConnectionFacade DELExtraFacade = new ConnectionFacade();
        //set up string for booking ref search
        public string Book_Ref_Search = "";
        public string Cus_Ref_Search = "";

        public DELExtra()
        {
            InitializeComponent();
        }

        private void Search_btn_Click(object sender, RoutedEventArgs e)
        {
            //make new db connection
            SqlConnection con = DELExtraFacade.Connect();

            //make new command which will help to check if the values for the customer name and the customer address are correct
            SqlCommand com = new SqlCommand("SELECT Cus_Ref, Cus_Name, Cus_Address FROM Customer WHERE Cus_Address=@Cus_Address AND Cus_Name=@Cus_Name");
            com.Parameters.AddWithValue("@Cus_Address", Cus_Address_txtbx.Text);
            com.Parameters.AddWithValue("@Cus_Name", Cus_Name_txtbx.Text);

            com.CommandType = System.Data.CommandType.Text;
            com.Connection = con;
            con.Open();
            //read the cus ref
            SqlDataReader Cus_Ref_rdr = com.ExecuteReader();
            while (Cus_Ref_rdr.Read())
            {
                Cus_Ref_Search = Cus_Ref_rdr["Cus_Ref"].ToString();
            }
            Cus_Ref_rdr.Close();
            //show the cus ref
            MessageBox.Show("Cus ref= " + Cus_Ref_Search);

            //make new command which will help to check if the values for the boooking are correct
            string SELECTQuery = "SELECT Booking_Date, Date_Leaving, BookingRef FROM Booking WHERE Booking_Date=@SELECT_Booking_Date AND Date_Leaving=@SELECT_Booking_Leave_Date AND Customer_id=@SELECT_Cus_Ref";
            com.CommandText = SELECTQuery;
            com.Parameters.AddWithValue("@SELECT_Booking_Date", Booking_Date_txtbx.Text);
            com.Parameters.AddWithValue("@SELECT_Booking_Leave_Date", Booking_Leave_Date_txtbx.Text);
            com.Parameters.AddWithValue("@SELECT_Cus_Ref", Cus_Ref_Search);

            com.CommandType = System.Data.CommandType.Text;
            com.Connection = con;
            //read the Book ref
            SqlDataReader Book_Ref_rdr = com.ExecuteReader();
            while (Book_Ref_rdr.Read())
            {
                Book_Ref_Search = Book_Ref_rdr["BookingRef"].ToString();
            }
            Book_Ref_rdr.Close();
            //show the Book ref
            MessageBox.Show("Book ref= " + Book_Ref_Search);

            string DELExtraQuery = "DELETE FROM Extra WHERE Booking_id=@Booking_id";
            com.CommandText = DELExtraQuery;
            com.Parameters.AddWithValue("@Booking_id", Book_Ref_Search);
            
            com.CommandType = System.Data.CommandType.Text;
            com.Connection = con;
            //execute the new query
            com.ExecuteNonQuery();
            con.Close();

        }
    }
}
