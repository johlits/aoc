module Day5
open System.IO
open System

type Day5() =
    static member Run() =
        use file = new StreamReader("day05/p.in")

        let rec readLines() =
            match file.ReadLine() with
            | null -> ()
            | ln ->
                Console.WriteLine(ln)
                readLines()

        readLines()
