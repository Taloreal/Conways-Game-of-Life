using System;
using System.Collections.Generic;

namespace Utilities {
    
    public static class ExtensionMethods {

        /// <summary>
        /// Splits a string by another string.
        /// Emulates the .net Core method :)
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
        /// Creates 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
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
    }
}