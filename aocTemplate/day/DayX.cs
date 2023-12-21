using Helper;

public class DayX
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day/p.in"))
        {
            string? ln;
            while ((ln = file.ReadLine()) != null)
            {
                Console.WriteLine(ln);
            }
        }
    }
}

