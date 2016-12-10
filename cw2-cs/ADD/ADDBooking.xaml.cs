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
        public int Cus_Ref_Search = 0;
        //set up string for booking ref search
        public int Book_Ref_Search = 0;
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


            Customer c1 = new Customer();
            c1.Cus_Address = Cus_Address_txtbx.Text;
            c1.Cus_Name = Cus_Name_txtbx.Text;
            c1.Cus_Ref = Cus_Ref_Search;


            Booking b1 = new Booking();
            b1.Booking_Date = Booking_Date_txtbx.Text;
            b1.Date_Leaving = Booking_Leave_Date_txtbx.Text;
            b1.Cust = c1;
            b1.Booking_Ref = Book_Ref_Search;
            b1.No_Guests = Convert.ToInt32(No_Guests_cmbobx.SelectedValue);


            try
            {
                c1.SelectCus();
                b1.InsertBooking();
            }
            catch(SqlException except)
            {
                MessageBox.Show(except.Message);
            }
          
            finally
            {
                con.Close();
            }
            MessageBox.Show(c1.Cus_Ref.ToString());
            if (buttonWasClicked)
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

                MessageBox.Show("booking_ref "+ b1.Booking_Ref);

            }
            for (int i = 0; i < b1.No_Guests; i++)
            {
                ADDGuest GuestWindow = new ADDGuest();
                GuestWindow.ShowDialog();
            }
           


        }

        private void SAVE_EXTRA_btn_Click(object sender, RoutedEventArgs e)
        {
            //make new db connection
            SqlConnection con = ADDBookFacade.Connect();
            
            Customer c1 = new Customer();
            c1.Cus_Address = Cus_Address_txtbx.Text;
            c1.Cus_Name = Cus_Name_txtbx.Text;
            c1.Cus_Ref = Cus_Ref_Search;

            Booking b1 = new Booking();
            b1.Booking_Date = Booking_Date_txtbx.Text;
            b1.Date_Leaving = Booking_Leave_Date_txtbx.Text;
            b1.Cust = c1;
            b1.Booking_Ref = Book_Ref_Search;
            b1.No_Guests = Convert.ToInt32(No_Guests_cmbobx.SelectedValue);

            Extra e1 = new Extra();
            e1.Book = b1;
            e1.Breakfast_No_Days = Convert.ToInt32(Breakfast_txtbx.Text);
            e1.Dinner_No_Days = Convert.ToInt32(Dinner_txtbx.Text);
            e1.Car_Hire_No_Days = Convert.ToInt32(Car_Hire_txtbx.Text);
            e1.Driver_Name = Car_Hire_Driver_Name_txtbx.Text;
            e1.Start_Date = Convert.ToDateTime(Car_Hire_Start_Date_txtbx.Text);
            e1.End_Date = Convert.ToDateTime(Car_Hire_End_Date_txtbx.Text);
            e1.Dietry_Requirements = Dietry_Requirements_txtbx.Text;



            MessageBox.Show("book_ref " + Book_Ref_Search);
            try
            {
                c1.SelectCus();
                b1.SelectBooking();
                e1.InsertExtra();
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
