using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw2_cs
{
    class Booking
    {
        private string booking_date;
        private string date_leaving;
        private int nights;
        private int booking_ref;

        public string Booking_Date
        {
            get
            {
                return booking_date;
            }
            set
            {
                //error message
                booking_date = value;

            }
        }

        public string Date_Leaving
        {
            get
            {
                return date_leaving;
            }
            set
            {
                //show error
                date_leaving = value;
            }
        }

        public int Nights
        {
            get
            {
                return nights;
            }
            set
            {
                //show error message
                nights = value;
            }
        }

        public int Booking_Ref
        {
            get
            {
                return booking_ref;
            }
            set
            {
                //show error
                booking_ref = value;
            }
        }


    }
}
