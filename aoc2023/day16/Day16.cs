public class Day16
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day16/p.in"))
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

