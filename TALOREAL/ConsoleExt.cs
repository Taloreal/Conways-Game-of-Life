using System;
using System.Collections.Generic;

namespace TALOREAL {

    public enum ConsoleTextAlign {
        LeftAligned,
        Centered,
        RightAligned
    }


    public static class ConsoleExt {

        private delegate object Parser(string str, out bool worked);
        private delegate bool Ranged(object obj, object min, object max);

        /// <summary>
        /// Used to attempt to convert string input to the requested type.
        /// </summary>
        private static Dictionary<Type, Parser> Converter = new Dictionary<Type, Parser>() {
            { typeof(string),   (string s, out bool p) => { p = true; return s; } },
            { typeof(bool),     (string s, out bool p) => { p = ExtensionMethods.TryParseBool(s, out bool val); return val; } },
            { typeof(byte),     (string s, out bool p) => { p = byte.TryParse(s, out byte val); return val; } },
            { typeof(short),    (string s, out bool p) => { p = short.TryParse(s, out short val); return val; } },
            { typeof(int),      (string s, out bool p) => { p = int.TryParse(s, out int val); return val; } },
            { typeof(long),     (string s, out bool p) => { p = long.TryParse(s, out long val); return val; } },
            { typeof(double),   (string s, out bool p) => { p = double.TryParse(s, out double val); return val; } },
            { typeof(float),    (string s, out bool p) => { p = float.TryParse(s, out float val); return val; } },
            { typeof(sbyte),    (string s, out bool p) => { p = sbyte.TryParse(s, out sbyte val); return val; } },
            { typeof(ushort),   (string s, out bool p) => { p = ushort.TryParse(s, out ushort val); return val; } },
            { typeof(uint),     (string s, out bool p) => { p = uint.TryParse(s, out uint val); return val; } },
            { typeof(ulong),    (string s, out bool p) => { p = ulong.TryParse(s, out ulong val); return val; } },
            { typeof(DateTime), (string s, out bool p) => { p = DateTime.TryParse(s, out DateTime val); return val; } },
        };

        /// <summary>
        /// Used to check if a value is inside expected range.
        /// </summary>
        private static Dictionary<Type, Ranged> InsideOf = new Dictionary<Type, Ranged>() {

            { typeof(string), (o, min, max) => {
                if (!IsType<int>(new object[]{ min, max })) { return false; }
                if (o.GetType() != typeof(string)) { return false; }
                string val = (string)o;
                return  val.Length >= (int)min && val.Length <= (int)max;
            } },

            { typeof(bool), (o, min, max) => {
                if (!IsType<bool>(new object[]{ o })) { return false; }
                return true;
            } },

            { typeof(byte), (o, min, max) => {
                if (!IsType<byte>(new object[]{ o, min, max })) { return false; }
                byte val = (byte)o;
                return val >= (byte)min && val <= (byte)max;
            } },

            { typeof(short), (o, min, max) => {
                if (!IsType<short>(new object[]{ o, min, max })) { return false; }
                short val = (short)o;
                return val >= (short)min && val <= (short)max;
            } },

            { typeof(int), (o, min, max) => {
                if (!IsType<int>(new object[]{ o, min, max })) { return false; }
                int val = (int)o;
                return val >= (int)min && val <= (int)max;
            } },

            { typeof(long), (o, min, max) => {
                if (!IsType<long>(new object[]{ o, min, max })) { return false; }
                long val = (long)o;
                return val >= (long)min && val <= (long)max;
            } },

            { typeof(double), (o, min, max) => {
                if (!IsType<double>(new object[]{ o, min, max })) { return false; }
                double val = (double)o;
                return val >= (double)min && val <= (double)max;
            } },

            { typeof(float), (o, min, max) => {
                if (!IsType<float>(new object[]{ o, min, max })) { return false; }
                float val = (float)o;
                return val >= (float)min && val <= (float)max;
            } },

            { typeof(sbyte), (o, min, max) => {
                if (!IsType<sbyte>(new object[]{ o, min, max })) { return false; }
                sbyte val = (sbyte)o;
                return val >= (sbyte)min && val <= (sbyte)max;
            } },

            { typeof(ushort), (o, min, max) => {
                if (!IsType<ushort>(new object[]{ o, min, max })) { return false; }
                ushort val = (ushort)o;
                return val >= (ushort)min && val <= (ushort)max;
            } },

            { typeof(uint), (o, min, max) => {
                if (!IsType<uint>(new object[]{ o, min, max })) { return false; }
                uint val = (uint)o;
                return val >= (uint)min && val <= (uint)max;
            } },

            { typeof(ulong), (o, min, max) => {
                if (!IsType<ulong>(new object[]{ o, min, max })) { return false; }
                ulong val = (ulong)o;
                return val >= (ulong)min && val <= (ulong)max;
            } },

            { typeof(DateTime), (o, min, max) => {
                if (!IsType<DateTime>(new object[]{ o, min, max })) { return false; }
                DateTime val = (DateTime)o;
                return val >= (DateTime)min && val <= (DateTime)max;
            } },
        };

