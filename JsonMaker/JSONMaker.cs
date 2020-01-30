using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace JsonMaker
{
    public class JSONMaker
    {
        string path = " ";
        int numofvals = 0;
        private static Object list;

        private static Dictionary<string, string> options;


        private Writer.JsonWriter jwr;
        /// <summary>
        /// Initializes a new instance of the <see cref="JSONMaker"/> class.
        /// </summary>
        /// <param name="numberOfValues">The number of values.</param>
        /// <param name="names">The names.</param>
        /// <param name="values">The values.</param>
        /// <param name="path">The path to store file.</param>
        public JSONMaker(int numberOfValues, string[] names, string[] values, string path)
        {

            numofvals = numberOfValues;
            this.path = path;

            jwr = new Writer.JsonWriter(numofvals, names, values);
            //jwr.AddNames(names);
            //jwr.AddValues(values);
            jwr.start();
            makeFile();
        }
        public JSONMaker(int numberOfValues, string path)
        {
            numofvals = numberOfValues;
            this.path = path;
            jwr = new Writer.JsonWriter(numofvals);
            makeFile();
        }
        public JSONMaker(Object list, string path)
        {
            this.path = path;
            jwr = new Writer.JsonWriter(list);
            MakeList();
        }

        /// <summary>
        /// Adds the items.
        /// </summary>
        /// <param name="numberOfValues">The number of values.</param>
        /// <param name="names">The names of items.</param>
        /// <param name="values">The values of items.</param>
        public void AddItems(int numberOfValues, string[] names, string[] values)
        {

            jwr.updateSize(numberOfValues);
            jwr.AddNames(names);
            jwr.AddValues(values);
            jwr.start();
            makeFile();
        }
        private void makeFile()
        {
            StreamWriter write = new StreamWriter(path);
            options = jwr.GetOptions;
            string arr = JsonConvert.SerializeObject(options);

            object obj = JsonConvert.DeserializeObject(arr);
            write.Write(obj);
            write.Close();
        }
        private void MakeList()
        {
            StreamWriter write = new StreamWriter(path);
            list = jwr.Getlist;
            string arr = JsonConvert.SerializeObject(list);

            object obj = JsonConvert.DeserializeObject(arr);
            write.Write(obj);
            write.Close();
        }
    }
}
