namespace AdventTests.Days

module Day2Tests =

    open NUnit.Framework
    open FsUnit
    open Days.Day2

    [<Test>]
    let ``countValidPasswords should solve part1 example`` () =
        // arrange
        let passwords =
            [ "1-3 a: abcde"
              "1-3 b: cdefg"
              "2-9 c: ccccccccc" ]

        // act
        let result =
            countValidPasswords passwords isPasswordValid1

        // assert
        result |> should equal 2

    [<Test>]
    let ``countValidPasswords2 should solve part2 example`` () =
        // arrange
        let passwords =
            [ "1-3 a: abcde"
              "1-3 b: cdefg"
              "2-9 c: ccccccccc" ]

        // act
        let result =
            countValidPasswords passwords isPasswordValid2

        // assert
        result |> should equal 1
