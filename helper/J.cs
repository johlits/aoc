using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class J
    {
        // I/O 

        public static List<string> ReadAllLines(string from)
        {
            string dataIn = File.ReadAllText(from);
            return dataIn.Split('\n').Select(line => line.Trim()).ToList();
        }

        public static void O(object o) => Console.Write(o);

        public static void OL(object o)
        {
            if (o is IEnumerable && !(o is string))
            {
                foreach (var obj in (IEnumerable<object>)o)
                {
                    OL(obj);
                }
            }
            else
            {
                Console.WriteLine(o);
            }
        }

        // Conversion

        public static int I(string s)
        {
            if (!int.TryParse(s, out int result))
            {
                throw new FormatException($"Failed to parse '{s}' to int.");
            }
            return result;
        }

        public static int I(char c)
        {
            if (!int.TryParse(c.ToString(), out int result))
            {
                throw new FormatException($"Failed to parse '{c}' to int.");
            }
            return result;
        }

        public static long L(string s)
        {
            if (!long.TryParse(s, out long result))
            {
                throw new FormatException($"Failed to parse '{s}' to long.");
            }
            return result;
        }

        public static ulong UL(string s)
        {
            if (!ulong.TryParse(s, out ulong result))
            {
                throw new FormatException($"Failed to parse '{s}' to ulong.");
            }
            return result;
        }


        // Math

        public static long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static long LCM(params long[] numbers)
        {
            if (numbers.Length == 0)
                throw new ArgumentException("At least two numbers are required.");

            long result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result = LCM(result, numbers[i]);
            }
            return result;
        }
    }
}
