namespace Days

open Utils.FileUtils

module Day10 =

    let getData () =
        getLines "./inputs/day10part1.txt" |> Seq.toList

    let findJoltageAnswer lines =
        [ "0" ]
        |> Seq.append lines
        |> Seq.map int
        |> Seq.sort
        |> Seq.pairwise
        |> Seq.fold
            (fun (dif1, dif2, dif3) (x, y) ->
                match (y - x) with
                | 1 -> (dif1 + 1, dif2, dif3)
                | 2 -> (dif1, dif2 + 1, dif3)
                | 3 -> (dif1, dif2, dif3 + 1)
                | unexpected -> failwith $"Uexpected input diff: {unexpected}")
            (0, 0, 0)
        |> (fun (dif1, _, dif3) -> dif1 * (dif3 + 1))


    let findArrangements lines: int64 =
        let adapters = lines |> Seq.map int |> Set.ofSeq

        let deviceValue = adapters |> Seq.max |> (+) 3

        let adaptersAndDev = adapters |> Set.add deviceValue

        let routesMap =
            adaptersAndDev
            |> Seq.sort
            |> Seq.fold
                (fun routesMap adapter ->
                    let routesToAdptMinus1 =
                        routesMap
                        |> Map.tryFind (adapter - 1)
                        |> Option.defaultValue (int64 0)

                    let routesToAdptMinus2 =
                        routesMap
                        |> Map.tryFind (adapter - 2)
                        |> Option.defaultValue (int64 0)

                    let routesToAdptMinus3 =
                        routesMap
                        |> Map.tryFind (adapter - 3)
                        |> Option.defaultValue (int64 0)

                    let routesToHere =
                        routesToAdptMinus1
                        + routesToAdptMinus2
                        + routesToAdptMinus3

                    routesMap |> Map.add adapter routesToHere)
                ([ 0, (int64 1) ] |> Map.ofList)

        routesMap.[deviceValue]


    let part1 () =
        let result = getData () |> findJoltageAnswer

        printf $"Day 10 Part 1 Answer: {result}\n"


    let part2 () =
        let result = getData () |> findArrangements

        printf $"Day 10 Part 2 Answer: {result}\n"
