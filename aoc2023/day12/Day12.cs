
using System.Runtime.CompilerServices;

public class Day12
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day12/p.in"))
        {
            ulong cnt = 0;
            

            string? ln;
            while ((ln = file.ReadLine()) != null)
            {
                var cnttemp = 0;

                var words = ln.Split(" ");
                var p = words[0];
                for (var i = 0; i < 4; i++)
                {
                    p += "?" + words[0];
                }
                //for (var i = 0; i < 100; i++)
                //{
                //    p = p.Replace(".?#", ".##");
                //    p = p.Replace("#?.", "##.");
                //    p = p.Replace("..", ".");
                //}
                p = "." + p + ".";
                
                var w = words[1];
                for (var i = 0; i < 4; i++)
                {
                    w += "," + words[1];
                }

                Console.WriteLine(w);

                var nums = w.Split(",");
                var n = new List<int>();

                foreach (var num in nums)
                {
                    n.Add(int.Parse(num));
                }

                Console.WriteLine(p);

                var q = new Queue<Tuple<int, List<int>>>();
                var hs = new HashSet<string>();

                var l = new List<int>();
                l.Add(1);
                for (var i = 1; i < nums.Count(); i++)
                {
                    l.Add(l[i - 1] + n[i - 1] + 1);

                }

                q.Enqueue(new Tuple<int, List<int>>(0, l));

                while (q.Count > 0)
                {
                    var t = q.Dequeue();
                    var list = new List<int>(t.Item2);

                    var tmp = p.ToCharArray();

                    for (var i = 0; i < tmp.Length; i++)
                    {
                        tmp[i] = '.';
                    }

                    for (var j = 0; j < list.Count; j++)
                    {
                        for (var k = 0; k < n[j]; k++)
                        {
                            tmp[list[j] + k] = '#';
                        }
                    }

                    var valid = true;
                    var inhash = false;
                    var hashes = 0;
                    for (var i = 0; i < tmp.Length; i++)
                    {
                        if (tmp[i] == '#')
                        {
                            if (!inhash)
                            {
                                inhash = true;
                                hashes++;
                            }
                            if (p[i] == '.')
                            {
                                valid = false;
                                break;
                            }
                        }
                        if (tmp[i] == '.')
                        {
                            if (inhash)
                            {
                                inhash = false;
                            }
                            if (p[i] == '#')
                            {
                                valid = false;
                                break;
                            }
                        }
                    }

                    //Console.WriteLine(new String(tmp) + " " + (valid ? "VALID" : "INVALID"));

                    if (valid && !hs.Contains(new String(tmp)))
                    {
                        hs.Add(new string(tmp));
                        cnt++;
                        cnttemp++;
                    }

                    if (!valid && hashes <= t.Item1)
                    {
                        continue;
                    }

                    if (t.Item1 == n.Count)
                    {
                        continue;
                    }


                    while (list[t.Item1] + n[t.Item1] < p.Count())
                    {
                        //if (t.Item1 < n.Count() - 1)
                        //{
                        //    if (list[t.Item1] + n[t.Item1] > list[t.Item1 + 1])
                        //    {
                        //        break;
                        //    }
                        //}
                        q.Enqueue(new Tuple<int, List<int>>(t.Item1 + 1, new List<int>(list)));

                        var brejk = false;                        
                        for (var i = t.Item1; i < n.Count; i++)
                        {
                            list[i]++;
                            if (list[i] + n[i] >= p.Count())
                            {
                                brejk = true;
                                break;
                            }
                        }
                        if (brejk)
                        {
                            break;
                        }
                        
                    }
                }
                
                Console.WriteLine("Cnt: " + cnttemp);

            }
            Console.WriteLine("TOT: " + cnt);

            file.Close();
        }
    }
}

