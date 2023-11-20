public class Day1
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day01/p.in"))
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

