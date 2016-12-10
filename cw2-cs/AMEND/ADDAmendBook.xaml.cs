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
    /// Interaction logic for ADDAmendBook.xaml
    /// </summary>
    public partial class ADDAmendBook : Window
    {
        public int Cus_Ref_Search = 0;
        public int Book_Ref_Search = 0;
        ConnectionFacade AmendBookFacade = new ConnectionFacade();
        public ADDAmendBook()
        {
            InitializeComponent();
        }

        private void SAVE_btn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = AmendBookFacade.Connect();

            Customer c1 = new Customer();
            c1.Cus_Address = Cus_Address_txtbx.Text;
            c1.Cus_Name = Cus_Name_txtbx.Text;
            c1.Cus_Ref = Cus_Ref_Search;


            Booking b1 = new Booking();
            b1.Booking_Date = Amend_Booking_Date_txtbx.Text;
            b1.Date_Leaving = Amend_Booking_Leave_Date_txtbx.Text;
            b1.Cust = c1;
            b1.Booking_Ref = Book_Ref_Search;

            try
            {
                c1.SelectCus();
                b1.SelectCus();
                b1.SelectBooking();
                b1.AmendBook();
            }
            catch(SqlException except)
            {
                MessageBox.Show(except.Message);
            }


        }
    }
}
