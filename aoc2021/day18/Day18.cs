﻿using Helper;

public class Day18
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

