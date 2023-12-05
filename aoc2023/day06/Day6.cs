public class Day6
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day06/p.in"))
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

