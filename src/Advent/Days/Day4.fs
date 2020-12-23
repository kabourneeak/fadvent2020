namespace Days

open Utils.FileUtils
open System.Text.RegularExpressions

module Day4 =

    let getPassports =
        getLines "./inputs/day4part1.txt" |> Seq.toList

    type Passport = Map<string, string>

    let passportFactory passportLines =

        passportLines
        |> splitWhen (fun x -> x = "")
        |> Seq.map
            (fun lines ->
                lines
                |> Seq.collect (fun line -> line.Split(" "))
                |> Seq.map
                    (fun kvp ->
                        let parts = kvp.Split(':')
                        (parts.[0], parts.[1]))
                |> Passport)


    let intTryParse str =
        match System.Int32.TryParse(str: string) with
        | (true, int) -> Some(int)
        | _ -> None

    let validateRange x min max =
        match intTryParse x with
        | Some intx -> min <= intx && intx <= max
        | None -> false

    let validateHgt (x: string) =
        let secondLastCharIndex = max (x.Length - 2) 0
        let justBeforsecondLastCharIndex = max (secondLastCharIndex - 1) 0
        let units = x.[secondLastCharIndex..]
        let number = x.[..justBeforsecondLastCharIndex]

        match (units, number) with
        | ("cm", hgt) -> validateRange hgt 150 193
        | ("in", hgt) -> validateRange hgt 59 76
        | _ -> false

    let hasValidFields passport =
        [ "byr"
          "iyr"
          "eyr"
          "hgt"
          "hcl"
          "ecl"
          "pid" ]
        |> Seq.forall (fun key -> Map.containsKey key passport)

    let hasValidValues passport =
        [ "byr", (fun x -> validateRange x 1920 2002)
          "iyr", (fun x -> validateRange x 2010 2020)
          "eyr", (fun x -> validateRange x 2020 2040)
          "hgt", validateHgt
          "hcl", (fun (x: string) -> Regex.IsMatch(x, "#[0-9|a-f]{6}"))
          "ecl",
          (fun (x: string) ->
              [ "amb"
                "blu"
                "brn"
                "gry"
                "grn"
                "hzl"
                "oth" ]
              |> List.contains x)
          "pid", (fun (x: string) -> x.Length = 9) ]
        |> Seq.forall
            (fun (key, validation) ->
                Map.containsKey key passport
                && validation (passport.Item key))

    let countPassportsWithValidFields (passportsLines: List<string>) =
        passportsLines
        |> passportFactory
        |> Seq.filter hasValidFields
        |> Seq.length

    let countPassportsWithValidValues (passportsLines: List<string>) =
        passportsLines
        |> passportFactory
        |> Seq.filter hasValidValues
        |> Seq.length

    let part1 =
        let result =
            countPassportsWithValidFields getPassports

        printf $"Day 4 Part 1 Answer: {result}\n"

    let part2 =
        let result =
            countPassportsWithValidValues getPassports

        printf $"Day 4 Part 2 Answer: {result}\n"
