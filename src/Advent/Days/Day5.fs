namespace Days

open Utils.FileUtils

module Day5 =

    let getBoardingPasses =
        getLines "./inputs/day5part1.txt" |> Seq.toList

    let rec findBinaryPosition lowValue highValue range values =
        match values with
        | [] -> 0
        | h :: t ->
            let half = range / 2

            let valueToAdd =
                match h with
                | lv when lv = lowValue -> 0
                | hv when hv = highValue -> half
                | _ -> failwith $"Unexpected character: {h}"

            valueToAdd
            + findBinaryPosition lowValue highValue half t

    let getRow boardingPass =
        boardingPass
        |> Seq.take 7
        |> List.ofSeq
        |> findBinaryPosition 'F' 'B' 128

    let getColumn boardingPass =
        boardingPass
        |> Seq.skip 7
        |> List.ofSeq
        |> findBinaryPosition 'L' 'R' 8

    let getSeatId boardingPass =
        let row = getRow boardingPass
        let column = getColumn boardingPass
        row * 8 + column

    let part1 () =
        let result =
            getBoardingPasses |> Seq.map getSeatId |> Seq.max

        printf $"Day 5 Part 1 Answer: {result}\n"

    let part2 () =

        let tryGetEmptySeatBetween (seat1, seat2) =
            if (seat2 - seat1) = 2 then Some(seat1 + 1) else None

        let result =
            getBoardingPasses
            |> Seq.map getSeatId
            |> Seq.sort
            |> Seq.pairwise
            |> Seq.pick tryGetEmptySeatBetween

        printf $"Day 5 Part 2 Answer: {result}\n"
