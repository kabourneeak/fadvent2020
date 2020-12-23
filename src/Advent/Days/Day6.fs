namespace Days

open Utils.FileUtils

module Day6 =

    let getData () =
        getLines "./inputs/day6part1.txt" |> Seq.toList

    let sumDistinctYeses lines =
        let countDistinctYesses answerLines =
            answerLines
            |> Seq.collect Seq.toList
            |> Seq.distinct
            |> Seq.length

        lines
        |> splitWhen ((=) "")
        |> Seq.sumBy countDistinctYesses

    let sumUnanimousYeses lines =
        let countUnanimousYesses answerLines =
            answerLines
            |> Seq.collect Seq.toList
            |> Seq.countBy int
            |> Seq.filter (fun (_, count) -> count = Seq.length answerLines)
            |> Seq.length

        lines
        |> splitWhen ((=) "")
        |> Seq.sumBy countUnanimousYesses


    let part1 () =
        let result = getData () |> sumDistinctYeses

        printf $"Day 6 Part 1 Answer: {result}\n"


    let part2 () =
        let result = getData () |> sumUnanimousYeses

        printf $"Day 6 Part 2 Answer: {result}\n"
