namespace Days

open Utils.FileUtils

module Day9 =

    let getData () =
        getLines "./inputs/day9part1.txt" |> Seq.toList

    let firstInvalidEmission preamble lines =
        lines
        |> Seq.map int64
        |> Seq.windowed (preamble + 1)
        |> Seq.pick
            (fun window ->
                window
                |> Array.rev
                |> List.ofArray
                |> function
                | testValue :: preambleValues ->
                    let allowedValues =
                        Seq.allPairs preambleValues preambleValues
                        |> Seq.filter (fun (l, r) -> l <> r)
                        |> Seq.map (fun (x, y) -> x + y)
                        |> Set.ofSeq

                    if Set.contains testValue allowedValues then None else Some testValue
                | unexpected -> failwith $"Unexpected window state {unexpected}")

    let findWeakness preamble lines =
        let target = firstInvalidEmission preamble lines

        let values = lines |> Seq.map int64 |> Array.ofSeq

        let rec findWeakness lowI highI =
            let valuesToCheck = values.[lowI..highI]
            let sum = valuesToCheck |> Seq.sum

            match int64 sum with
            | sum when sum = target ->
                (valuesToCheck |> Seq.min)
                + (valuesToCheck |> Seq.max)
            | sum when sum > target -> findWeakness (lowI + 1) (lowI + 1)
            | sum when sum < target -> findWeakness lowI (highI + 1)
            | _ -> failwith "not possible"

        findWeakness 0 0

    let part1 () =
        let result = getData () |> firstInvalidEmission 25

        printf $"Day 9 Part 1 Answer: {result}\n"


    let part2 () =
        let result = getData () |> findWeakness 25

        printf $"Day 9 Part 2 Answer: {result}\n"
