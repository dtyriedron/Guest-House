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
        public string Cus_Ref_Search = "";
        public ADDBooking()
        {
            InitializeComponent();
        }

        private void SAVE_btn_Click(object sender, RoutedEventArgs e)
        {
            //saves progress and takes you to the next window
            SqlConnection con =
            new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\sampledatabase.mdf; Integrated Security = True; Connect Timeout = 30");

            SqlCommand com = new SqlCommand("SELECT Cus_Ref, Cus_Name, Cus_Address FROM Customer WHERE Cus_Address=@Cus_Address AND Cus_Name=@Cus_Name");

            string nextquery = "INSERT INTO Booking (Booking_Date, Date_Leaving, Customer_id) VALUES (@Booking_Date, @Booking_Leave_Date, @Cus_Ref)";

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

            com.CommandText = nextquery;
            com.Parameters.AddWithValue("@Cus_Ref", Cus_Ref_Search);
            com.Parameters.AddWithValue("@Booking_Date", Booking_Date_txtbx.Text);
            com.Parameters.AddWithValue("@Booking_Leave_Date", Booking_Leave_Date_txtbx.Text);

            int ralf = com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(ralf.ToString());

        }
    }
}
