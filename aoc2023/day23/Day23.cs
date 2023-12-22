public class Day23
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day23/p.in"))
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

