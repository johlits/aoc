using System.Linq;
using System.Threading.Tasks.Sources;

public class Day10
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day10/p.in"))
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

