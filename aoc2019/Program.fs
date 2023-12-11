open System
open Day

let run argv =
    let result1 = Day2.part1
    let result2 = Day2.part2
    printfn "Part 1: %d" result1
    printfn "Part 2: %d" result2

[<EntryPoint>]
let main argv =
    run argv
    0
