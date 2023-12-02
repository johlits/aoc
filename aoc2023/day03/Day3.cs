public class Day3
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day03/p.in"))
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

