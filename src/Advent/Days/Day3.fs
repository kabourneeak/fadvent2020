namespace Days

open Utils.FileUtils

module Day3 =

    type Point = { X: int; Y: int }

    let getMap =
        getLines "./inputs/day3part1.txt" |> Seq.toList

    let countTrees (map: List<string>) ((slopeX, slopeY): (int * int)) =

        let rec countTreesRec lastPoint =
            let nextPoint =
                { X = lastPoint.X + slopeX
                  Y = lastPoint.Y + slopeY }

            match map.Length with
            | len when nextPoint.Y >= len -> 0
            | _ ->
                let currentElevation = map.[nextPoint.Y]

                let currentSpace =
                    currentElevation.[nextPoint.X % currentElevation.Length]

                match currentSpace with
                | '#' -> 1 + countTreesRec nextPoint
                | _ -> 0 + countTreesRec nextPoint

        countTreesRec { X = 0; Y = 0 }

    let part1 =
        let result = countTrees getMap (3, 1)

        printf $"Day 3 Part 1 Answer: {result}\n"

    let part2 =
        let result =
            countTrees getMap (1, 1)
            * countTrees getMap (3, 1)
            * countTrees getMap (5, 1)
            * countTrees getMap (7, 1)
            * countTrees getMap (1, 2)

        printf $"Day 3 Part 2 Answer: {result}\n"
