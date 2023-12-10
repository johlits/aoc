public class Day11
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day11/p.in"))
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

