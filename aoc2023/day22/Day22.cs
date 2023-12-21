using System.Runtime.CompilerServices;

public class Day22
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day22/p.in"))
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

