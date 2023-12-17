public class Day18
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day18/p.in"))
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

