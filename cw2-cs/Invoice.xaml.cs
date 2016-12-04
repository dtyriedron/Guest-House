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
    /// Interaction logic for Invoice.xaml
    /// </summary>
    public partial class Invoice : Window
    {
        ConnectionFacade InvoiceFacade = new ConnectionFacade();

        public string Cus_Ref_Search = "";
        public string Book_Ref_Search = "";
        public int VAR_Gus_Age = 0;

        public Invoice()
        {
            InitializeComponent();
        }

        private void SEARCH_btn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = InvoiceFacade.Connect();

            SqlCommand com = new SqlCommand("SELECT Cus_Ref, Cus_Name, Cus_Address FROM Customer WHERE Cus_Address=@Cus_Address AND Cus_Name=@Cus_Name");

            string query1 = "SELECT Booking_Date, Date_Leaving FROM Booking WHERE Booking_Date=@SELECT_Booking_Date AND Date_Leaving=@SELECT_Date_Leaving";

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
            SqlDataReader rdr2 = com.ExecuteReader();
            while (rdr2.Read())
            {
                Book_Ref_Search = rdr2["BookingRef"].ToString();
            }
            rdr2.Close();
            MessageBox.Show(Book_Ref_Search);
            com.Parameters.AddWithValue("@SELECT_Booking_Date", Booking_Date_txtbx.Text);
            com.Parameters.AddWithValue("@SELECT_Date_Leaving", Booking_Leave_Date_txtbx.Text);
            com.ExecuteNonQuery();
        }

        private void SAVE_btn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = InvoiceFacade.Connect();

            //case when person is under 18
            SqlCommand com = new SqlCommand("SELECT Gus_Age FROM Guest WHERE Booking_id=@AGESEARCH_Booking_id AND Gus_Age=@Gus_Age");

            com.Parameters.AddWithValue("@AGESEARCH_Booking_id", Book_Ref_Search);
            com.Parameters.AddWithValue("@Gus_Age", VAR_Gus_Age);

            if (VAR_Gus_Age > 18)
            {
                //charge extra
            }
            else
            {
                //charge normal
            }

            //change price 

            //case when person wants dinner
            //change price according to how many days they want dinner

            //case when person wants breakfast
            //change price according to how many days they want breakfast

            //case when person wants car hire
            //change price according to the number of days they want a car
        }

       
    }
}
