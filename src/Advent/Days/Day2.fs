namespace Days

open Utils.FileUtils
open System.Text.RegularExpressions

module Day2 =
    type PasswordModel = {
        Min : int
        Max : int
        Char : char
        Password : string
    }

    let stringToPasswordModel s =
        let pattern = @"^(\d+)-(\d+) (\w): (\w+)$"
        let matched = Regex.Match(s, pattern)
        {
            Min = matched.Groups.[1].Value |> int
            Max = matched.Groups.[2].Value |> int
            Char = matched.Groups.[3].Value |> char
            Password = matched.Groups.[4].Value
        }

    let getPasswords =
        getLines "./inputs/day2part1.txt"
        |> Seq.map stringToPasswordModel

    let matchesPasswordCountPolicy model =
        let charCount = 
            model.Password
            |> Seq.filter (fun c -> c.Equals model.Char)
            |> Seq.length

        charCount >= model.Min && charCount <= model.Max

    let Part1 =
        let validCount = 
            getPasswords
            |> Seq.filter matchesPasswordCountPolicy
            |> Seq.length

        printf $"Day 2 Part 1 Answer: There are {validCount} valid passwords\n"
        ()

    let Part2 = ()
