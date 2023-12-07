using System.Threading.Tasks.Sources;

public class Day8
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day08/p.in"))
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

