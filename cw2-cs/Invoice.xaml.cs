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
        public int TCost = 0;
        public int VAR_Gus_Age = 0;
        public int VAR_Dinner = 0;
        public int Dinner_Cost = 15;
        public int VAR_Breakfast = 0;
        public int Breakfast_Cost = 5;
        public int VAR_Car_Hire = 0;
        public int Car_Hire_Cost = 50;
        public int VAR_Guests = 0;
        DateTime startDate;
        DateTime endDate;

        public Invoice()
        {
            InitializeComponent();
        }

        private void SEARCH_btn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = InvoiceFacade.Connect();

            SqlCommand com = new SqlCommand("SELECT Cus_Ref, Cus_Name, Cus_Address FROM Customer WHERE Cus_Address=@Cus_Address AND Cus_Name=@Cus_Name");
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

            string query1 = "SELECT Booking_Date, Date_Leaving, BookingRef FROM Booking WHERE Booking_Date=@SELECT_Booking_Date AND Date_Leaving=@SELECT_Date_Leaving";
            com.CommandText = query1;
            com.Parameters.AddWithValue("@SELECT_Booking_Date", Booking_Date_txtbx.Text);
            com.Parameters.AddWithValue("@SELECT_Date_Leaving", Booking_Leave_Date_txtbx.Text);
            SqlDataReader rdr2 = com.ExecuteReader();
            while (rdr2.Read())
            {
                Book_Ref_Search = rdr2["BookingRef"].ToString();
            }
            rdr2.Close();
            MessageBox.Show(Book_Ref_Search);
            
           

            com.ExecuteNonQuery();
        }

        private void SAVE_btn_Click(object sender, RoutedEventArgs e)
        {
            

            

            SqlCommand com = new SqlCommand("SELECT Booking_Date, Date_Leaving, No_Guests FROM Booking WHERE BookingRef=@Book_Ref_Search");
            com.Parameters.AddWithValue("@Book_Ref_Search", Book_Ref_Search);
            SqlConnection con = InvoiceFacade.Connect();
            com.CommandType = System.Data.CommandType.Text;
            com.Connection = con;
            con.Open();

          

            
            SqlDataReader rdr1 = com.ExecuteReader();
            while (rdr1.Read())
            { 
                startDate = Convert.ToDateTime(rdr1["Booking_Date"]);
                endDate = Convert.ToDateTime(rdr1["Date_Leaving"]);
                VAR_Guests = Convert.ToInt32(rdr1["No_Guests"]);

            }
            rdr1.Close();
            int nights = (endDate - startDate).Days;

            //case when person is under 18
            string SELECTGus_Age = "SELECT Gus_Age FROM Guest_Table WHERE Booking_id=@AGESEARCH_Booking_id";
            com.CommandText = SELECTGus_Age;
            com.Parameters.AddWithValue("@AGESEARCH_Booking_id", Book_Ref_Search);


            
            SqlDataReader rdr2 = com.ExecuteReader();
            while (rdr2.Read())
            {
               
                if (Convert.ToInt32(rdr2["Gus_Age"]) < 18)
                {
                    //charge less
                   TCost += (30 * nights);
                }
                else
                {
                    //charge normal
                    TCost += (50 * nights);
                }

            }
            rdr2.Close();
            


            string ExtraQuery = "SELECT Dinner_No_Days, Breakfast_No_Days, Car_Hire_No_Days FROM Extra WHERE Booking_id=@EXTRASEARCH_Booking_id";
            com.CommandText = ExtraQuery;

            com.Parameters.AddWithValue("@EXTRASEARCH_Booking_id", Book_Ref_Search);
            SqlDataReader Extra_rdr = com.ExecuteReader();
            while (Extra_rdr.Read())
            {
                
                VAR_Breakfast = Convert.ToInt32(Extra_rdr["Breakfast_No_Days"]);
                VAR_Dinner = Convert.ToInt32(Extra_rdr["Dinner_No_Days"]);
                VAR_Car_Hire = Convert.ToInt32(Extra_rdr["Car_Hire_No_Days"]);
            }
            Extra_rdr.Close();

            //................Totals.....................
            //add customer to no_guests to get total people
            VAR_Guests += 1;
            //add customer cost
            TCost += (50*nights);
            //case when person wants dinner
            //change price according to how many days they want dinner
            TCost += (VAR_Dinner*Dinner_Cost*VAR_Guests);
            //case when person wants breakfast
            //change price according to how many days they want breakfast
            TCost += (VAR_Breakfast*Breakfast_Cost*VAR_Guests);
            //case when person wants car hire
            //change price according to the number of days they want a car
            TCost += (VAR_Car_Hire*Car_Hire_Cost);

            INVOICE_PRINT_lbl.Content = TCost;

            

        }


    }
}
