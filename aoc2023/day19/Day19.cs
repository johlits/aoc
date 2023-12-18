public class Day19
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day19/p.in"))
        {
            string? ln;
            while ((ln = file.ReadLine()) != null)
            {
                Console.WriteLine(ln);
            }

            file.Close();
        }
    }
}

