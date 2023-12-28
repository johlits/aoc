using Helper;

public class Day
{
    public static void Run()
    {
        var numbers = new ListOfIntegers();
        var bps = new List<(Blueprint, int)>
        {
            (numbers, -1),
        };
        new Parser("day04/p.in", bps, new Symbols()
        {

        });
    }
}

