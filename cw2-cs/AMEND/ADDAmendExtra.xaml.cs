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
    /// Interaction logic for ADDAmendExtra.xaml
    /// </summary>
    public partial class ADDAmendExtra : Window
    {
        //connect to the db
        ConnectionFacade ADDAmendExtraFacade = new ConnectionFacade();
        //set up string for booking ref search
        public string Book_Ref_Search = "";
        public string Cus_Ref_Search = "";

        public ADDAmendExtra()
        {
            InitializeComponent();
        }
         private void Search_btn_Click(object sender, RoutedEventArgs e)
        {
            //make new db connection
            SqlConnection con = ADDAmendExtraFacade.Connect();

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

            //make all the Search bit invisable
            Cus_Name_lbl.Visibility = System.Windows.Visibility.Hidden;
            Cus_Name_txtbx.Visibility = System.Windows.Visibility.Hidden;
            Cus_Address_lbl.Visibility = System.Windows.Visibility.Hidden;
            Cus_Address_txtbx.Visibility = System.Windows.Visibility.Hidden;
            Booking_Date_lbl.Visibility = System.Windows.Visibility.Hidden;
            Booking_Date_txtbx.Visibility = System.Windows.Visibility.Hidden;
            Booking_Leave_Date_lbl.Visibility = System.Windows.Visibility.Hidden;
            Booking_Leave_Date_txtbx.Visibility = System.Windows.Visibility.Hidden;
            Search_btn.Visibility = System.Windows.Visibility.Hidden;

            //make all the extras visable
            Amend_Car_Hire_lbl.Visibility = System.Windows.Visibility.Visible;
            Amend_Car_Hire_txtbx.Visibility = System.Windows.Visibility.Visible;
            Amend_Car_Hire_Start_Date_lbl.Visibility = System.Windows.Visibility.Visible;
            Amend_Car_Hire_Start_Date_txtbx.Visibility = System.Windows.Visibility.Visible;
            Amend_Car_Hire_End_Date_lbl.Visibility = System.Windows.Visibility.Visible;
            Amend_Car_Hire_End_Date_txtbx.Visibility = System.Windows.Visibility.Visible;
            Amend_Car_Hire_Driver_Name_lbl.Visibility = System.Windows.Visibility.Visible;
            Amend_Car_Hire_Driver_Name_txtbx.Visibility = System.Windows.Visibility.Visible;
            Amend_Dinner_lbl.Visibility = System.Windows.Visibility.Visible;
            Amend_Dinner_txtbx.Visibility = System.Windows.Visibility.Visible;
            Amend_Breakfast_lbl.Visibility = System.Windows.Visibility.Visible;
            Amend_Breakfast_txtbx.Visibility = System.Windows.Visibility.Visible;
            Amend_Dietry_Requirements_lbl.Visibility = System.Windows.Visibility.Visible;
            Amend_Dietry_Requirements_txtbx.Visibility = System.Windows.Visibility.Visible;
            SAVE_btn.Visibility = System.Windows.Visibility.Visible;
            con.Close();

        }

        private void SAVE_btn_Click(object sender, RoutedEventArgs e)
        {
            //make new db connection
            SqlConnection con = ADDAmendExtraFacade.Connect();


            SqlCommand com = new SqlCommand("UPDATE Extra SET Breakfast_No_Days=@Breakfast_No_Days, Dinner_No_Days=@Dinner_No_Days, Car_Hire_No_Days=@Car_Hire_No_Days, Car_Driver=@Driver_Name, Car_Hire_Start_Date=@Start_Date, Car_Hire_End_Date=@End_Date, Dietry_Requirements=@Dietry_Requirements WHERE Booking_id=@Book_Ref_Search");
            com.Parameters.AddWithValue("@Book_Ref_Search", Book_Ref_Search);
            com.Parameters.AddWithValue("@Driver_Name", Amend_Car_Hire_Driver_Name_txtbx.Text);
            com.Parameters.AddWithValue("@Start_Date", Amend_Car_Hire_Start_Date_txtbx.Text);
            com.Parameters.AddWithValue("@End_Date", Amend_Car_Hire_End_Date_txtbx.Text);
            com.Parameters.AddWithValue("@Dietry_Requirements", Amend_Dietry_Requirements_txtbx.Text);
            com.Parameters.AddWithValue("@Breakfast_No_Days", Amend_Breakfast_txtbx.Text);
            com.Parameters.AddWithValue("@Dinner_No_Days", Amend_Dinner_txtbx.Text);
            com.Parameters.AddWithValue("@Car_Hire_No_Days", Amend_Car_Hire_txtbx.Text);


            com.CommandType = System.Data.CommandType.Text;
            com.Connection = con;
            con.Open();
            //execute the new query
            com.ExecuteNonQuery();
            con.Close();

            
        }

       
    }
}
