﻿using Helper;

public class Day1
{
    public static void Run()
    {
        var numbers = new ListOfIntegers();
        var bps = new List<Tuple<Blueprint, int>>
        {
            new Tuple<Blueprint, int>(numbers, -1),
        };
        new Parser("day01/p.in", bps, new Symbols()
        {

        });
    }
}

