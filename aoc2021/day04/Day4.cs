public class Day4
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day04/p.in"))
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

