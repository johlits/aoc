﻿public class Day21
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day21/p.in"))
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

