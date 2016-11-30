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
    /// Interaction logic for DELGuest.xaml
    /// </summary>
    public partial class DELGuest : Window
    {
        public DELGuest()
        {
            InitializeComponent();
        }

        SqlConnection con =
          new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\sampledatabase.mdf; Integrated Security = True; Connect Timeout = 30");

        private void Remove_btn_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand com = new SqlCommand("DELETE FROM Guest_Table WHERE Guest_Pass_Num=@Guest_Pass_Num");

            com.Parameters.AddWithValue("@Guest_Pass_Num", Guest_Pass_Num_txtbx.Text);

            com.CommandType = System.Data.CommandType.Text;
            com.Connection = con;

            con.Open();
            int ralf = com.ExecuteNonQuery();
            MessageBox.Show(ralf.ToString());
        }
    }
}
