using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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

        public static Tuple<long, long> Point(string s)
        {
            // Use a regular expression to find all numbers in the string
            var matches = Regex.Matches(s, @"\d+");

            // Check if we have exactly two numbers
            if (matches.Count != 2)
            {
                throw new ArgumentException("The input string does not contain exactly two numbers.");
            }

            // Parse the numbers and return them as a tuple
            long number1 = long.Parse(matches[0].Value);
            long number2 = long.Parse(matches[1].Value);

            return Tuple.Create(number1, number2);
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

        public static long CrossProduct(Tuple<long, long> v1, Tuple<long, long> v2)
        {
            return v1.Item1 * v2.Item2 - v1.Item2 * v2.Item1;
        }

        public static bool DoLinesIntersect(Line line1, Line line2)
        {
            var r = new Tuple<long, long>(line1.Point2.Item1 - line1.Point1.Item1, line1.Point2.Item2 - line1.Point1.Item2);
            var s = new Tuple<long, long>(line2.Point2.Item1 - line2.Point1.Item1, line2.Point2.Item2 - line2.Point1.Item2);

            var rxs = CrossProduct(r, s);
            var q_p = new Tuple<long, long>(line2.Point1.Item1 - line1.Point1.Item1, line2.Point1.Item2 - line1.Point1.Item2);
            var t = CrossProduct(q_p, s) / (double)rxs;
            var u = CrossProduct(q_p, r) / (double)rxs;

            if (rxs == 0 && CrossProduct(q_p, r) == 0)
            {
                return (line1.Point1.Item1 <= line2.Point2.Item1 && line1.Point2.Item1 >= line2.Point1.Item1) ||
                       (line1.Point1.Item2 <= line2.Point2.Item2 && line1.Point2.Item2 >= line2.Point1.Item2);
            }

            if (rxs == 0)
                return false;

            return (t >= 0 && t <= 1) && (u >= 0 && u <= 1);
        }

        // Classes

        public class Line
        {
            public Tuple<long, long> Point1 { get; set; }
            public Tuple<long, long> Point2 { get; set; }

            public Line(Tuple<long, long> point1, Tuple<long, long> point2)
            {
                Point1 = point1;
                Point2 = point2;
            }
        }
    }
}
