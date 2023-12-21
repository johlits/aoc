namespace Helper
{
    public static class Parser
    {
        public class Symbols
        {
            public char? StartSymbol { get; set; }
            public char? GoalSymbol { get; set; }
            public char? ObstacleSymbol { get; set; }
        }

        public class M2ds
        {
            private List<M2d> Matrix2ds = new List<M2d>();

            public int Count()
            {
                return Matrix2ds.Count;
            }

            public M2d Get(int id)
            {
                return Matrix2ds[id];
            }

            public M2ds(StreamReader file, Symbols symbols = null)
            {
                var lines = new List<string>();
                int width = 0;

                string? ln;
                while ((ln = file.ReadLine()) != null)
                {
                    if (width == 0)
                    {
                        width = ln.Length;
                    }
                    else if (ln.Length != width)
                    {
                        throw new Exception("Matrix is not w x h");
                    }
                    lines.Add(ln);

                    if (string.IsNullOrEmpty(ln))
                    {
                        Matrix2ds.Add(new M2d(lines, width, lines.Count, symbols));

                        lines.Clear();
                        width = 0;
                    }
                }
                if (width > 0)
                {
                    Matrix2ds.Add(new M2d(lines, width, lines.Count, symbols));
                }
            }
        }

        public class M2d
        {
            private Tuple<long, long> dimensions = null;
            public long Width { get { return dimensions.Item1; } }
            public long Height { get { return dimensions.Item2; } }
            public List<Tuple<long, long>> Starts = new List<Tuple<long, long>>();
            public List<Tuple<long, long>> Goals = new List<Tuple<long, long>>();
            public List<Tuple<long, long>> Obstacles = new List<Tuple<long, long>>();

            public long? BFS(Tuple<long, long> start, Tuple<long, long> goal)
            {
                long? shortestDistance = null;

                var current = new Tuple<Tuple<long, long>, long>(start, 0);
                var q = new Queue<Tuple<Tuple<long, long>, long>>();
                var v = new HashSet<Tuple<long, long>>();
                q.Enqueue(current);

                while (q.Count > 0)
                {
                    current = q.Dequeue();
                    var position = current.Item1;
                    var distance = current.Item2;

                    if (position == goal)
                    {
                        shortestDistance = distance;
                        break;
                    }

                    var w = GoWest(position);
                    var e = GoEast(position);
                    var n = GoNorth(position);
                    var s = GoSouth(position);

                    if (w != null && !v.Contains(w) && !Obstacles.Contains(w))
                    {
                        q.Enqueue(new Tuple<Tuple<long, long>, long>(w, distance + 1));
                    }
                    if (e != null && !v.Contains(e) && !Obstacles.Contains(e))
                    {
                        q.Enqueue(new Tuple<Tuple<long, long>, long>(e, distance + 1));
                    }
                    if (n != null && !v.Contains(n) && !Obstacles.Contains(n))
                    {
                        q.Enqueue(new Tuple<Tuple<long, long>, long>(n, distance + 1));
                    }
                    if (s != null && !v.Contains(s) && !Obstacles.Contains(s))
                    {
                        q.Enqueue(new Tuple<Tuple<long, long>, long>(s, distance + 1));
                    }
                }

                return shortestDistance;
            }

            public Tuple<long, long>? GoNorth(Tuple<long, long> position, bool wrap = false)
            {
                if (position.Item2 > 0)
                {
                    return new Tuple<long, long>(position.Item1, position.Item2 - 1);
                }
                else if (wrap)
                {
                    return new Tuple<long, long>(position.Item1, Height - 1);
                }
                return null;
            }

            public Tuple<long, long>? GoSouth(Tuple<long, long> position, bool wrap = false)
            {
                if (position.Item2 < Height - 1)
                {
                    return new Tuple<long, long>(position.Item1, position.Item2 + 1);
                }
                else if (wrap)
                {
                    return new Tuple<long, long>(position.Item1, 0);
                }
                return null;
            }

            public Tuple<long, long>? GoWest(Tuple<long, long> position, bool wrap = false)
            {
                if (position.Item1 > 0)
                {
                    return new Tuple<long, long>(position.Item1 - 1, position.Item2);
                }
                else if (wrap)
                {
                    return new Tuple<long, long>(Width - 1, position.Item2);
                }
                return null;
            }

            public Tuple<long, long>? GoEast(Tuple<long, long> position, bool wrap = false)
            {
                if (position.Item1 < Width - 1)
                {
                    return new Tuple<long, long>(position.Item1 + 1, position.Item2);
                }
                else if (wrap)
                {
                    return new Tuple<long, long>(0, position.Item2);
                }
                return null;
            }

            public M2d(List<string> lines, int width, int height, Symbols? symbols)
            {
                if (symbols != null)
                {
                    for (var i = 0; i < height; i++)
                    {
                        for (var j = 0; j < width; j++)
                        {
                            if (symbols.StartSymbol != null && lines[i][j] == symbols.StartSymbol)
                            {
                                Starts.Add(new Tuple<long, long>(j, i));
                            }
                            if (symbols.GoalSymbol != null && lines[i][j] == symbols.GoalSymbol)
                            {
                                Goals.Add(new Tuple<long, long>(j, i));
                            }
                            if (symbols.ObstacleSymbol != null && lines[i][j] == symbols.ObstacleSymbol)
                            {
                                Obstacles.Add(new Tuple<long, long>(j, i));
                            }
                        }
                    }
                }

                dimensions = new Tuple<long, long>(width, height);
            }
        }
    }
}