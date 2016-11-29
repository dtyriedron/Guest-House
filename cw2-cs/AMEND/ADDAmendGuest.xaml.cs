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
    /// Interaction logic for ADDAmendGuest.xaml
    /// </summary>
    public partial class ADDAmendGuest : Window
    {
        string Gus_Pass_Search= "";

        SqlConnection con =
           new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\sampledatabase.mdf; Integrated Security = True; Connect Timeout = 30");
        public ADDAmendGuest()
        {
            InitializeComponent();
        }

        private void SAVE_btn_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand com = new SqlCommand("SELECT Guest_Pass_Num FROM Guest_Table WHERE Guest_Pass_Num=@REF_Guest_Pass_Num");

            string query1 = "UPDATE Guest_Table SET Guest_Name=@Guest_Name, Guest_Pass_Num=@Amend_Guest_Pass_Num, Gus_Age=@Gus_Age WHERE Guest_Pass_Num=@Guest_Pass_Num";

            com.Parameters.AddWithValue("@REF_Guest_Pass_Num", Gus_Pass_Num_txtbx.Text);

            com.CommandType = System.Data.CommandType.Text;
            com.Connection = con;

            con.Open();
            SqlDataReader rdr = com.ExecuteReader();
            while (rdr.Read())
            {
                Gus_Pass_Search = rdr["Guest_Pass_Num"].ToString();
            }
            rdr.Close();
            MessageBox.Show(Gus_Pass_Search);

            com.CommandText = query1;
            com.Parameters.AddWithValue("@Guest_Pass_Num", Gus_Pass_Search);
            com.Parameters.AddWithValue("@Guest_Name", Amend_Gus_Name_txtbx.Text);
            com.Parameters.AddWithValue("@Amend_Guest_Pass_Num", Amend_Pass_Num_txtbx.Text);
            com.Parameters.AddWithValue("@Gus_Age", Amend_Gus_Age_txtbx.Text);

            int ralf = com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(ralf.ToString());
        }
    }
}
