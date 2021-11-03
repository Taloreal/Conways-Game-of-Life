﻿using System;
using System.Collections.Generic;

namespace TALOREAL {
    
    public static class ExtensionMethods {

        /// <summary>
        /// Splits a string by another string.
        /// Emulates the .net Core method. :)
        /// </summary>
        /// <param name="toSplit">The string to split.</param>
        /// <param name="delimiter">The string to split by.</param>
        /// <param name="strOps">Get rid of empty strings?</param>
        /// <returns>The string split into an array of strings.</returns>
        public static string[] Split(this string toSplit, string delimiter, StringSplitOptions strOps = StringSplitOptions.None) {
            if (toSplit.Length < delimiter.Length) { return new string[] { toSplit }; }
            List<string> entries = new List<string>();
            string working = "";
            for (int i = 0; i < toSplit.Length; i++) {
                working += toSplit[i];
                if (working.EndsWith(delimiter)) {
                    entries.Add(working.Substring(0, working.Length - delimiter.Length));
                    working = "";
                }
            }
            if (working != "") { entries.Add(working); }
            if (strOps == StringSplitOptions.RemoveEmptyEntries) {
                entries.RemoveAll(s => string.IsNullOrEmpty(s));
            }
            return entries.ToArray();
        }

        /// <summary>
        /// Gets a subset array from another array.
        /// </summary>
        /// <typeparam name="T">The type of array.</typeparam>
        /// <param name="arr">The original array.</param>
        /// <param name="start">The starting index.</param>
        /// <param name="count">The number of elements to copy.</param>
        /// <returns>The subset array.</returns>
        public static T[] SubArray<T>(this T[] arr, int start, int count = -1) {
            start = (start < 0) ? 0 : start;
            count = (start + count >= arr.Length) ? arr.Length - start : count;
            if (count < 1) { return new T[0]; }
            List<T> objs = new List<T>(count);
            for (int i = 0; i < count; i++) {
                int pos = i + start;
                objs.Add(arr[pos]);
            }
            return objs.ToArray();
        }

        /// <summary>
        /// Attempts to parse a bool from a string.
        /// </summary>
        /// <param name="str">The string to parse.</param>
        /// <param name="result">The resulting bool.</param>
        /// <returns>Did the parsing work?</returns>
        public static bool TryParseBool(string str, out bool result) {
            result = false;
            if (string.IsNullOrEmpty(str)) { return false; }
            if (str[0] == '0' || str.ToLower().StartsWith("false")) { return true; }
            if (str[0] == '1' || str.ToLower().StartsWith("true")) { 
                result = true; return true; 
            }
            return false;
        }
    }
}