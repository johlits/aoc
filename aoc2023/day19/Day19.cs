public class Day19
{
    public class Condition

    {
        public Condition() { }

        public Condition(string s)
        {
            // a<2006:qkq,m>2090:A,rfg
            var buff = "";
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '<')
                {
                    Operator = "<";
                    LHV = buff;
                    buff = "";
                    continue;
                }
                if (s[i] == '>')
                {
                    Operator = ">";
                    LHV = buff;
                    buff = "";
                    continue;
                }
                if (s[i] == ':')
                {
                    RHV = int.Parse(buff);
                    buff = "";
                    continue;
                }
                if (s[i] == ',')
                {
                    TrueCondition = new Condition() { Label = buff };
                    buff = "";
                    FalseCondition = new Condition(s.Substring(i + 1));
                    return;
                }
                buff += s[i];
            }
            Label = buff;
        }

        public string Label { get; set; }
        public string LHV { get; set; }
        public int RHV { get; set; }
        public string Operator { get; set; }
        public Condition TrueCondition { get; set; }
        public Condition FalseCondition { get; set; }
        public Condition Validate(int x, int m, int a, int s)
        {
            if (Label != null)
            {
                return this;
            }
            var lhv = -1;
            if (LHV == "x") lhv = x;
            if (LHV == "m") lhv = m;
            if (LHV == "a") lhv = a;
            if (LHV == "s") lhv = s;
            if (Operator == "<")
            {
                if (lhv < RHV)
                {
                    return TrueCondition;
                }
                return FalseCondition;
            }
            if (Operator == ">")
            {
                if (lhv > RHV)
                {
                    return TrueCondition;
                }
                return FalseCondition;
            }
            throw new Exception();
        }
    }

    public static void Run()
    {
        using (StreamReader file = new StreamReader("day19/p.in"))
        {
            var cnt = 0;
            string? ln;
            var part = 1;

            var dic = new Dictionary<string, Condition>();

            while ((ln = file.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(ln))
                {
                    part = 2;
                    continue;
                }

                if (part == 1)
                {
                    var a = ln.Split("{");
                    var label = a[0];
                    var b = a[1].Substring(0, a[1].Length - 1);
                    dic.Add(label, new Condition(b));
                }
                else if (part == 2)
                {
                    var w = ln.Replace("{", "").Replace("}", "").Trim();
                    var parts = w.Split(",");
                    var x = 0;
                    var m = 0;
                    var a = 0;
                    var s = 0;
                    foreach (var p in parts)
                    {
                        var l = p.Split("=")[0];
                        var r = p.Split("=")[1];
                        if (l == "x") x = int.Parse(r);
                        if (l == "m") m = int.Parse(r);
                        if (l == "a") a = int.Parse(r);
                        if (l == "s") s = int.Parse(r);
                    }

                    var c = dic["in"];
                    while (true)
                    {
                        var n = c.Validate(x, m, a, s);
                        if (n.Label == "A")
                        {
                            cnt += x + m + a + s;
                            break;
                        }
                        if (n.Label == "R")
                        {
                            break;
                        }
                        if (n.Label != null)
                        {
                            c = dic[n.Label];
                        }
                        else
                        {
                            c = n;
                        }
                    }
                }
            }
            Console.WriteLine(cnt);


            file.Close();
        }
    }
}

