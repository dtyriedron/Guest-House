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
            Testlist t = new Testlist();

            t.test();

            Console.ReadLine();

            InitializeComponent();
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
