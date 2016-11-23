using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

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

                

            }
        }

    }
}
