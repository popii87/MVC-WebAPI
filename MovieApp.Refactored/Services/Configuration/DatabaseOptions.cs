using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Configuration
{
    public class DatabaseOptions
    {
        public string MovieAppConnectionString { get; set; }
        public string Secret { get; set; }
    }
}
