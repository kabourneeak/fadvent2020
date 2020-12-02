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

    let findExpense target allExpenses =
        let expenses =
            Set.ofSeq allExpenses

        let matches =
            Seq.filter (fun l -> expenses.Contains(target - l)) allExpenses
            |> Seq.map (fun l -> { Left = l; Right = target - l})

        Seq.head matches

    let findExpenseTriplet target allExpenses =
        let expenses =
            Set.ofSeq allExpenses

        let pairs = 
            Seq.allPairs allExpenses allExpenses
            |> Seq.filter (fun (l,r) -> l <> r)
        
        let matches =
            Seq.filter (fun (a, b) -> expenses.Contains(target - a - b)) pairs
            |> Seq.map (fun (a, b) -> (a, b, target - a - b))

        Seq.head matches
    
    let Part1 =
        let ep =
            findExpense 2020 getExpenses

        printf $"Day 1 Part 1 Answer: {ep.Left} x {ep.Right} = {ep.Left * ep.Right}\n"
        ()

    let Part2 =
        let (a, b, c) =
            findExpenseTriplet 2020 getExpenses

        printf $"Day 1 Part 2 Answer: {a} x {b} x {c} = {a * b * c}\n"
        ()

