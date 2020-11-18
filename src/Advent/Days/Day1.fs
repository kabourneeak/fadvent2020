namespace Days

open System.IO

module Day1 =
    let getModuleWeights =
        let readLines (filePath: string) =
            seq {
                use sr = new StreamReader(filePath)
                while not sr.EndOfStream do
                    yield sr.ReadLine()
            }

        let weights =
            readLines "../../inputs/day1part1.txt"
            |> Seq.map int

        weights

    let getRequiredFuel moduleWeight = moduleWeight / 3 - 2

    let Part1 =
        let sum =
            Seq.sumBy getRequiredFuel getModuleWeights

        printf $"Day 1 Part 1 Answer: {sum}\n"
        ()

    let Part2 = ()
