using Microsoft.VisualBasic;
using Helper;

public class Day24
{
    public class Hailstone
    {
        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }
        public long DX { get; set; }
        public long DY { get; set; }
        public long DZ { get; set; }
    }

    private static bool IsWithinRange(Tuple<double, double> intersection)
    {
        const long minRange = 200000000000000;
        const long maxRange = 400000000000000;
        //const long minRange = 7;
        //const long maxRange = 27;

        return intersection.Item1 >= minRange && intersection.Item1 <= maxRange &&
               intersection.Item2 >= minRange && intersection.Item2 <= maxRange;
    }

    public static void Run()
    {
        using (StreamReader file = new StreamReader("day24/p.in"))
        {
            var hailstones = new List<Hailstone>();

            string? ln;
            while ((ln = file.ReadLine()) != null)
            {
                string[] parts = ln.Replace(" ", "").Split(new char[] { ',', '@' });

                hailstones.Add(new Hailstone()
                {
                    X = long.Parse(parts[0]),
                    Y = long.Parse(parts[1]),
                    Z = long.Parse(parts[2]),
                    DX = long.Parse(parts[3]),
                    DY = long.Parse(parts[4]),
                    DZ = long.Parse(parts[5])
                });
            }

            var lines = new List<J.Line>();
            foreach (var hailstone in hailstones)
            {
                lines.Add(new J.Line(
                    new Tuple<long, long>(hailstone.X, hailstone.Y),
                    new Tuple<long, long>(hailstone.X + hailstone.DX, hailstone.Y + hailstone.DY)));
            }

            int cnt = 0;
            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = i + 1; j < lines.Count; j++)
                {
                    Tuple<double, double>? intersection = J.LineIntersection(lines[i], lines[j], true, true);
                    if (intersection != null)
                    {
                        var r = new Tuple<long, long>(lines[i].Point2.Item1 - lines[i].Point1.Item1, lines[i].Point2.Item2 - lines[i].Point1.Item2);
                        var s = new Tuple<long, long>(lines[j].Point2.Item1 - lines[j].Point1.Item1, lines[j].Point2.Item2 - lines[j].Point1.Item2);
                        var q_p = new Tuple<long, long>(lines[j].Point1.Item1 - lines[i].Point1.Item1, lines[j].Point1.Item2 - lines[i].Point1.Item2);
                        var rxs = J.CrossProduct(r, s);

                        var t = J.CrossProduct(q_p, s) / (double)rxs;
                        var u = J.CrossProduct(q_p, r) / (double)rxs;

                        if (t > 0 && u > 0 && IsWithinRange(intersection))
                        {
                            cnt++;
                        }
                    }
                }
            }
            Console.WriteLine(cnt);

            file.Close();
        }
    }
}

