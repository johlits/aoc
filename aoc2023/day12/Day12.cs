
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
                for (var i = 0; i < 100; i++)
                {
                    p = p.Replace(".?#", ".##");
                    p = p.Replace("#?.", "##.");
                    p = p.Replace("..", ".");
                }
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

                var newP = p.ToCharArray();

                // do something?

                p = new string(newP);
                Console.WriteLine(p);

                long qs = 1;
                long bs = 1;
                var q = 0;
                var qpos = new List<int>();
                var bitworth = new List<long>();
                for (var i = 0; i < p.Length; i++)
                {
                    if (p[i] == '?')
                    {
                        q++;
                        
                        qs *= 2;
                        

                        qpos.Add(i);
                    }
                    if (bs > 0)
                    {
                        bitworth.Add(bs);
                        bs *= 2;
                    }
                }
                
                for (long i = 0; i < qs; i++)
                {
                    char[] temp = p.ToCharArray();
                    string binaryString = Convert.ToString(i, 2).PadLeft(q, '0');
                    for (var j = 0; j < binaryString.Length; j++)
                    {
                        temp[qpos[j]] = binaryString[j] == '1' ? '#' : '.';
                    }
                    var islands = new List<int>();
                    var islandCount = 0;
                    var building = false;
                    var bc = 0;
                    foreach (var c in temp)
                    {

                        if (c == '#')
                        {
                            if (building == false)
                            {
                                building = true;
                                bc = 1;
                            }
                            else
                            {
                                bc++;
                            }
                        }
                        else
                        {
                            if (building == true)
                            {

                                if (bc != n[islandCount])
                                {
                                    //if (q - islandCount - 30 >= 0)
                                    //{
                                    //    i += bitworth[q - islandCount - 30];
                                    //}

                                    break;
                                }

                                islandCount++;

                                if (islandCount > n.Count)
                                {
                                    break;
                                }
                                

                                building = false;
                                islands.Add(bc);
                                bc = 0;
                            }
                        }
                    }
                    if (building)
                    {
                        islands.Add(bc);
                    }
                    
                    //Console.WriteLine();
                    var ok = true;
                    if (islands.Count != n.Count)
                    {
                        ok = false;
                    }
                    else
                    {
                        for (var j = 0; j < islands.Count; j++)
                        {
                            if (islands[j] != n[j])
                            {
                                ok = false;
                            }
                        }
                    }
                    
                    if (ok)
                    {
                        //Console.WriteLine("OK");
                        cnttemp++;
                        cnt++;
                    }
                }

                //Console.WriteLine();
                
                Console.WriteLine("Cnt: " + cnttemp);

            }
            Console.WriteLine("TOT: " + cnt);

            file.Close();
        }
    }
}

