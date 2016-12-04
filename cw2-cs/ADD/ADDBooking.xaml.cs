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
    /// Interaction logic for ADDBooking.xaml
    /// </summary>
    public partial class ADDBooking : Window
    {
        //set up string for cus ref search
        public string Cus_Ref_Search = "";
        //set up string for booking ref search
        public string Book_Ref_Search = "";
        //set up string for number of guests
        public int Guest_No = 0;
        //set up the search for guest_no
        public string Guest_No_Search = "";
        //set up extra
        private bool buttonWasClicked = false;

        //connect to the db
        ConnectionFacade ADDBookFacade = new ConnectionFacade();

        public ADDBooking()
        {
            InitializeComponent();
        }

        private void Extra_btn_Click(object sender, RoutedEventArgs e)
        {
            buttonWasClicked = true;
        }

        private void No_Guests_cmbobx_Loaded(object sender, RoutedEventArgs e)
        {
            for (int ANumber = 0; ANumber < 5; ANumber++)
            {
                No_Guests_cmbobx.Items.Add(ANumber);
            }

        }

        //saves progress and takes you to the next window
        private void SAVE_btn_Click(object sender, RoutedEventArgs e)
        {

            //make new db connection
            SqlConnection con = ADDBookFacade.Connect();

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




            //save all the entered values for a booking into the db
            string INSERT_BOOK_Query = "INSERT INTO Booking (Booking_Date, Date_Leaving, Customer_id, No_Guests) VALUES (@Booking_Date, @Booking_Leave_Date, @Cus_Ref, @No_Guests)";
            //change the text of the command so there can be a new query
            com.CommandText = INSERT_BOOK_Query;
            com.Parameters.AddWithValue("@Cus_Ref", Cus_Ref_Search);
            com.Parameters.AddWithValue("@Booking_Date", Booking_Date_txtbx.Text);
            com.Parameters.AddWithValue("@Booking_Leave_Date", Booking_Leave_Date_txtbx.Text);
            com.Parameters.AddWithValue("@No_Guests", No_Guests_cmbobx.SelectedValue);
            //execute the new query
            com.ExecuteNonQuery();

            //save all the entered values for a booking into the db
            string SELECT_BOOK_Query = "SELECT Booking_Date, Date_Leaving, BookingRef, No_Guests FROM Booking WHERE Booking_Date=@SELECT_Booking_Date AND Date_Leaving=@SELECT_Booking_Leave_Date AND Customer_id=@SELECT_Cus_Ref AND No_Guests=@SELECT_No_Guests";
            //change the text of the command so there can be a new query
            com.CommandText = SELECT_BOOK_Query;
            com.Parameters.AddWithValue("@SELECT_Cus_Ref", Cus_Ref_Search);
            com.Parameters.AddWithValue("@SELECT_Booking_Date", Booking_Date_txtbx.Text);
            com.Parameters.AddWithValue("@SELECT_Booking_Leave_Date", Booking_Leave_Date_txtbx.Text);
            com.Parameters.AddWithValue("@SELECT_No_Guests", No_Guests_cmbobx.SelectedValue);

            //read the variables need from booking
            SqlDataReader Book_rdr = com.ExecuteReader();
            while (Book_rdr.Read())
            {
                Book_Ref_Search = Book_rdr["BookingRef"].ToString();
                Guest_No_Search = Book_rdr["No_Guests"].ToString();
            }
            Book_rdr.Close();
            //show the booking ref
            MessageBox.Show("Booking ref= " + Book_Ref_Search);
            //show the Guest_No
            MessageBox.Show("Guest_No= " + Guest_No_Search);

            //allow the user to save all the guests to the db
            for (int i = 0; i < Int32.Parse(Guest_No_Search); i++)
            {
                ADDGuest GuestWindow = new ADDGuest();
                GuestWindow.ShowDialog();
            }

            if(buttonWasClicked)
            {
             

                //make all the booking bit invisable
                Extra_btn.Visibility = System.Windows.Visibility.Hidden;
                Cus_Name_lbl.Visibility = System.Windows.Visibility.Hidden;
                Cus_Name_txtbx.Visibility = System.Windows.Visibility.Hidden;
                Cus_Address_lbl.Visibility = System.Windows.Visibility.Hidden;
                Cus_Address_txtbx.Visibility = System.Windows.Visibility.Hidden;
                Booking_Date_lbl.Visibility = System.Windows.Visibility.Hidden;
                Booking_Date_txtbx.Visibility = System.Windows.Visibility.Hidden;
                Booking_Leave_Date_lbl.Visibility = System.Windows.Visibility.Hidden;
                Booking_Leave_Date_txtbx.Visibility = System.Windows.Visibility.Hidden;
                No_Guests_lbl.Visibility = System.Windows.Visibility.Hidden;
                No_Guests_cmbobx.Visibility = System.Windows.Visibility.Hidden;
                SAVE_btn.Visibility = System.Windows.Visibility.Hidden;

                //make all the extras visable
                Car_Hire_lbl.Visibility = System.Windows.Visibility.Visible;
                Car_Hire_txtbx.Visibility = System.Windows.Visibility.Visible;
                Car_Hire_Start_Date_lbl.Visibility = System.Windows.Visibility.Visible;
                Car_Hire_Start_Date_txtbx.Visibility = System.Windows.Visibility.Visible;
                Car_Hire_End_Date_lbl.Visibility = System.Windows.Visibility.Visible;
                Car_Hire_End_Date_txtbx.Visibility = System.Windows.Visibility.Visible;
                Car_Hire_Driver_Name_lbl.Visibility = System.Windows.Visibility.Visible;
                Car_Hire_Driver_Name_txtbx.Visibility = System.Windows.Visibility.Visible;
                Dinner_lbl.Visibility = System.Windows.Visibility.Visible;
                Dinner_txtbx.Visibility = System.Windows.Visibility.Visible;
                Breakfast_lbl.Visibility = System.Windows.Visibility.Visible;
                Breakfast_txtbx.Visibility = System.Windows.Visibility.Visible;
                Dietry_Requirements_lbl.Visibility = System.Windows.Visibility.Visible;
                Dietry_Requirements_txtbx.Visibility = System.Windows.Visibility.Visible;
                SAVE_EXTRA_btn.Visibility = System.Windows.Visibility.Visible;


            }
            con.Close();

        }

        private void SAVE_EXTRA_btn_Click(object sender, RoutedEventArgs e)
        {
            
            //make new db connection
            SqlConnection con = ADDBookFacade.Connect();

            //save all the entered values for a booking into the db
            SqlCommand com = new SqlCommand("INSERT INTO Extra (Booking_id,Breakfast_No_Days,Dinner_No_Days, Car_Hire_No_Days, Car_Driver, Car_Hire_Start_Date, Car_Hire_End_Date, Dietry_Requirements) VALUES (@Book_Ref_Search, @Breakfast_No_Days, @Dinner_No_Days, @Car_Hire_No_Days, @Driver_Name, @Start_Date, @End_Date, @Dietry_Requirements)");
            com.CommandType = System.Data.CommandType.Text;
            com.Connection = con;
            con.Open();
            com.Parameters.AddWithValue("@Book_Ref_Search", Book_Ref_Search);
            com.Parameters.AddWithValue("@Driver_Name", Car_Hire_Driver_Name_txtbx.Text);
            com.Parameters.AddWithValue("@Start_Date", Car_Hire_Start_Date_txtbx.Text);
            com.Parameters.AddWithValue("@End_Date", Car_Hire_End_Date_txtbx.Text);
            com.Parameters.AddWithValue("@Dietry_Requirements", Dietry_Requirements_txtbx.Text);
            com.Parameters.AddWithValue("@Breakfast_No_Days", Breakfast_txtbx.Text);
            com.Parameters.AddWithValue("@Dinner_No_Days", Dinner_txtbx.Text);
            com.Parameters.AddWithValue("@Car_Hire_No_Days", Car_Hire_txtbx.Text);
            //execute the new query
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}
