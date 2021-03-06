﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Writer
{
    class JsonWriter
    {
        System.ArgumentException argEx = new System.ArgumentException("insufficent values, Values do not match the array size");
        private int size;
        private string[] names;
        private string[] values;
        private static Object list;

        private static Dictionary<string, string> options;

        public JsonWriter(int size)
        {
            this.size = size;
            this.names = new string[size];
            this.values = new string[size];
            options = new Dictionary<string, string>();
        }
        public Object Getlist
        {
            get
            {
                return list;
            }
        }
        public Dictionary<string, string> GetOptions
        {
            get
            {
                return options;
            }
        }
        public JsonWriter()
        {

        }
        public JsonWriter(Object list)
        {
            JsonWriter. list = list;
        }

        public JsonWriter(int size, string[] names, string[] values)
        {
            this.size = size;
            this.names = new string[size];
            this.values = new string[size];
            AddNames(names);
            AddValues(values);
            options = new Dictionary<string, string>();
           
        }
        public void updateOption(string name,string newvalue)
        {
            options[name] = newvalue;
        }
        public void updateSize(int size)
        {
            this.size = size;
            this.names = new string[size];
            this.values = new string[size];
        }
        public void AddNames(string[] names)
        {
            if (names.Length == size)
            {
                for (int i = 0; i < size; i++)
                {
                    this.names[i] = names[i];
                }
            }
            else
            {
                throw argEx;
            }
        }
        public void AddValues(string[] values)
        {
            if (values.Length == size)
            {
                for (int i = 0; i < size; i++)
                {
                    this.values[i] = values[i];
                }
            }
            else
            {
                throw argEx;
            }
        }
        public void start()
        {
            for (int i = 0; i < size; i++)
            {
                options.Add(names[i], values[i]);
                Console.WriteLine("Added name: "+names[i]+" with value: "+values[i]);
            }
        }

    }
}
