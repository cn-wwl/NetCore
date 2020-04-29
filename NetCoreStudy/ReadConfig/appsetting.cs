using System;
using System.Collections.Generic;
using System.Text;

namespace ReadConfig
{  
    public class appsetting
    {
        public string platform { get; set; }
        public string Address { get; set; }
        public Login Login { get; set; }
    }

    public class Login
    {
        public string account { get; set; }
        public string password { get; set; }
    }

}
