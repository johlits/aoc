public class Day20
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day20/p.in"))
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

