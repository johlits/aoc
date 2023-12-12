
using System.Runtime.CompilerServices;

public class Day13
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day13/p.in"))
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

