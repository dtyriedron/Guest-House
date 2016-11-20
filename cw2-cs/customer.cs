using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw2_cs
{
    class Customer
    {
        private string cus_name;
        private string cus_address;
        private int cus_ref;

        public string Cus_Name
        {
            get
            {
                return cus_name;
            }
            set
            {
                //show error
                cus_name = value;
            }
        }

        public string Cus_Address
        {
            get
            {
                return cus_address;
            }
            set
            {
                cus_address = value;
            }
        }

        public int Cus_Ref
        {
            get
            {
                return cus_ref;
            }
            set
            {
                //show error
                cus_ref = value;
            }
        }
    }
}
