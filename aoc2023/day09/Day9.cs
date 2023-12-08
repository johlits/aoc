using System.Linq;
using System.Threading.Tasks.Sources;

public class Day9
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day09/p.in"))
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

