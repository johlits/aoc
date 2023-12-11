
public class Day12
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day12/p.in"))
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