        /// <summary>
        /// Checks that all elements are of the requested type.
        /// </summary>
        /// <typeparam name="T">The expected type.</typeparam>
        /// <param name="objs">The objects to compare.</param>
        /// <returns>Are all of the objects the expected type?</returns>
        private static bool IsType<T>(object[] objs) {
            for (int i = 0; i < objs.Length; i++) {
                if (objs[i].GetType() != typeof(T)) {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Attempts to get a value from the user.
        /// </summary>
        /// <typeparam name="T">The type of value to get from the user.</typeparam>
        /// <param name="prompt">The prompt to show the user.</param>
        /// <param name="lined">Should the response be on another line?</param>
        /// <param name="min">The minimum value, if any, of the user's input.</param>
        /// <param name="max">The maximum value, if any, of the user's input.</param>
        /// <returns>The user's input in the requested type.</returns>
        public static T ReadValue<T>(string prompt, bool lined = true, T min = default(T), T max = default(T)) {
            bool loop = true;
            T obj = default(T);
            Write(prompt, lined);
            if (typeof(T) == typeof(string)) {
                obj = (T)((object)Console.ReadLine());
                loop = false;
            }
            else if (!Converter.ContainsKey(typeof(T))) { loop = false; }
            while (loop) {
                string input = Console.ReadLine();
                obj = (T)Converter[typeof(T)](input, out loop);
                loop = !loop;
                if (loop) {
                    Write("ERROR: \"" + input + "\" is not of expected type " + typeof(T).Name);
                    Write(prompt, lined);
                }
                else if (!min.Equals(max) && !InsideOf[typeof(T)](obj, min, max)) {
                    Write("ERROR: \"" + input + "\" was outside the expected range " + min + " to " + max);
                    loop = true;
                }
            }
            return obj;
        }

        /// <summary>
        /// Displays a prompt then waits for user imput.
        /// </summary>
        /// <param name="prompt">The prompt to display.</param>
        /// <param name="limit">The maximum number of characters, if any, for the response.</param>
        /// <param name="lined">Should the response be on a different line?</param>
        /// <returns>The user's input.</returns>
        public static string ReadLine(string prompt, int limit = -1, bool lined = true) {
            Write(prompt, lined);
            string resp = Console.ReadLine();
            while (limit != -1 && resp.Length > limit) {
                Write("ERROR: Response was too long. (Limit: " + limit + " chars)", true);
                Write(prompt, lined);
                resp = Console.ReadLine();
            }
            return resp;
        }

        /// <summary>
        /// Writes a prompt to the screen either with a new line or not.
        /// </summary>
        /// <param name="prompt">The prompt to display.</param>
        /// <param name="lined">Should a new line be made?</param>
        public static void Write(string prompt, bool lined = true) {
            if (lined) { Console.WriteLine(prompt); }
            else { Console.Write(prompt); }
        }

        /// <summary>
        /// Waits for the user to press enter.
        /// </summary>
        /// <param name="action">The prompt to wait for.</param>
        public static void WaitForEnter(string action) {
            Console.WriteLine();
            Console.WriteLine("Press enter to " + action + "...");
            Console.ReadLine();
        }

        /// <summary>
        /// Shows the user some options and prompts for a choice.
        /// </summary>
        /// <param name="prompt">The prompt for the user.</param>
        /// <param name="options">The options for the user.</param>
        /// <param name="sel">The user's selection.</param>
        public static void ReadChoice(string prompt, string[] options, out int sel) {
            foreach (string option in options) {
                Console.WriteLine(option);
            }
            sel = ReadInteger(prompt, 1, options.Length);
        }

        /// <summary>
        /// Gets an integer input from the user.
        /// If min and max are set equal range does not matter,
        /// otherwise the integer must be within range.
        /// </summary>
        /// <param name="prompt">The string to prompt the user with.</param>
        /// <param name="min">The minimum input.</param>
        /// <param name="max">The maximum input.</param>
        /// <returns>An integer within the set range.</returns>
        public static int ReadInteger(string prompt, int min = -1, int max = -1) {
            bool notRanged = min == max;
            Console.Write(prompt);
            bool isInt = int.TryParse(Console.ReadLine(), out int input);
            bool inRange = notRanged || (input >= min && input <= max);
            while (!isInt || !inRange) {
                string add = (notRanged) ? "." : " " + min + " to " + max + ".";
                string err = "ERROR: Must enter a number" + add;
                Console.WriteLine(err);
                Console.Write(prompt);
                isInt = int.TryParse(Console.ReadLine(), out input);
                inRange = notRanged || (input >= min && input <= max);
            }
            return input;
        }

        /// <summary>
        /// Prompts the user for input and puts it inside input.
        /// </summary>
        /// <param name="prompt">The prompt for the user.</param>
        /// <param name="input">The input the user enters.</param>
        public static void ReadString(string prompt, ref string input) {
            Console.Write(prompt);
            input = Console.ReadLine();
            bool empty = string.IsNullOrEmpty(input);
            bool white = string.IsNullOrWhiteSpace(input);
            while (empty || white) {
                Console.WriteLine("ERROR: Must enter text.");
                Console.Write(prompt);
                input = Console.ReadLine();
                empty = string.IsNullOrEmpty(input);
                white = string.IsNullOrWhiteSpace(input);
            }
        }
    }
}