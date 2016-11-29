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
    /// Interaction logic for ADDGuest.xaml
    /// </summary>
    public partial class ADDGuest : Window
    {
        public string Cus_Ref_Search = "";
        public string Book_Ref_Search = "";

        SqlConnection con =
            new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\sampledatabase.mdf; Integrated Security = True; Connect Timeout = 30");
        public ADDGuest()
        {
           InitializeComponent();
        }

        private void SAVE_btn_Click(object sender, RoutedEventArgs e)
        {
            //saves progress and takes you to the next window
            SqlCommand com = new SqlCommand("SELECT Cus_Ref, Cus_Name, Cus_Address FROM Customer WHERE Cus_Address=@Cus_Address AND Cus_Name=@Cus_Name");

            string query1 = "SELECT BookingRef, Booking_Date, Date_Leaving FROM Booking WHERE Booking_Date=@Booking_Date AND Date_Leaving=@Booking_Leave_Date";

            string query2 = "INSERT INTO Guest_Table (Guest_Pass_Num,Guest_Name,Gus_Age, Booking_id, Customer_id) VALUES (@Guest_Pass_Num,@Guest_Name,@Gus_Age, @BookingRef, @Cus_Ref)";

            com.Parameters.AddWithValue("@Cus_Address", Cus_Address_txtbx.Text);
            com.Parameters.AddWithValue("@Cus_Name", Cus_Name_txtbx.Text);

            com.CommandType = System.Data.CommandType.Text;
            com.Connection = con;

            con.Open();
            SqlDataReader rdr = com.ExecuteReader();
            while (rdr.Read())
            {
                Cus_Ref_Search = rdr["Cus_Ref"].ToString();
            }
            rdr.Close();
            MessageBox.Show(Cus_Ref_Search);

            com.CommandText = query1;
            com.Parameters.AddWithValue("@Booking_Date", Booking_Date_txtbx.Text);
            com.Parameters.AddWithValue("@Booking_Leave_Date", Booking_Leave_Date_txtbx.Text);

            SqlDataReader rdr2 = com.ExecuteReader();
            while (rdr2.Read())
            {
                Book_Ref_Search = rdr2["BookingRef"].ToString();
            }
            rdr2.Close();
            MessageBox.Show(Book_Ref_Search);

            com.CommandText = query2;
            com.Parameters.AddWithValue("@Cus_Ref", Cus_Ref_Search);
            com.Parameters.AddWithValue("@BookingRef", Book_Ref_Search);
            com.Parameters.AddWithValue("@Guest_Pass_Num", Gus_Pass_Num_txtbx.Text);
            com.Parameters.AddWithValue("@Guest_Name", Gus_Name_txtbx.Text);
            com.Parameters.AddWithValue("@Gus_Age", Gus_Age_txtbx.Text);


            int ralf = com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(ralf.ToString());
        }
    }
}
