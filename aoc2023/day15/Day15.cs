public class Day15
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day15/p.in"))
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

