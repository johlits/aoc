public class Day7
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day07/p.in"))
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

