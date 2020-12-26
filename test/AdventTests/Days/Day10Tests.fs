namespace AdventTests.Days

module Day10Tests =

    open NUnit.Framework
    open FsUnit
    open Days.Day10

    [<Test>]
    let ``part1 should solve part1 example 1`` () =
        // arrange
        // act
        // assert
        [ "16"
          "10"
          "15"
          "5"
          "1"
          "11"
          "7"
          "19"
          "6"
          "12"
          "4" ]
        |> findJoltageAnswer
        |> should equal 35

    [<Test>]
    let ``part1 should solve part2 example 2`` () =
        // arrange
        // act
        // assert
        [ "28"
          "33"
          "18"
          "42"
          "31"
          "14"
          "46"
          "20"
          "48"
          "47"
          "24"
          "23"
          "49"
          "45"
          "19"
          "38"
          "39"
          "11"
          "1"
          "32"
          "25"
          "35"
          "8"
          "17"
          "7"
          "9"
          "4"
          "2"
          "34"
          "10"
          "3" ]
        |> findJoltageAnswer
        |> should equal 220

    [<Test>]
    let ``part2 should solve part2 example 1`` () =
        // arrange
        // act
        // assert
        [ "16"
          "10"
          "15"
          "5"
          "1"
          "11"
          "7"
          "19"
          "6"
          "12"
          "4" ]
        |> findArrangements
        |> should equal 8

    [<Test>]
    let ``part2 should solve part2 example 2`` () =
        // arrange
        // act
        // assert
        [ "28"
          "33"
          "18"
          "42"
          "31"
          "14"
          "46"
          "20"
          "48"
          "47"
          "24"
          "23"
          "49"
          "45"
          "19"
          "38"
          "39"
          "11"
          "1"
          "32"
          "25"
          "35"
          "8"
          "17"
          "7"
          "9"
          "4"
          "2"
          "34"
          "10"
          "3" ]
        |> findArrangements
        |> should equal 19208
