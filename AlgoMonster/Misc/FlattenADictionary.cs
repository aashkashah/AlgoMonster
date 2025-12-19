using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.Misc
{
    public static class FlattenADictionary
    {
        //Flatten a Dictionary
        //        input:  dict = {
        //            "Key1" : "1",
        //            "Key2" : {
        //                "a" : "2",
        //                "b" : "3",
        //                "c" : {
        //                    "d" : "3",
        //                    "e" : {
        //                        "" : "1"
        //                    }
        //                }
        //            }
        //        }

        //output: {
        //            "Key1" : "1",
        //            "Key2.a" : "2",
        //            "Key2.b" : "3",
        //            "Key2.c.d" : "3",
        //            "Key2.c.e" : "1"
        //        }

        public static Dictionary<string, string> FlattenDictionary(Dictionary<string, object> dict)
        {

            return null;
        }

        private static void FlattenDictHelper(string initialKey, Dictionary<string, object> dictionary, Dictionary<string, string> flattenDict)
        {
            foreach (var dict in dictionary)
            {
                var key = dict.Key;
                var val = dict.Value;


                string newkey = "";
                if (string.IsNullOrEmpty(key))
                {
                    newkey = key;
                }
                else
                {
                    newkey = initialKey +  (string.IsNullOrEmpty(key) ? "" : "." + key);
                }

                if(val is Dictionary<string, object>)
                {
                    FlattenDictHelper(newkey, (Dictionary<string, object>)val, flattenDict);
                }
                else
                {
                    flattenDict.Add(newkey, val.ToString());
                }

            }
        }
    }
}
