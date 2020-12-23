namespace AdventTests.Days

module Day6Tests =

    open NUnit.Framework
    open FsUnit
    open Days.Day6

    [<Test>]
    let ``sumDistinctYeses should solve part1 example`` () =
        // arrange
        // act
        // assert
        [ "abc"
          ""
          "a"
          "b"
          "c"
          ""
          "ab"
          "ac"
          ""
          "a"
          "a"
          "a"
          "a"
          ""
          "b" ]
        |> sumDistinctYeses
        |> should equal 11

    [<Test>]
    let ``sumUnanimousYeses should solve part2 example`` () =
        // arrange
        // act
        // assert
        [ "abc"
          ""
          "a"
          "b"
          "c"
          ""
          "ab"
          "ac"
          ""
          "a"
          "a"
          "a"
          "a"
          ""
          "b" ]
        |> sumUnanimousYeses
        |> should equal 6
