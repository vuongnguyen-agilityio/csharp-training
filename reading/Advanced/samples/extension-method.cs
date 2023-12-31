﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.samples
{
    public static class ExtensionsMethodSample
    {
        public static int WordCount(this string str)
        {
            if (str is string) // This is a type pattern
            {
                return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
            } else
            {
                throw new Exception("String is required");
            }
        }

    }

    internal class ExtensionMethodSample
    {
        public void RunTest()
        {
            // What Sample Do?
            // 1. Create a extension method to count word in a string
            string str = "Hello Extension Methods";
            int i = str.WordCount();
        }
    }
}
