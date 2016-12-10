using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Configuration;

namespace cw2_cs
{
    /// <summary>
    /// Interaction logic for ADDCustomer.xaml
    /// </summary>
    public partial class ADDCustomer : Window
    {
        ConnectionFacade ADDCusFacade = new ConnectionFacade();

        public int Cus_Ref_Search = 0;
                
        public ADDCustomer()
        {
            InitializeComponent();
        }

        


        private void SAVE_btn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = ADDCusFacade.Connect();

            
            Customer c1 = new Customer();
            c1.Cus_Address = Cus_Address_txtbx.Text;
            c1.Cus_Name = Cus_Name_txtbx.Text;
            c1.Cus_Ref = Cus_Ref_Search;

            try
            {
                c1.InsertCus();
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
