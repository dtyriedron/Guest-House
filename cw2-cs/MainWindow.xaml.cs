using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace cw2_cs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\dtd2509\Documents\Visual Studio 2015\Projects\cw2-csharp-db\cw2-csharp-db\sampledatabase.mdf; Integrated Security = True; Connect Timeout = 30");
            con.Open();
            SqlCommand com = new SqlCommand(
                "SELECT * FROM Booking", con);

            Console.ReadLine();

            InitializeComponent();
        }

        private void ADD_Booking_btn_Click(object sender, RoutedEventArgs e)
        {
            ADDBooking bookingWindow = new ADDBooking();
            bookingWindow.ShowDialog();
            //this creates a booking_id and also goes to the addbooking window
        }

        private void DELETE_Booking_btn_Click(object sender, RoutedEventArgs e)
        {
            //this completely removes the booking, this should have a check built in so that the user does not remove the booking by mistake
        }

        private void AMEND_Booking_btn_Click(object sender, RoutedEventArgs e)
        {
            ADDAmendBook Amendbook = new ADDAmendBook();
            Amendbook.ShowDialog();
            //this should allow the user to edit the booking by redirecting to the addbooking window and editing any fields there
        }

        private void INVOICE_btn_Click(object sender, RoutedEventArgs e)
        {
            //this should show the total cost of the booking in a newe invoice window
        }

        private void ADD_Customer_btn_Click(object sender, RoutedEventArgs e)
        {
            ADDCustomer customerWindow = new ADDCustomer();
            customerWindow.ShowDialog();
            //this will start a new customer window
        }

        private void Amend_Customer_btn_Click(object sender, RoutedEventArgs e)
        {
            ADDAmend amendWindow = new ADDAmend();
            amendWindow.ShowDialog();
        }




        /*
        holidayCost(int nights, int Age, int  extras)
        {
            int childCost =30;
            int adultCost =50;
            
            if (Age <19)
            {
               // childCost* nights*extras;
            }
            else
            {
                //adultCost*nights*extras;
            }

        }

       // calextras()
        //{

        //}
        */

    }
}
