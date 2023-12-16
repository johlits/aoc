public class Day17
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day17/p.in"))
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

