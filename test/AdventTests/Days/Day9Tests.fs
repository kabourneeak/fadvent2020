namespace AdventTests.Days

module Day9Tests =

    open NUnit.Framework
    open FsUnit
    open Days.Day9

    [<Test>]
    let ``executeUntilLoop should solve part1 example`` () =
        // arrange
        // act
        // assert
        [ "35"
          "20"
          "15"
          "25"
          "47"
          "40"
          "62"
          "55"
          "65"
          "95"
          "102"
          "117"
          "150"
          "182"
          "127"
          "219"
          "299"
          "277"
          "309"
          "576" ]
        |> firstInvalidEmission 5
        |> should equal 127

    [<Test>]
    let ``findWeakness should solve part2 example`` () =
        // arrange
        // act
        // assert
        [ "35"
          "20"
          "15"
          "25"
          "47"
          "40"
          "62"
          "55"
          "65"
          "95"
          "102"
          "117"
          "150"
          "182"
          "127"
          "219"
          "299"
          "277"
          "309"
          "576" ]
        |> findWeakness 5
        |> should equal 62
