
public class Day5
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day05/p.in"))
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

