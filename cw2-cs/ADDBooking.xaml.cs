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
        public ADDBooking()
        {
            InitializeComponent();
        }

        private void Booking_Date_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            //this updates or creates a booking date that is linked to the booking_id and the customer_id
        }

        private void Booking_Leave_Date_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            //this uodates or creates a booking_leave_date which is liked to the customer and booking ids
        }

        private void Car_Hire_cmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //this should show you all the number of days available to you to book a car which is calculated by subtracting the booking_leave_date with the booking_date
        }

        private void SAVE_btn_Click(object sender, RoutedEventArgs e)
        {
            //saves progress and takes you to the next window
            SqlConnection con =
                new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\dtd2509\Documents\Visual Studio 2015\Projects\cw2-csharp-db\cw2-csharp-db\sampledatabase.mdf; Integrated Security = True; Connect Timeout = 30");
            
            SqlCommand com = new SqlCommand("INSERT INTO Booking (Booking_Date, Date_Leaving) VALUES (@Booking_Date,@Booking_Leave_Date)");
            com.CommandType = System.Data.CommandType.Text;
            com.Connection = con;
            com.Parameters.AddWithValue("@Booking_Date", Booking_Date_txtbx.Text);
            com.Parameters.AddWithValue("@Booking_Leave_Date", Booking_Leave_Date_txtbx.Text);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        
            
        

    }
}
