using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronusFormsClient
{
    public class MyKeyValuePairCronus
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public MyKeyValuePairCronus() { }

        public MyKeyValuePairCronus(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public static implicit operator KeyValuePairCronus(MyKeyValuePairCronus myKvp)
        {
            return new KeyValuePairCronus() { Key = myKvp.Key, Value = myKvp.Value };
        }

        public static implicit operator MyKeyValuePairCronus(KeyValuePairCronus kvp)
        {
            return new MyKeyValuePairCronus() { Key = kvp.Key, Value = kvp.Value };
        }
    }
}
