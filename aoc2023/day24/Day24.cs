public class Day24
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day24/p.in"))
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

