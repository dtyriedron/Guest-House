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
        public int Cus_Ref_Search = 0;
        public int Book_Ref_Search = 0;

        ConnectionFacade ADDGuestFacade = new ConnectionFacade();
        public ADDGuest()
        {
           InitializeComponent();
        }

        //saves progress and takes you to the next window
        private void SAVE_btn_Click(object sender, RoutedEventArgs e)
        {
            
            SqlConnection con = ADDGuestFacade.Connect();

            Customer c1 = new Customer();
            c1.Cus_Address = Cus_Address_txtbx.Text;
            c1.Cus_Name = Cus_Name_txtbx.Text;
            c1.Cus_Ref = Cus_Ref_Search;

            Booking b1 = new Booking();
            b1.Booking_Date = Booking_Date_txtbx.Text;
            b1.Date_Leaving = Booking_Leave_Date_txtbx.Text;
            b1.Booking_Ref = Book_Ref_Search;
            b1.Cust = c1;

            Guest g1 = new Guest();
            g1.Guest_Name = Gus_Name_txtbx.Text;
            g1.Gus_Age = Convert.ToInt32(Gus_Age_txtbx.Text);
            g1.Guest_Pass_Num = Convert.ToInt32(Gus_Pass_Num_txtbx.Text);
            g1.Cust = c1;
            g1.Book = b1;

            try
            {
                c1.SelectCus();
                b1.SelectCus();
                b1.SelectBooking();
                g1.InsertGuest();
            }
            catch(SqlException except)
            {
                MessageBox.Show(except.Message);
            }

            finally
            {
                con.Close();
            }
           
        }
    }
}
