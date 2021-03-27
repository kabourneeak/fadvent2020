namespace Days

open Utils.FileUtils
open System.Text.RegularExpressions

module Day3 =

    type Forest =
        | Open
        | Tree

    let stringToForestModel str =
        str
        |> Seq.map(fun c -> 
            match c with
                | '.' -> Open
                | '#' -> Tree
                | _ -> failwith "unexpected char in forest string")

    let getForest =
        getLines "./inputs/day3part1.txt"
        |> Seq.map (fun line -> stringToForestModel line |> Seq.toList)
        |> Seq.toList

    let countTreesOnSlope start slope forest =
        ()

    let Part1 =
        let start = (0, 0)
        let slope = 3
        let trees = countTreesOnSlope start slope getForest

        printf $"Day 3 Part 1 Answer: Not Implemented\n"
        ()

    let Part2 = 
        printf $"Day 3 Part 2 Answer: Not Implemented\n"
        ()
