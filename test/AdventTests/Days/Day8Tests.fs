namespace AdventTests.Days

module Day8Tests =

    open NUnit.Framework
    open FsUnit
    open Days.Day8

    [<Test>]
    let ``executeUntilLoop should solve part1 example`` () =
        // arrange
        // act
        // assert
        [ "nop +0"
          "acc +1"
          "jmp +4"
          "acc +3"
          "jmp -3"
          "acc -99"
          "acc +1"
          "jmp -4"
          "acc +6" ]
        |> parseInstructions
        |> execute
        |> function
        | Loop x -> x.Accumlator
        | unexpected -> failwith $"Unexpected result {unexpected}"
        |> should equal 5

    [<Test>]
    let ``fixUp should solve part2 example`` () =
        // arrange
        // act
        // assert
        [ "nop +0"
          "acc +1"
          "jmp +4"
          "acc +3"
          "jmp -3"
          "acc -99"
          "acc +1"
          "jmp -4"
          "acc +6" ]
        |> parseInstructions
        |> fixUp
        |> function
        | Finished x -> x.Accumlator
        | unexpected -> failwith $"Unexpected result {unexpected}"
        |> should equal 8
