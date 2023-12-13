public class Day14
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day14/p.in"))
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

