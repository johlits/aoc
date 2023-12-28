using Helper;

public class Day7
{
    public static void Run()
    {
        var numbers = new ListOfIntegers();
        var bps = new List<(Blueprint, int)>
        {
            (numbers, -1),
        };
        new Parser("day07/p.in", bps, new Symbols()
        {

        });
    }
}

