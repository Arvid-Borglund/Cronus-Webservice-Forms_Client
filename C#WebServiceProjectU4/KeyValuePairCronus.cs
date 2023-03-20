using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationCronus
{
    public class KeyValuePairCronus
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public KeyValuePairCronus(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public KeyValuePairCronus()
        {
            // Empty constructor required for serialization
        }


    }
}