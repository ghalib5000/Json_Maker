using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Reader
{
    public class Reader
    {
        private Writer.JsonWriter jr = new Writer.JsonWriter();
        string pathnew = "";
        /// <summary>
        /// Initializes a new instance of the <see cref="Reader"/> class.
        /// </summary>
        /// <param name="pathnew">The path to read from.</param>
        public Reader(string pathnew)
        {
            this.pathnew = pathnew;
        }
        /// <summary>
        /// Finds the specified value.
        /// </summary>
        /// <param name="value">The value to find.</param>
        /// <returns></returns>
        public bool find(string value)
        {
            StreamReader sr = new StreamReader(pathnew);
            JsonTextReader reader = new JsonTextReader(new StringReader(sr.ReadToEnd()));
          
            while (reader.Read())
            {
                if (reader.TokenType.ToString().Contains("Property") && reader.Value.ToString().Contains(value))
                {
                    Console.WriteLine(reader.Value+" is the token");
                    reader.Read();
                    Console.WriteLine(reader.Value+" is the value");
                    sr.Close();
                    return true;
                }
                /*
                if (reader.Value != null)
                {
                    Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                }
                else
                {
                    Console.WriteLine("Value: {0}", reader.TokenType);
                }*/
            }
            return false;
        }
        /// <summary>
        /// Replaces the value of specified name.
        /// </summary>
        /// <param name="name">The name to replace the value of.</param>
        /// <param name="newvalue">The new value.</param>
        /// <returns></returns>
        public bool ReplaceValueOf(string name, string newvalue)
        {
            jr.updateOption(name, newvalue);
            string jsonString = File.ReadAllText(pathnew);
            JObject jObject = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString) as JObject;
            // Select a nested property using a single string:
            JToken jToken = jObject.SelectToken(name);
            jToken.Replace(newvalue);
            string updatedJsonString = jObject.ToString();
            Console.WriteLine("replacing value of " + name+" to "+newvalue);
            File.WriteAllText(pathnew, updatedJsonString);
            return true;
        }
        /// <summary>
        /// Returns the value of specified name.
        /// </summary>
        /// <param name="name">The name to return the value of.</param>
        /// <returns></returns>
        public string ReturnValueOf(string name)
        {
            string jsonString = File.ReadAllText(pathnew);
            JObject jObject = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString) as JObject;
            // Select a nested property using a single string:
            JToken jToken = jObject.SelectToken(name);
            Console.WriteLine("returning value of "+name);
           return jToken.ToString();
        }
        /// <summary>
        /// Views all the names along with their values.
        /// </summary>
        /// <returns></returns>
        public string view()
        {
            StreamReader sr = new StreamReader(pathnew);
            string res = sr.ReadToEnd();
            //Console.WriteLine(sr.ReadToEnd());
            sr.Close();
            return res;
        }
    }
}
