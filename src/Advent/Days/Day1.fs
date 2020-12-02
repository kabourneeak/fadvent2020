namespace Days

open Utils.FileUtils

module Day1 =
    let getExpenses =
        getLines "./inputs/day1part1.txt"
        |> Seq.map int
        |> Seq.toList

    let findExpensePair target allExpenses =
        let expenses = Set.ofSeq allExpenses

        Seq.filter (fun l -> expenses.Contains(target - l)) allExpenses
        |> Seq.map (fun l -> (l, target - l))
        |> Seq.tryHead

    let findExpenseTriplet target allExpenses =
        let rec findExpenseTripletRec expenses =
            match expenses with
            | []
            | [ _ ]
            | [ _; _ ] -> None
            | h :: t ->
                match findExpensePair (target - h) t with
                | Some (a, b) -> Some((h, a, b))
                | None -> findExpenseTripletRec t

        findExpenseTripletRec allExpenses

    let part1 =
        let result = findExpensePair 2020 getExpenses

        let answerText =
            match result with
            | Some (a, b) -> $"{a} x {b} = {a * b}"
            | None -> "No Solution Found"

        printf $"Day 1 Part 1 Answer: {answerText}\n"

    let part2 =
        let result = findExpenseTriplet 2020 getExpenses

        let answerText =
            match result with
            | Some (a, b, c) -> $"{a} x {b} x {c} = {a * b * c}"
            | None -> "No Solution Found"

        printf $"Day 1 Part 2 Answer: {answerText}\n"
