// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open Days

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    Day1.part1
    Day1.part2
    0 // return an integer exit code
