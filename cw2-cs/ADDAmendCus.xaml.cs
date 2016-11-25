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
    /// Interaction logic for ADDAmend.xaml
    /// </summary>
    public partial class ADDAmend : Window
    {
        public string Cus_Ref_Search = "";
        SqlConnection con =
           new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\sampledatabase.mdf; Integrated Security = True; Connect Timeout = 30");
        public ADDAmend()
        {
            InitializeComponent();
        }

        private void Search_btn_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand com = new SqlCommand("SELECT Cus_Address, Cus_Name, Cus_Ref FROM Customer WHERE Cus_Address=@Cus_Address AND Cus_Name= @Cus_Name");

            string address="";
            string name ="";
            com.CommandType = System.Data.CommandType.Text;
            com.Connection = con;
            com.Parameters.AddWithValue("@Cus_Address", Search_Cus_Address_txtbx.Text);
            com.Parameters.AddWithValue("@Cus_Name", Search_Cus_Name_txtbx.Text);
            con.Open();
            SqlDataReader rdr = com.ExecuteReader();
            while(rdr.Read())
            {
                Cus_Ref_Search = rdr["Cus_Ref"].ToString();
                name = rdr["Cus_Name"].ToString();
                address = rdr["Cus_Address"].ToString();
            }
            con.Close();
            Amend_Cus_Name_txtbx.Text=name;
            Amend_Cus_Address_txtbx.Text = address;

            Amend_lbl.Visibility = System.Windows.Visibility.Visible;
            Amend_btn.Visibility=System.Windows.
                Visibility.Visible;
            Amend_Cus_Address_lbl.Visibility = System.Windows.Visibility.Visible;
            Amend_Cus_Address_txtbx.Visibility = System.Windows.Visibility.Visible;
            Amend_Cus_Name_lbl.Visibility = System.Windows.Visibility.Visible;
            Amend_Cus_Name_txtbx.Visibility = System.Windows.Visibility.Visible;

            Search_btn.Visibility = System.Windows.Visibility.Hidden;
            Search_Cus_Address_lbl.Visibility = System.Windows.Visibility.Hidden;
            Search_Cus_Address_txtbx.Visibility = System.Windows.Visibility.Hidden;
            Search_Cus_Name_lbl.Visibility = System.Windows.Visibility.Hidden;
            Search_Cus_Name_txtbx.Visibility = System.Windows.Visibility.Hidden;
            Search_lbl.Visibility = System.Windows.Visibility.Hidden;
            //on click amend stuff becomes visable and the search stuff becomes invisable
        }

        private void Amend_btn_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand com = new SqlCommand("UPDATE Customer SET Cus_Address=@Cus_Address, Cus_Name=@Cus_Name WHERE Cus_Ref=@Cus_Ref_Search",con);

            com.CommandType = System.Data.CommandType.Text;
            com.Connection = con;
            com.Parameters.AddWithValue("@Cus_Address", Amend_Cus_Address_txtbx.Text);
            com.Parameters.AddWithValue("@Cus_Name", Amend_Cus_Name_txtbx.Text);
            com.Parameters.AddWithValue("@Cus_Ref_Search",Cus_Ref_Search);
            con.Open();
            int result = com.ExecuteNonQuery();
            con.Close();
            if (result == 1)
            {
                MessageBox.Show("passed");
            }
            else
            {
                MessageBox.Show("failed");
            }
        }
    }
}
