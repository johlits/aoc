module Day
open System

let input = 
    IO.File.ReadAllLines("day/p.in")

let a (x: string) = x.Length
let b (x: string) = x.Split(" ").Length

let part1 = input |> Seq.sumBy a
let part2 = input |> Seq.sumBy b