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
            DELBooking DELbookingWindow = new DELBooking();
            DELbookingWindow.ShowDialog();
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
            ADDAmendCus amendWindow = new ADDAmendCus();
            amendWindow.ShowDialog();
        }

        private void ADD_Guest_btn_Click(object sender, RoutedEventArgs e)
        {
            ADDGuest GuestWindow = new ADDGuest();
            GuestWindow.ShowDialog();
        }

        private void Amend_Guest_btn_Click(object sender, RoutedEventArgs e)
        {
            ADDAmendGuest AmendGuestWindow = new ADDAmendGuest();
            AmendGuestWindow.ShowDialog();
        }

        private void Delete_Cus_btn_Click(object sender, RoutedEventArgs e)
        {
            DELCustomer DELCustomerWindow = new DELCustomer();
            DELCustomerWindow.ShowDialog();
        }

        private void Delete_Guest_btn_Click(object sender, RoutedEventArgs e)
        {
            DELGuest DELGuestWindow = new DELGuest();
            DELGuestWindow.ShowDialog();
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
