
using System.Runtime.CompilerServices;

public class Day13
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day13/p.in"))
        {
            var cnt = 0;
            var maps = new List<List<string>>();
            List<string> map = new List<string>();
            string? ln;
            while ((ln = file.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(ln))
                {
                    maps.Add(map);
                    map = new List<string>();
                }
                else
                {
                    map.Add(ln);
                }
            }
            maps.Add(map);

            foreach (var m in maps)
            {
                // row by row
                var rscore = 0;
                //var rscore_cnt = 0;
                var foundr = false;

                for (var i = 1; i < m.Count; i++)
                {
                    
                    if (m[i] == m[i-1])
                    {
                        var rscore_temp = i;
                        var u = i - 1;
                        var d = i;
                        //var score = 0;

                        //score++;
                        //if (score > rscore_cnt)
                        //{
                            rscore = rscore_temp;
                            //rscore_cnt = score;
                        //}

                        var eq = true;
                        while (u > 0 && d < m.Count - 1)
                        {
                            

                            u--;
                            d++;

                            if (m[u] != m[d])
                            {
                                eq = false;
                                break;
                            }

                            //score++;
                            //if (score > rscore_cnt)
                            //{
                                //rscore = rscore_temp;
                                //rscore_cnt = score;
                            //}
                        }
                        if (eq)
                        {
                            foundr = true;
                            break;
                        }
                    }
                }

                // col by col
                var cscore = 0;
                //var cscore_cnt = 0;
                var foundc = false;

                var len = m[0].Length;
                for (var i = 1; i < len; i++)
                {
                    var eq = true;
                    for (var j = 0; j < m.Count; j++)
                    {
                        if (m[j][i] != m[j][i - 1])
                        {
                            eq = false;
                            break;
                        }
                    }

                    if (eq)
                    {
                        var cscore_temp = i;
                        var l = i - 1;
                        var r = i;
                        //var score = 0;

                        //score++;
                        //if (score > cscore_cnt)
                        //{
                            cscore = cscore_temp;
                            //cscore_cnt = score;
                        //}

                        while (l > 0 && r < len - 1)
                        {

                            l--;
                            r++;

                            eq = true;
                            for (var j = 0; j < m.Count; j++)
                            {
                                if (m[j][r] != m[j][l])
                                {
                                    eq = false;
                                    break;
                                }
                            }
                            if (eq == false)
                            {
                                break;
                            }

                            //score++;
                            //if (score > cscore_cnt)
                            //{
                            //    cscore = cscore_temp;
                            //    cscore_cnt = score;
                            //}
                        }

                        if (eq)
                        {
                            foundc = true;
                            break;
                        }
                    }
                }
                if (foundr)
                {
                    //Console.WriteLine(rscore * 100);
                    cnt += rscore * 100;
                }
                if (foundc)
                {
                    //Console.WriteLine(cscore);
                    cnt += cscore;
                }
                if (!foundr && !foundc)
                {
                    throw new Exception();
                }
                if (foundr && foundc)
                {
                    throw new Exception();
                }
                //Console.WriteLine();
            }

            Console.WriteLine(cnt);
            file.Close();
        }
    }
}

