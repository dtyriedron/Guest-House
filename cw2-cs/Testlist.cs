using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MySql.Data.MySqlClient;

namespace cw2_cs
{
    class Testlist
    {
        private static List<Booking> bookings = new List<Booking>();
        public void test()
        {
            LoadData();
             //query 2- select by make
            var QueryTest = from b in bookings
                               select b;
            foreach (Booking b in QueryTest)
            {
                Console.WriteLine(b);
            }
        }

        private void LoadData()
        {
            {
                string sql = " SELECT * FROM guest  ";
                MySqlConnection con = new MySqlConnection("server=socweb8.napier.ac.uk;uid=40203045;password=5fako1xe8;database=40203045;");
                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

            }
        }

    }
}
