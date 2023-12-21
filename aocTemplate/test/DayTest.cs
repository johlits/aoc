using Helper;

public class DayTest
{
    public static void Run()
    {
        var numbers = new ListOfIntegers();
        var bps = new List<Tuple<Blueprint, int>>
        {
            new Tuple<Blueprint, int>(numbers, -1),
        };
        new Parser("dayTest/p.in", bps, new Symbols()
        {

        });
    }
}

