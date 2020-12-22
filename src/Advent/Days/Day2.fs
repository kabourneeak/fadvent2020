namespace Days

open Utils.FileUtils

module Day2 =

    let getPasswordDb =
        getLines "./inputs/day2part1.txt" |> Seq.toList

    type Range = { Min: int; Max: int }

    type PasswordEntry =
        { Range: Range
          Char: char
          Password: string }

    let parseRange (rangeString: string) =
        let parts = rangeString.Split("-")
        let min = parts.[0] |> int
        let max = parts.[1] |> int
        { Min = min; Max = max }

    let parseChar (charString: string) = charString.Replace(":", "").[0]

    let passwordEntryFactory (entryString: string) =
        let parts = entryString.Split(" ")

        { Range = parseRange (parts.[0])
          Char = parseChar (parts.[1])
          Password = parts.[2] }

    let countValidPasswords (passwordDb: List<string>) isPasswordValid =
        passwordDb
        |> Seq.map passwordEntryFactory
        |> Seq.filter isPasswordValid
        |> Seq.length

    let isPasswordValid1 pe =
        let charCount =
            pe.Password
            |> Seq.filter ((=) pe.Char)
            |> Seq.length

        pe.Range.Min <= charCount
        && charCount <= pe.Range.Max

    let isPasswordValid2 pe =
        let firstIndexIsChar =
            Seq.tryItem (pe.Range.Min - 1) pe.Password = Some pe.Char

        let secondIndexIsChar =
            Seq.tryItem (pe.Range.Max - 1) pe.Password = Some pe.Char

        (firstIndexIsChar || secondIndexIsChar)
        && not (firstIndexIsChar && secondIndexIsChar)

    let part1 =
        let result =
            countValidPasswords getPasswordDb isPasswordValid1

        printf $"Day 2 Part 1 Answer: {result}\n"

    let part2 =
        let result =
            countValidPasswords getPasswordDb isPasswordValid2

        printf $"Day 2 Part 2 Answer: {result}\n"
