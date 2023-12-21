namespace Helper
{
    public enum Type
    {
        Integer,
        Long,
        ULong,
        String
    }

    public class Symbols
    {
        public char? SplittingSymbol { get; set; }
        public char? StartSymbol { get; set; }
        public char? GoalSymbol { get; set; }
        public char? ObstacleSymbol { get; set; }
    }

    public class Parser
    {
        public Parser(string path, List<Tuple<Blueprint, int>> blueprints, Symbols symbols)
        {
            using (StreamReader file = new StreamReader(path))
            {
                var lines = new List<string>();
                string? ln;

                var bluePrintIndex = 0;
                var blueprint = blueprints[bluePrintIndex].Item1;
                var bluePrintIteration = 1;
                var bluePrintIterations = blueprints[bluePrintIndex].Item2 > 0 ? blueprints[bluePrintIndex].Item2 : int.MaxValue;
                var end = false;

                while ((ln = file.ReadLine()) != null)
                {
                    if (ln.Trim() == "")
                    {
                        if (bluePrintIteration < bluePrintIterations)
                        {
                            blueprint.Process(lines, symbols);
                            lines = new List<string>();
                            bluePrintIteration++;
                        }
                        else
                        {
                            blueprint.Process(lines, symbols);
                            lines = new List<string>();
                            bluePrintIndex++;
                            if (bluePrintIndex >= blueprints.Count)
                            {
                                end = true;
                                break;
                            }
                            blueprint = blueprints[bluePrintIndex].Item1;
                            bluePrintIteration = 1;
                            bluePrintIterations = blueprints[bluePrintIndex].Item2 > 0 ? blueprints[bluePrintIndex].Item2 : int.MaxValue;
                        }
                    }
                    else
                    {
                        lines.Add(ln);
                    }
                }
                if (!end)
                {
                    blueprint.Process(lines, symbols);
                }
            }
        }
    }

    public interface Blueprint
    {
        public void Process(List<string> list, Symbols symbols);
    }

    public class ListOfIntegerBingos : Blueprint
    {
        public List<Bingo> bingos = new List<Bingo>();
        public void Process(List<string> list, Symbols symbols)
        {
            bingos.Add(new Bingo(list));
        }
    }

    public class Bingo
    {
        public int width = 0;
        public int height = 0;
        public List<List<int>> board = new List<List<int>>();
        public List<List<bool>> marked = new List<List<bool>>();
        public Bingo(List<string> rows)
        {
            height = rows.Count;
            for (var i = 0; i < rows.Count; i++)
            {
                board.Add(new List<int>());
                marked.Add(new List<bool>());
                var numbers = rows[i].Split(" ");
                for (var j = 0; j < numbers.Count(); j++)
                {
                    if (string.IsNullOrEmpty(numbers[j]))
                    {
                        continue;
                    }
                    else
                    {
                        board[i].Add(J.I(numbers[j]));
                        marked[i].Add(false);
                    }
                }
                width = board[i].Count;
            }
        }
        public void Mark(int val)
        {
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    if (board[i][j] == val)
                    {
                        marked[i][j] = true;
                    }
                }
            }
        }

        public bool IsBingo()
        {
            for (var i = 0; i < height; i++)
            {
                var bingo = true;
                for (var j = 0; j < width; j++)
                {
                    if (marked[j][i] != true)
                    {
                        bingo = false;
                        break;
                    }
                }
                if (bingo)
                {
                    return true;
                }
            }

            for (var i = 0; i < width; i++)
            {
                var bingo = true;
                for (var j = 0; j < height; j++)
                {
                    if (marked[i][j] != true)
                    {
                        bingo = false;
                        break;
                    }
                }
                if (bingo)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class ListOfIntegers : Blueprint
    {
        public List<L1d> lists = new List<L1d>();
        public void Process(List<string> list, Symbols symbols)
        {
            for (var i = 0; i < list.Count; i++)
            {
                lists.Add(new L1d(list[i], symbols));
            }
        }
    }

    public class ListOf2dMaps : Blueprint
    {
        public List<M2d> Matrix2ds = new List<M2d>();

        public int Count()
        {
            return Matrix2ds.Count;
        }

        public M2d Get(int id)
        {
            return Matrix2ds[id];
        }

        public void Process(List<string> lines, Symbols symbols)
        {
            int width = lines[0].Length;
            Matrix2ds.Add(new M2d(lines, width, lines.Count, symbols));
        }
    }

    public class L1d
    {
        public List<int> list = new List<int>();
        public Type type = Type.String;


        public L1d(string line, Symbols? symbol = null)
        {
            var splittingSymbol = ',';
            if (symbol != null && symbol.SplittingSymbol != null)
            {
                splittingSymbol = (char)symbol.SplittingSymbol;
            }
            var parts = line.Split(splittingSymbol);
            foreach (var part in parts)
            {
                list.Add(J.I(part));
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
