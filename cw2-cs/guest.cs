using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw2_cs
{
    class Guest
    {
        private string gus_name;
        private string gus_pass_num;
        private int gus_age;

        public string Gus_Name
        {
            get
            {
                return gus_name;
            }

            set
            {
                //show error
                gus_name = value;
            }
        }

        public string Gus_Pass_Num
        {
            get
            {
                return gus_pass_num;
            }
            set
            {
                //error
                gus_pass_num = value;
            }
        }

        public int Gus_Age
        {
            get
            {
                return gus_age;
            }
            set
            {
                gus_age = value;
            }
        }

    }
}
