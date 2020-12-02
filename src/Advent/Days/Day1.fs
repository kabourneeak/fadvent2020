namespace Days

open Utils.FileUtils

module Day1 =
    let getExpenses =
        getLines "./inputs/day1part1.txt"
        |> Seq.map int

    type ExpensePair = {
        Left : int
        Right : int
    }

    let findExpense allExpenses =
        let expenses =
            Set.ofSeq allExpenses

        let pairs =
            Seq.map (fun x -> { Left = x; Right = 2020 - x}) allExpenses

        let matches =
            Seq.filter (fun ep -> expenses.Contains(ep.Right)) pairs

        Seq.head matches
    
    let Part1 =
        let ep =
            findExpense getExpenses

        printf $"Day 1 Part 1 Answer: {ep.Left} x {ep.Right} = {ep.Left * ep.Right}\n"
        ()

    let Part2 = ()
