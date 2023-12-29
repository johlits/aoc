using Helper;

public class Day21
{
    public static void Run()
    {
        var numbers = new ListOfIntegers();
        var bps = new List<(Blueprint, int)>
        {
            (numbers, -1),
        };
        new Parser("p.in", bps, new Symbols()
        {

        });
    }
}

